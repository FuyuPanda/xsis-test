using System.Security.Cryptography.X509Certificates;
using Xsis.Api.Model;
using Xsis.Api.Model.Movies;
using Xsis.Api.Service.Movies;
using Xsis.Data.Entity;

namespace Xsis.Api.Test
{
    [TestFixture]
    public class InsertMovieTest
    {
        private MovieService _service;
        private XsisContext db { get; }
        [SetUp]
        public void Setup()
        {
            
            _service = new MovieService(db);
        }

        [Test]
        public void Movie_CanBe_Inserted_ReturnTrue()
        {
            InsertMovieModel model = new InsertMovieModel
            {
                description = "description",
                title = "testtt",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.InsertMovie(model);
            Assert.AreEqual(response.message,"OK");
        }

        [Test]
        public void Movie_Title_IsNull_Or_Empty()
        {
            InsertMovieModel model = new InsertMovieModel
            {
                description = "description",
                title = "",
                image = "",
                rating = 8
            };
            BaseResponse response=_service.InsertMovie(model);
            Assert.AreEqual(response.message, "Movie title must be filled!");
        }

        [Test]
        public void Movie_Description_IsNull_Or_Empty()
        {
            InsertMovieModel model = new InsertMovieModel
            {
                description = "",
                title = "testt",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.InsertMovie(model);
            Assert.AreEqual(response.message, "Movie description must be filled!");

        }

        [Test]
        public void Movie_Rating_MoreThan_10()
        {
            InsertMovieModel model = new InsertMovieModel
            {
                description = "tesssting",
                title = "testt",
                image = "",
                rating = 11
            };
            BaseResponse response = _service.InsertMovie(model);
            Assert.AreEqual(response.message, "Movie rating must be less or equal than 10!");

        }

        [Test]
        public void Movie_Already_Inserted()
        {
            InsertMovieModel model = new InsertMovieModel
            {
                description = "description",
                title = "testtt",
                image = "",
                rating = 8
            };
            BaseResponse response = _service.InsertMovie(model);
            Assert.AreEqual(response.message, "DUPLICATE ENTRY");
        }

    }
}