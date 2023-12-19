using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;
using Xsis.Api.Model.Movies;

namespace Xsis.Api.Test
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void Movie_CanBe_Inserted_ReturnTrue()
        {

        }

        [TestMethod]
        public void Movie_Title_IsNull_Or_Empty()
        {
            var insertModel = new InsertMovieModel
            {
                
            };
        }
    }
}
