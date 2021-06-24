using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        
        public DetailsPage(Movie.Item movie)
        {
            InitializeComponent();

            MovieName.Text = movie.title;
            MovieImage.Source = movie.poster_path;
            MovieOverview.Text = movie.overview;
            this.BindingContext = this;
            
        }
    }
}