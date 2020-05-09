using System;
namespace CAB301Assignment {
    public class MovieCollection {

        /// <summary>
        /// This must be binary search tree
        /// </summary>
        private Movie[] collection = new Movie[0];


        public MovieCollection() {


        }

        public void AddMovie(Movie movie) {

        }

        public void RemoveMovie(string title) {

        }

        public Movie GetMovie(string title) {

            return null;
        }


        public Movie[] GetAllMovies() {

            // sort collection

            return null;
        }

        public Movie[] GetTopTenMoviews() {

            // retrieve top 10 (order in 1st - 10th)

            return null;
        }

        public string GetTop10List() {

            // for each GetTopTenMoview()
            // then convert each to string (title only)

            return null;
        }

        public string[] GetAllMovieTitle() {
            string[] array = new string[collection.Length];
            for(int i=0; i<collection.Length; i++) {
                array[i] = collection[i].title;
            }
            return array;
        }
    }
}
