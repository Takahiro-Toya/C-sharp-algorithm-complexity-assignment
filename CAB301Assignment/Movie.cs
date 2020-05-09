using System;
using System.Diagnostics.CodeAnalysis;

namespace CAB301Assignment {
    public class Movie: IComparable<Movie> {

        public string title;
        public string starring;
        public string director;
        public string duration;
        public Genre genre;
        public Classification classification;
        public string releaseDate;

        private int numBorrowed = 0;
        private int numCopies = 0;   

        public Movie(string title, string starring, string director, string duration, Genre genre, Classification classification, string releaseDate, int numCopies) 
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
            this.numCopies = numCopies;
        }

        public Movie MakeCopy() {
            return new Movie(title, starring, director, duration, genre, classification, releaseDate, numCopies);
        }

        public bool Borrowed() {
            if (numCopies <= 0) {
                return false;
            } else {
                numBorrowed++;
                numCopies--;
                return true;
            }
        }

        public void IncrementNumCopies() {
            numCopies++;
        }

        public void DecrementNumCopies() {
            if(numCopies - 1 < 0) {
                return;
            } else {
                numCopies--;
            }
        }

        override public string ToString() {
            return string.Format(
                "==Movie Info==\n" +
                "-Title: {0}\n" +
                "-Starring: {1}\n" +
                "-Director: {2}\n" +
                "-Duration: {3}\n" +
                "-Genre: {4}\n" +
                "-Classfication: {5}\n" +
                "-Release: {6}\n" +
                "==============\n",
                title, starring, director, duration,
                GenreMethods.toString(genre), ClassificationMethods.toString(classification),
                releaseDate);
             
        }

        public int CompareTo( Movie other) {
            return string.Compare(this.title, other.title);
        }
    }
}
