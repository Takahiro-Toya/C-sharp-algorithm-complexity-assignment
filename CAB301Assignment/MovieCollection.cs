using System;
namespace CAB301Assignment {
    public class MovieCollection {


        private MovieNode root = null;

        /// <summary>
        /// number of nodes in this tree
        /// </summary>
        public int Count {
            get { return CountNodes(root); }
        }

        /// <summary>
        /// Add new movie to the tree
        /// </summary>
        /// <param name="movie">Movie object</param>
        /// <returns>True if movie is added, False if movie already exists in the collection</returns>
        public bool Add(Movie movie) {
            if (root == null) {
                root = new MovieNode(movie);
                return true;
            }

            MovieNode pin = root;
            while (true) {
                // the title comes before the compared title
                if (movie.CompareTo(pin.movie) < 0) {
                    if (pin.left == null) {
                        pin.left = new MovieNode(movie);
                        return true;
                    }
                    pin = pin.left;
                // the title comes after the compared title
                } else if (pin.movie.CompareTo(movie) < 0) {
                    if (pin.right == null) {
                        pin.right = new MovieNode(movie);
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
        /// Count the number of all nodes in tree, given entry node as root 
        /// </summary>
        /// <param name="entry">
        /// the top node of the tree that you want to count the number
        /// set root node if you want to count the number of all nodes in entire tree
        /// </param>
        /// <returns>the number of nodes</returns>
        private int CountNodes(MovieNode entry) {
            if (entry == null) {
                return 0;
            } else {
                MovieNode pin = entry;
                return 1 + CountNodes(pin.left) + CountNodes(pin.right);
            }
        }

        /// <summary>
        /// Return all movies in alphabetical order of title using in-order traversal
        /// </summary>
        /// <returns>sorted movies</returns>
        public Movie[] GetAllMovies() {

            Movie[] sorted = new Movie[Count];
            int count = 0;
            InOrderTraversal(root);

            // perform in-order traersal
            void InOrderTraversal(MovieNode node) {
                if (node == null) {
                    return;
                } else {
                    InOrderTraversal(node.left);
                    sorted[count] = node.movie;
                    count++;
                    InOrderTraversal(node.right);
                }
            }

            return sorted;
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
        private Movie[] GetSortedAccordingToBorrowingTimes() {
            Movie[] array = GetAllMovies();
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


        /// <summary>
        /// Retrieve only top ten movies from sorted array
        /// </summary>
        /// <returns>top 10 Ranking object as Ranking[10]</returns>
        public Ranking[] GetTopTenMovies() {
            Movie[] sorted = GetSortedAccordingToBorrowingTimes();
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
            if (sorted.Length == 0) {
                return topten;
            }

            int rank = 0; // from rank 1 to rank 10 (0 ~ 9 for array reference)
            //int index = 1; // array index in 'sorted'
            topten[0].Add(sorted[0]);
            for(int i = 1; i < sorted.Length; i++) {
                if (rank >= 10) { break; }
                if (sorted[i - 1].NumBorrowed == sorted[i].NumBorrowed) {
                    topten[rank].Add(sorted[i]);
                } else {
                    if (rank < 9) {
                        rank++;
                        topten[rank].Add(sorted[i]);
                    }
                }
            }
            return topten;
        }
    }
}
