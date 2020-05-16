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

        public bool IsAvailable {
            get { return numCopies > 0; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">title of this movie</param>
        /// <param name="starring">starring of this movie</param>
        /// <param name="director">director of this movie</param>
        /// <param name="duration">duration of this movie</param>
        /// <param name="genre">gener of this movie</param>
        /// <param name="classification">classfication of this movie</param>
        /// <param name="releaseDate">release date of this movie</param>
        /// <param name="numCopies">number of copies available of this movie</param>
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

        /// <summary>
        /// Make copy of this movie for the member can hold movie object and it does not affect database's movie object
        /// </summary>
        /// <returns></returns>
        public Movie MakeCopy() {
            return new Movie(title, starring, director, duration, genre, classification, releaseDate, numCopies);
        }

        /// <summary>
        /// Call this when this movie is borrowed
        /// Check availability (i.e, IsAvailable) before calling this function 
        /// </summary>
        public void Borrowed() {
            if (IsAvailable) {
                numBorrowed++;
                numCopies--;
            }
        }

        /// <summary>
        /// Call this when this movie is returned
        /// </summary>
        public void Returned() {
            numCopies++;
        }

        /// <summary>
        /// Compare this movie with other movie by title
        /// </summary>
        /// <param name="other">other movie object to be compared</param>
        /// <returns>
        /// -1 if this movie should come before other movie
        /// 0 if this movie's title is same as other movie title
        /// 1 if this movie should come after other movie
        /// </returns>
        public int CompareTo( Movie other) {
            return string.Compare(this.title, other.title);
        }
    }
}
