using System;
namespace CAB301Assignment {

    /// <summary>
    /// Node class for Binary Search Tree
    /// </summary>
    public class MovieNode {
        public Movie movie;
        public MovieNode left;
        public MovieNode right;

        public MovieNode(Movie movie) {
            this.movie = movie;
        }
    }
}

