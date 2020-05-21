using System;
namespace CAB301Assignment {
    public class MovieCollection {


        private MovieNode root = null;

        private int count = 0;
        /// <summary>
        /// number of nodes in this tree
        /// </summary>
        public int Count {
            get { return count; }
        }

        /// <summary>
        /// Add new movie to the tree
        /// </summary>
        /// <param name="movie">Movie object</param>
        /// <returns>True if movie is added, False if movie already exists in the collection</returns>
        public bool Add(Movie movie) {
            if (root == null) {
                root = new MovieNode(movie);
                count++;
                return true;
            }

            MovieNode pin = root;
            while (true) {
                // the title comes before the compared title
                if (movie.CompareTo(pin.movie) < 0) {
                    if (pin.left == null) {
                        pin.left = new MovieNode(movie);
                        count++;
                        return true;
                    }
                    pin = pin.left;
                // the title comes after the compared title
                } else if (pin.movie.CompareTo(movie) < 0) {
                    if (pin.right == null) {
                        pin.right = new MovieNode(movie);
                        count++;
                        return true;
                    }
                    pin = pin.right;
                // the title is same as the compared title (pin.movie.CompareTo(movie) == 0)
                // the movie should not be added to the tree
                } else {
                    return false;
                }
            }
        }


        /// <summary>
        /// Get Movie object of title
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>Movie object</returns>
        public Movie GetMovie(string title) {
            MovieNode pin = root;
            while (pin != null) {
                // found a movie
                if (CompareMovie(pin.movie.title, title) == 0) {
                    return pin.movie;
                // the movie should be on the left side of current pin
                } else if (CompareMovie(title, pin.movie.title) < 0) {
                    pin = pin.left;
                // the movie should be on the right side of current pin
                } else if (CompareMovie(pin.movie.title, title) < 0) {
                    pin = pin.right;
                }
            }
            return null;
        }

        /// <summary>
        /// Remove movie objct of title from tree
        /// </summary>
        /// <param name="title">Movie title that is to be deleted</param>
        public void Remove(string title) {
            MovieNode parent = null;
            MovieNode pin = root;
            while (pin != null) {
                // found a target movie
                if (CompareMovie(pin.movie.title, title) == 0) {
                    // no children
                    if (pin.left == null && pin.right == null) {
                        // current pin is root, so just empty the tree
                        if (pin == root) {
                            root = null;
                        } else {
                            // pin to be null, parent's left or right to be null
                            UpdateMovieNode(parent, pin, null);
                        }
                    // has a child on the left hand side of current node (pin)
                    } else if (pin.left != null && pin.right == null) {
                        if (pin == root) {
                            // root will be the node of the left hand side of current root
                            root = root.left;
                        } else {
                            // move pin's left to pin's position
                            UpdateMovieNode(parent, pin, pin.left);
                        }
                    // has a child on the right hand side of current node (pin)
                    } else if (pin.left == null & pin.right != null) {
                        if (pin == root) {
                            root = root.right;
                        } else {
                            // move pin's right to pin's position
                            UpdateMovieNode(parent, pin, pin.right);
                        }
                        // has children on both side of current node (pin)
                    } else {
                        
                        MovieNode scopeParent = pin;
                        MovieNode scopePin = pin.left;

                        // find right-most node in left subtree
                        while (scopePin.right != null) {
                            scopeParent = scopePin;
                            scopePin = scopePin.right;
                        }
                        // no right subtree in pin's left subtree
                        // shift node up
                        if (scopeParent == pin) {
                            pin.movie = scopePin.movie;
                            pin.left = scopePin.left;
                        // let scope parent to take over scope pin's left
                        // scope pin move to pin's (to be deleted) poistion
                        } else {
                            scopeParent.right = scopePin.left;
                            pin.movie = scopePin.movie;
                        }
                    }
                    count--;
                    return;
                // title is on the left side of the pin
                } else if (CompareMovie(title, pin.movie.title) < 0) {
                    parent = pin;
                    pin = pin.left;
                // title is on the right side of the pin
                } else if (CompareMovie(pin.movie.title, title) < 0) {
                    parent = pin;
                    pin = pin.right;
                }
            }
        }

