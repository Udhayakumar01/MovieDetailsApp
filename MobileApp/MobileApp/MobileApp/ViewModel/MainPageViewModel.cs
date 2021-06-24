using MobileApp.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModel
{
    public class MainPageViewModel : BaseClass
    {
        public ObservableCollection<Movie.Item> MovieList { get; set; }
        List<Movie.Item> source;

        public MainPageViewModel()
        {
            PopulateData();
        }

        string Title;
        double Popularity;
        string Poster_Path;
        string Release_Date;
        string Overview;

        public string title {
            get { return Title; }
            set {
                Title = value;
                NotifyPropertyChanged();
            } }

        public double popularity { get { return Popularity; }
            set {
                Popularity = value;
                NotifyPropertyChanged();
            } }


        public string poster_path { get { return Poster_Path; } 
            set { 
                Poster_Path =   value; 
                NotifyPropertyChanged(); 
            } }

        public string release_date { get { return Release_Date; } 
            set {
                Release_Date = value;
                NotifyPropertyChanged();
            } }

        public string overView
        {
            get { return Overview; }
            set
            {
                Overview = value;
                NotifyPropertyChanged();
            }
        }
        
        public void PopulateData()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var responseMessage =  httpClient.GetAsync(Constants.Url);
                responseMessage.Wait();
                var result = responseMessage.Result;
                //check the status of api if its ok
                if (result.IsSuccessStatusCode)
                {
                    var stringResponse = result.Content.ReadAsStringAsync().Result;

                    JsonSerializerSettings Settings = new JsonSerializerSettings() { MetadataPropertyHandling = MetadataPropertyHandling.Ignore, DateParseHandling = DateParseHandling.None };
                    //Decentralize the API data  
                    Movie.Root listOfMovies = JsonConvert.DeserializeObject<Movie.Root>(stringResponse);
                    source = new List<Movie.Item>();

                    foreach (var item in listOfMovies.items)
                    {
                        Movie.Item movie = new Movie.Item();
                        movie.title = item.title;
                        movie.popularity = item.popularity;
                        movie.release_date = "Movie Release Date "+ item.release_date;
                        movie.poster_path = "https://image.tmdb.org/t/p/w500/"+ item.poster_path;
                        movie.overview = item.overview;
                        source.Add(movie);
                    }
                    //Assigning values to the MovieList
                    MovieList = new ObservableCollection<Movie.Item>(source);
                }
                
            }
        }
    }
}