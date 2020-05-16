using System;
namespace CAB301Assignment {

    /// <summary>
    /// This class holds movies that are in same rank. This class allows the system to easily display same rank movies.
    /// Generating top10 will be something like Ranking top10 = new Ranking[10], where each Rank object in the array
    /// represents each rank.
    /// </summary>
    public class Ranking {

        // pre set array size since the specification confirms that it's ok not to think of array resizing
        // and becuase Array.Resize<> cannot be included in algorithm analysis. 
        public Movie[] movies = new Movie[100];
        private int counter = 0;
        public int Counter {
            get { return counter; }
        }

        public void Add(Movie movie) {
            movies[counter] = movie;
            counter++;
        }
    }
}
