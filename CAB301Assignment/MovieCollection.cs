using System;
namespace CAB301Assignment {
    public class MovieCollection {

        /// <summary>
        /// This must be binary search tree
        /// </summary>
        private BinarySearchTree movieTree = new BinarySearchTree();


        public MovieCollection() {
        }

        public bool AddMovie(Movie movie) {
            if (movieTree.Contains(movie.title)) {
                return false;
            } else {
                movieTree.Add(movie);
                return true;
            }
           
        }

        public void RemoveMovie(string title) {
            movieTree.Remove(title);
        }

        public bool ReturnMovie(Movie movie) {
            Movie found = movieTree.GetMovie(movie.title);
            if (found != null) {
                found.Returned();
            }
            return true;
        }

        public Movie GetMovie(string title) {
            return movieTree.GetMovie(title);
        }

        public Movie[] GetAllMovies() {
            return movieTree.GetAllNodes();
        }

        private Movie[] GetBorrowingRankingSortedMovies() {
            Movie[] array = movieTree.GetAllNodes();
            void QuickSort(Movie[] movies, int left, int right) {

                if (left >= right) { return; }

                Movie pivot = movies[left];
                int l = left;
                int r = right;

                while (true) {
                    while (movies[l].NumBorrowed > pivot.NumBorrowed) {
                        l++;
                    }
                    while (movies[r].NumBorrowed < pivot.NumBorrowed) {
                        r--;
                    }
                    if (l >= r) {
                        break;
                    }
                    Movie temp = movies[l];
                    movies[l] = movies[r];
                    movies[r] = temp;
                    l++;
                    r--;
                }

                QuickSort(movies, left, l - 1);
                QuickSort(movies, r + 1, right);
            }
            QuickSort(array, 0, array.Length - 1);
            return array;
        }

        public Ranking[] GetTopTenMovies() {
            Movie[] sorted = GetBorrowingRankingSortedMovies();

            if (sorted.Length == 0) { return null;  }
            Ranking[] topten = new Ranking[] {
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking(),
                new Ranking()
            };
            int index = 0;
            // loop to create top 10 rank
            for (int i = 0; i < 10; i++) {
                if (index > sorted.Length - 1) { // there is no element for current rank order
                    topten[i] = new Ranking(); // empty rank
                    continue; // skip
                } else {  // add the first element of the rank
                    topten[i].Add(sorted[index]);
                    index++;
                    while (true) {
                        if(index > sorted.Length - 1) {
                            break;
                        }
                        // if number of borrowed is equal to the number of borrowed of the previous element
                        if (sorted[index - 1].NumBorrowed == sorted[index].NumBorrowed) {
                            topten[i].Add(sorted[index]);
                            index++;
                        } else {
                            break;
                        }
                    }
                    continue;
                }
            }

            // retrieve top 10 (order in 1st - 10th)

            return topten;
        }
    }
}
