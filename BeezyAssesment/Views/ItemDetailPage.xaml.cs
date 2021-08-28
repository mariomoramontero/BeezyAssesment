using BeezyAssesment.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BeezyAssesment.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}