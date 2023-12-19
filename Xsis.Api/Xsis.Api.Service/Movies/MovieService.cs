using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Api.Common;
using Xsis.Api.Model;
using Xsis.Api.Model.Movies;

namespace Xsis.Api.Service.Movies
{
    public interface IMovieService
    {
        BaseResponse InsertMovie(InsertMovieModel model);
    }
    public class MovieService : IMovieService
    {
        public BaseResponse InsertMovie(InsertMovieModel model)
        {
            BaseResponse response = ResponseConstants.ERROR;
            if(string.IsNullOrEmpty(model.title))
            {
                response.data = false;
            }
            return response;
        }
    }
}
