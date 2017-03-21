using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using YDemo.Models;

namespace YDemo.Controllers
{
    public class movieAPIController : ApiController
    {
        private IMovieRepository<Movie> repo;

        public movieAPIController()
        : this(new MovieRepository<Movie>(new MovieDBContext()))
        {
        }

        public movieAPIController(IMovieRepository<Movie> inRepo)
        {
            repo = inRepo;
        }
        //private MovieDBContext db = new MovieDBContext();

        //取得所有電影
        public IEnumerable<Movie> GetAllMovies()
        {
            return repo.Reads();
        }

        //搜尋電影 by id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = repo.Read(x => x.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        /// <summary>
        /// 取得指定類型電影清單
        /// URI: /api/movieAPI?Genre=MVC
        /// Method: GET
        /// </summary>
        /// <param name="pCategory"></param>
        /// <returns></returns>
        public IEnumerable<Movie> GetProductsByCategory(string Genre)
        {
            IEnumerable<Movie> movies = repo.Reads();
            var cProducts = movies.Where(p => p.Genre == Genre);
            if (cProducts.FirstOrDefault<Movie>() != null)
                return cProducts;
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// 更新 movie.
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovies(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.ID)
            {
                return BadRequest();
            }

            //db.Entry(movie).State = EntityState.Modified;
            repo.Update(movie);
            
            try
            {
                //db.SaveChanges();
                repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        /// 新增 movie
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovies(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Movies.Add(movie);
            repo.Create(movie);
            

            try
            {
                //db.SaveChanges();
                repo.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MoviesExists(movie.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = movie.ID }, movie);
        }


        /// 刪除 movie.
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovies(int id)
        {
            Movie movies = repo.Read(x => x.ID == id);
            if (movies == null)
            {
                return NotFound();
            }

            //db.Movies.Remove(movies);
            //db.SaveChanges();
            repo.Delete(movies);
            repo.SaveChanges();

            return Ok(movies);
        }


        private bool MoviesExists(int id)
        {
            return repo.Reads().Count(e => e.ID == id) > 0;
        }

    }
}
