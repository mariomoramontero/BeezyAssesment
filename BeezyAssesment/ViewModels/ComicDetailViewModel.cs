using BeezyAssesment.Models;
using BeezyAssesment.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeezyAssesment.ViewModels
{
    [QueryProperty(nameof(ComicId), nameof(ComicId))]
    public class ComicDetailViewModel : BaseViewModel
    {
        private int comicId;
        public Comic ComicData { get; set; }

        //public string Authors => string.Join (",", comicData.creators.items.items(p=>p.items)
        public string Price => $"{ComicData.prices.FirstOrDefault()?.price}$";

        public int ComicId
        {
            get
            {
                return comicId;
            }
            set
            {
                comicId = value;
                ComicData = MarvelClient.Instance.CatchedComicData.data.results.FirstOrDefault(p => p.id == comicId);
                OnPropertyChanged(nameof(ComicData));
                OnPropertyChanged(nameof(Price));
              
            }
        }

    }
}
