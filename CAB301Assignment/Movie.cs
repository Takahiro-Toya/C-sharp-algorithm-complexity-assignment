using System;
using System.Diagnostics.CodeAnalysis;

namespace CAB301Assignment {
    public class Movie: IComparable<Movie> {

        public string title;
        public string starring;
        public string director;
        public int duration;
        public Genre genre;
        public Classification classification;
        public int releaseDate;

        private int numBorrowed = 0;
        public int NumBorrowed {
            get { return numBorrowed;  }
        }
        private int numCopies = 0;
        public int NumCopies {
            get { return numCopies; }
        }

        public Movie(string title, string starring, string director, int duration, Genre genre, Classification classification, int releaseDate, int numCopies) 
        {
            this.title = Reusables.ToTitleCase(title);
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

        public bool IsAvailable {
            get { return numCopies > 0; }
        }

        public void Borrowed() {
            numBorrowed++;
            numCopies--;
        }

        public void Returned() {
            numCopies++;
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