        /// <summary>
        /// Move node position after deleting
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="target"></param>
        /// <param name="replace"></param>
        private void UpdateMovieNode(MovieNode parent, MovieNode target, MovieNode replace) {
            if (parent.left == target) {
                parent.left = replace;
            } else {
                parent.right = replace;
            }
        }

        /// <summary>
        /// Compare movie title
        /// </summary>
        /// <param name="title">movei title</param>
        /// <param name="anotherTitle">another movie title</param>
        /// <returns>
        /// -1 if first argument comes before second
        /// 0 if both argumets are same
        /// 1 if first argument comes after second
        /// </returns>
        private int CompareMovie(string title, string anotherTitle) {
            return string.Compare(title, anotherTitle);
        }

        /// <summary>
        /// Return all movies in alphabetical order of title using in-order traversal
        /// </summary>
        /// <returns>sorted movies</returns>
        public Movie[] GetAlphabetical() {

            Movie[] alphabetic = new Movie[Count];
            int inorderCounter = 0;
            InOrderTraversal(root);
            /// <summary>
            /// In order traversal (visit from left to right)
            /// </summary>
            void InOrderTraversal(MovieNode node) {
                if (node == null) {
                    return;
                } else {
                    InOrderTraversal(node.left);
                    alphabetic[inorderCounter] = node.movie;
                    inorderCounter++;
                    InOrderTraversal(node.right);
                }
            }
            return alphabetic;
        }

        /// <summary>
        /// Call this function when the member returns movie
        /// The function evaluates the given movie title, and search by this title name,
        /// and increment the number of available copies of the movie in movie collection
        /// </summary>
        /// <param name="movie">the movie to be returned</param>
        /// <returns>It always returns true</returns>
        public bool ReturnMovie(Movie movie) {
            Movie found = GetMovie(movie.title);
            // movie might have been deleted, but it doesn't matter, just drop it.
            if (found != null) {
                found.Returned();
            }
            return true;
        }

        /// <summary>
        /// Sort movies according to number of borrow times
        /// Quick sort is performed 
        /// </summary>
        /// <returns>sorted movie array</returns>
        private Movie[] GetSortedAccordingToBorrowedTimes() {
            Movie[] sorted = GetAlphabetical(); // traversal method does not matter (time complexity ... same)
            QuickSort(sorted, 0, sorted.Length - 1);

            /// <summary>
            /// Quick sort to sort movies in order of number of borrow times
            /// This method contains partition part 
            /// </summary>
            void QuickSort(Movie[] movies, int left, int right) {

                if (left >= right) { return; }
                // for simplicity determine pivot from leftmost element of movies array
                Movie pivot = movies[left];
                // markers
                int l = left;
                int r = right;

                while (true) {
                    // move left marker 
                    while (movies[l].NumBorrowed > pivot.NumBorrowed) {
                        l++;
                    }
                    // move right marker 
                    while (movies[r].NumBorrowed < pivot.NumBorrowed) {
                        r--;
                    }
                    // left reaches right
                    if (l >= r) {
                        break;
                    }
                    // swap left and right
                    Movie temp = movies[l];
                    movies[l] = movies[r];
                    movies[r] = temp;
                    l++;
                    r--;
                }
                // patition
                QuickSort(movies, left, l - 1);
                QuickSort(movies, r + 1, right);
            }

            return sorted;
        }


        /// <summary>
        /// Retrieve only top ten movies from sorted array
        /// </summary>
        /// <returns>top 10 Ranking object as Ranking[10]</returns>
        public Ranking[] GetTopTenMovies() {
            Movie[] sorted = GetSortedAccordingToBorrowedTimes();
            Ranking[] topten = new Ranking[10];
            for (int i=0; i<10; i++) {
                topten[i] = new Ranking();
            }
            if (sorted.Length == 0) {
                return topten;
            }

            int rank = 0; // from rank 1 to rank 10 (0 ~ 9 for array reference)
            topten[0].Add(sorted[0]);
            for (int i = 1; i < sorted.Length; i++) {
                if (rank >= 10) { break; }
                if (sorted[i - 1].NumBorrowed == sorted[i].NumBorrowed) {
                    topten[rank].Add(sorted[i]);
                } else {
                    // there is rank 10 space available, so increment
                    if (rank < 9) {
                        rank++;
                        topten[rank].Add(sorted[i]);
                        // there is no more rank space available, so break;
                    } else {
                        break;
                    }
                }
            }
            return topten;
        }
    }
}
