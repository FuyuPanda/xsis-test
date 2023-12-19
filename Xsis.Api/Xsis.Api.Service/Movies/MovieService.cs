using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Api.Common;
using Xsis.Api.Model;
using Xsis.Api.Model.Movies;
using Xsis.Data.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace Xsis.Api.Service.Movies
{
    public interface IMovieService
    {
        Task<BaseResponse> Get();
        Task<BaseResponse> Get(int id);
        BaseResponse InsertMovie(InsertMovieModel model);
        BaseResponse UpdateMovie(UpdateMovieModel model,int id);
    }
    public class MovieService : IMovieService
    {
        private readonly XsisContext db;
        public MovieService(XsisContext _db)
        {
            db = _db;
        }

        public async Task<BaseResponse> Get()
        {
            BaseResponse response = ResponseConstants.ERROR;
            try
            {
                var lst = await (from a in db.Movies
                                 select new GetMovieModel
                                 {
                                     id = a.ID,
                                     created_at = a.CreatedAt,
                                     description = a.Description,
                                     image = a.Image,
                                     rating = a.Rating,
                                     title = a.Title,
                                     updated_at = a.UpdatedAt
                                 }
                                 ).ToListAsync();
                if(lst.Count>0)
                {
                    response = ResponseConstants.OK;
                    response.data = lst;
                }
                else
                {
                    response = ResponseConstants.NO_RESULT;
                }
            }
            catch (Exception e)
            {
                response.message= e.Message;
            }
            return response;
        }

        public async Task<BaseResponse> Get(int id)
        {
            BaseResponse response = ResponseConstants.ERROR;
            try
            {
                var lst = await (from a in db.Movies
                                 where a.ID== id
                                 select new GetMovieModel
                                 {
                                     id = a.ID,
                                     created_at = a.CreatedAt,
                                     description = a.Description,
                                     image = a.Image,
                                     rating = a.Rating,
                                     title = a.Title,
                                     updated_at = a.UpdatedAt
                                 }
                                 ).FirstOrDefaultAsync();
                if (lst!=null)
                {
                    response = ResponseConstants.OK;
                    response.data = lst;
                }
                else
                {
                    response = ResponseConstants.NOT_FOUND;
                }
            }
            catch (Exception e)
            {
                response.message = e.Message;
            }
            return response;
        }

        public BaseResponse InsertMovie(InsertMovieModel model)
        {
            BaseResponse response = ResponseConstants.ERROR;
            if(string.IsNullOrEmpty(model.title))
            {
                response.message = "Movie title must be filled!";
                return response;
            }

            if (string.IsNullOrEmpty(model.description))
            {
                response.message = "Movie description must be filled!";
                return response;
            }

            if(model.rating>10)
            {
                response.message = "Movie rating must be less or equal than 10!";
                return response;
            }

            var check=db.Movies.Where(a=>a.Title.ToLower()==model.title.ToLower()).FirstOrDefault();
            if(check!=null)
            {
                response = ResponseConstants.DUPLICATE_ENTRY;
            }
            else
            {
                using(var dbcxtransaction=db.Database.BeginTransaction())
                {
                    check = new Data.Entity.Movies
                    {
                        CreatedAt = DateTime.Now,
                        Title = model.title,
                        Description = model.description,
                        Image = model.image ?? string.Empty,
                        Rating = model.rating,
                        UpdatedAt = DateTime.Now,

                    };
                    db.SaveChanges();
                    dbcxtransaction.Commit();
                    response = ResponseConstants.OK;
                }
            }

            return response;
        }

        public BaseResponse UpdateMovie(UpdateMovieModel model, int id)
        {
            BaseResponse response = ResponseConstants.ERROR;
            if (string.IsNullOrEmpty(model.title))
            {
                response.message = "Movie title must be filled!";
                return response;
            }

            if (string.IsNullOrEmpty(model.description))
            {
                response.message = "Movie description must be filled!";
                return response;
            }

            if (model.rating > 10)
            {
                response.message = "Movie rating must be less or equal than 10!";
                return response;
            }

            var check = db.Movies.Where(a => a.Title.ToLower() == model.title.ToLower() && a.ID==id).FirstOrDefault();
            if (check != null)
            {
                using(var dbcxtransaction=db.Database.BeginTransaction())
                {

                    check.Title = model.title;
                    check.Description = model.description;
                    check.Image = model.image ?? string.Empty;
                    check.Rating = model.rating;
                    check.UpdatedAt = DateTime.Now;
                    db.Entry(check).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    dbcxtransaction.Commit();

                }

            }
            else
            {
                response = ResponseConstants.NOT_FOUND;
            }
            return response;
        }

    }
}
