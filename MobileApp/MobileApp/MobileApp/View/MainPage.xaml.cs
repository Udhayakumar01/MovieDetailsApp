using MobileApp.View;
using MobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

            InitializeComponent();

        }
        protected async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            /*var test = null;
            test = e.CurrentSelection as Movie;
            if (test! = null)
            {
                await Navigation.PushAsync(new DetailsPage(test));
            }*/
            Movie.Item movie = new Movie.Item();
            movie = e.CurrentSelection[0] as Movie.Item;
            if (movie != null)
            {
                await Navigation.PushAsync(new DetailsPage(movie));
            }

        }

    }
}
