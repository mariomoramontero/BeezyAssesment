
using BeezyAssesment.Models;
using BeezyAssesment.Services;
using BeezyAssesment.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeezyAssesment.ViewModels
{
    public class ComicsViewModel : BaseViewModel
    {
        private Comic _selectedItem;

        public ObservableCollection<Comic> Comics { get; }
        public Command LoadItemsCommand { get; }      
        public Command<Comic> ItemTapped { get; }
        public string FilterTitleStartsWith { get; set; }

        public ComicsViewModel()
        {
            Title = "Marvel comic browser";
            Comics = new ObservableCollection<Comic>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());            
            ItemTapped = new Command<Comic>(OnItemSelected);

  
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Comics.Clear();

                ComicDataWrapper comics;

                if (string.IsNullOrEmpty(FilterTitleStartsWith))
                    comics= await MarvelClient.Instance.GetComics();
                else
                    comics = await MarvelClient.Instance.GetComicsByTitleStartsWith(FilterTitleStartsWith);

                foreach (var item in comics.data.results)
                {
                    Comics.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
      
        public void OnAppearing()
        {
            if (MarvelClient.Instance.CatchedComicData==null)
                IsBusy = true;

            SelectedItem = null;
        }

        public Comic SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

     

        async void OnItemSelected(Comic item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ComicDetailPage)}?{nameof(ComicDetailViewModel.ComicId)}={item.id}");
            

        }
    }
}