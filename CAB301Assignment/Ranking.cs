using System;
namespace CAB301Assignment {

    public class Ranking {

        public Movie[] movies = new Movie[0];

        public Ranking() {
        }

        public void Add(Movie movie) {
            Array.Resize(ref movies, movies.Length + 1);
            movies[movies.Length - 1] = movie;
        }
    }
}
