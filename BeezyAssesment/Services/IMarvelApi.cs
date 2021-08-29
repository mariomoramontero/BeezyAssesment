using BeezyAssesment.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeezyAssesment.Services
{
    
    public interface IMarvelApi
    {

        [Get("/v1/public/comics")]
        Task<ApiResponse<ComicDataWrapper>> GetComics();

        [Get("/v1/public/comics?titleStartsWith={titleStartsWith}")]
        Task<ApiResponse<ComicDataWrapper>> GetComicsByTitleStartsWith(string titleStartsWith);

        //[Get("/v1/public/comics/{comicId}")]
        //Task<ApiResponse<ComicDataWrapper>> GetComicById(string comicId);
    }
}
