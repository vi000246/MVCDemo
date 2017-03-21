using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YDemo.Models
{
    public class Movie
    {
        //public Movie() { }

        //public Movie(int ID,string Title,DateTime ReleaseDate,string Genre,decimal Price) {
        //    this.ID = ID;
        //    this.Title = Title;
        //    this.ReleaseDate = ReleaseDate;
        //    this.Genre = Genre;
        //    this.Price = Price;
        //}
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}