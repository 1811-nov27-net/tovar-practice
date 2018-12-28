using Moq;
using MVCDemo.Controllers;
using MVCDemo.DataAccess;
using MVCDemo.Models;
using MVCDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDemo.Testing.MVC.Controllers
{
    public class FakeMovieRepo : IMovieRepo
    {
        public void CreateMovie(Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Movie> GetAll()
        {
            return new List<Movie>
            {
                new Movie { };
            }
        }

        public IEnumerable<Models.Movie> GetAllByCastMember(string cast)
        {
            throw new NotImplementedException();
        }

        public Models.Movie GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class MovieControllersTests
    {

        // tests that wehen the repository has movies to give
        // we'll get an index with with a model (IEnumeralbe<movie>) containing those movies
        public void IndexWithMoviesHasMovies()
        {
        // var db = new MovieDBContext();
        // var controller = new MoviesController();

        // to unit test something like MVC, that uses dependency injection,
        // or really in general, to unit test something with complex (or any) dependencies
        // we will use mocking (with Moq framework)

        var fakerepo = new FakeMovieRepo();
        var controller = new MoviesController(fakerepo);

        // because i used dependency inversion (my controler depends on an interface, not a concrete
        // class) i am able to provide a different implementation

        var data = new List<Movie> { new Movie { Id =1, Title = "Star Wars"} };

        var mockRepo = new Mock<IMovieRepo>();
        mockRepo
            .Setup(repo => repo.GetAll())
            .Returns(data);


            // act

            // assert

        }
    }
}
