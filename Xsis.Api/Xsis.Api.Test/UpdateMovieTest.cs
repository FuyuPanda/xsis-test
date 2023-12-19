using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Api.Model.Movies;
using Xsis.Api.Model;
using Xsis.Api.Service.Movies;
using Xsis.Data.Entity;

namespace Xsis.Api.Test
{
    [TestFixture]
    public class UpdateMovieTest
    {
        private MovieService _service;
        private XsisContext db { get; }
        [SetUp]
        public void Setup()
        {

            _service = new MovieService(db);
        }

        [Test]
        public void Movie_CanBe_Updated_ReturnTrue()
        {
            UpdateMovieModel model = new UpdateMovieModel
            {
                description = "description",
                title = "testtt",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.UpdateMovie(model,1);
            Assert.AreEqual(response.message, "OK");
        }

        [Test]
        public void Movie_Title_IsNull_Or_Empty()
        {
            UpdateMovieModel model = new UpdateMovieModel
            {
                description = "description",
                title = "",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.UpdateMovie(model, 1);
            Assert.AreEqual(response.message, "Movie title must be filled!");
        }

        [Test]
        public void Movie_Description_IsNull_Or_Empty()
        {
            UpdateMovieModel model = new UpdateMovieModel
            {
                description = "",
                title = "testt",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.UpdateMovie(model, 1);
            Assert.AreEqual(response.message, "Movie description must be filled!");

        }

        [Test]
        public void Movie_Rating_MoreThan_10()
        {
            UpdateMovieModel model = new UpdateMovieModel
            {
                description = "tesssting",
                title = "testt",
                image = "",
                rating = 11
            };
            BaseResponse response = _service.UpdateMovie(model, 1);
            Assert.AreEqual(response.message, "Movie rating must be less or equal than 10!");

        }
    }
}
