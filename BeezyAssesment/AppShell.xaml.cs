using BeezyAssesment.ViewModels;
using BeezyAssesment.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BeezyAssesment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ComicDetailPage), typeof(ComicDetailPage));
         
        }

    }
}
