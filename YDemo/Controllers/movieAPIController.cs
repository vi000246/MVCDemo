using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YDemo.Models;

namespace YDemo.Controllers
{
    public class movieAPIController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies;
        }

        public IHttpActionResult GetMovie(string Title)
        {
            var movie = db.Movies.FirstOrDefault((p) => p.Title == Title);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
