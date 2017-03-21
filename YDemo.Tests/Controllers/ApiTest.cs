using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using YDemo.Controllers;
using System.Linq;

namespace YDemo.Tests.Controllers
{
    [TestClass]
    public class ApiTest
    {
        private IMovieRepository<Movie> repo;
        public static List<Movie> data = new List<Movie>() {
            new Movie() { ID=1,Title="印地安那瓊斯",ReleaseDate=DateTime.Now.AddDays(-431),Genre="冒險",Price=300},
            new Movie() { ID=1,Title="星際大戰",ReleaseDate=DateTime.Now.AddDays(-102),Genre="奇幻",Price=200},
            new Movie() { ID=1,Title="鐵達尼號",ReleaseDate=DateTime.Now.AddDays(-587),Genre="愛情",Price=320},
            new Movie() { ID=1,Title="第二次世界大戰",ReleaseDate=DateTime.Now.AddDays(-135),Genre="紀錄片",Price=270} };
        

        public ApiTest()
        : this(new FakeMovieRepository<Movie>(data))
        {
        }

        public ApiTest(IMovieRepository<Movie> inRepo)
        {
            repo = inRepo;
        }

        [TestMethod]
        public void GetAllMovies_ShouldReturnAllMovies()
        {
            IQueryable<Movie> result = repo.Reads();
            Assert.AreEqual(data.Count, result.Count());
        }
    }
}
