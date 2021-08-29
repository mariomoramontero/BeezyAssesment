using BeezyAssesment.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BeezyAssesment.Views
{
    public partial class ComicDetailPage : ContentPage
    {
        public ComicDetailPage()
        {
            InitializeComponent();            
            BindingContext = new ComicDetailViewModel();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}