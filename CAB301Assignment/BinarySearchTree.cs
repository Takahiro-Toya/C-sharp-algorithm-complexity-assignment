using System;
namespace CAB301Assignment {

    public class Node {
        public Movie movie;
        public Node left;
        public Node right;

        public Node(Movie movie) {
            this.movie = movie;
        }
    }

    public class BinarySearchTree {

        public int Length {
            get { return CountNodes(root); }
        }

        private Node root;

        public void Add(Movie movie) {
            if (root==null) {
                root = new Node(movie);
                return;
            }

            Node pin = root;
            while (true) {
                if (movie.CompareTo(pin.movie) < 0) {
                    if (pin.left == null) {
                        pin.left = new Node(movie);
                        return;
                    }
                    pin = pin.left;
                } else if (pin.movie.CompareTo(movie) <= 0) {
                    if (pin.right == null) {
                        pin.right = new Node(movie);
                        return;
                    }
                    pin = pin.right;
                }
            }
        }

        public bool Contains(string title) {
            Node pin = root;
            while (pin != null) {
                if (CompareMovie(pin.movie.title, title) == 0) {
                    return true;
                } else if (CompareMovie(title, pin.movie.title) < 0) {
                    pin = pin.left;
                } else if (CompareMovie(pin.movie.title, title) < 0) {
                    pin = pin.right;
                }
            }
            return false;
        }


        public Movie GetMovie(string title) {
            Node pin = root;
            while (pin != null) {
                if (CompareMovie(pin.movie.title, title) == 0) {
                    return pin.movie;
                } else if (CompareMovie(title, pin.movie.title) < 0) {
                    pin = pin.left;
                } else if (CompareMovie(pin.movie.title, title) < 0) {
                    pin = pin.right;
                }
            }
            return null;
        }

        public void Remove(string title) {
            Node parent = null;
            Node pin = root;
            while (pin != null) {
                if (CompareMovie(pin.movie.title, title) == 0) {
                    if (pin.left == null && pin.right == null) {
                        if (pin == root) {
                            root = null;
                        } else {
                            UpdateNote(parent, pin, null);
                        }
                    } else if (pin.left != null && pin.right == null) {
                        if (pin == root) {
                            root = root.left;
                        } else {
                            UpdateNote(parent, pin, pin.left);
                        }
                    } else if (pin.left == null & pin.right != null) {
                        if (pin == root) {
                            root = root.right;
                        } else {
                            UpdateNote(parent, pin, pin.right);
                        }
                    } else {
                        Node minParent = pin;
                        Node min = pin.right;
                        while (min.left != null) {
                            minParent = min;
                            min = min.left;
                        }

                        if (minParent == pin) {
                            minParent.right = min.right;
                        } else {
                            minParent.left = min.right;
                        }

                        min.left = pin.left;
                        min.right = pin.right;
                        if (pin == root) {
                            root = min;
                        } else {
                            UpdateNote(parent, pin, min);
                        }
                    }
                    return;
                } else if (CompareMovie(title, pin.movie.title) < 0) {
                    parent = pin;
                    pin = pin.left;
                } else if (CompareMovie(pin.movie.title, title) < 0) { 
                    parent = pin;
                    pin = pin.right;
                }
            }
        }

        private void UpdateNote(Node parent, Node target, Node replace) {
            if (parent.left == target) {
                parent.left = replace;
            } else {
                parent.right = replace;
            }
        }

        private int CompareMovie(string title, string anotherTitle) {
            return string.Compare(title, anotherTitle);
        }

        private int CountNodes(Node entry) {
            if (entry == null) {
                return 0;
            } else {
                Node pin = entry;
                return 1 + CountNodes(pin.left) + CountNodes(pin.right);
            }
        }

        /// <summary>
        /// Return all movies in alphabetical order of title
        /// </summary>
        /// <returns>sorted movies</returns>
        public Movie[] GetAllNodes() {

            Movie[] sorted = new Movie[Length];
            int count = 0;
            InOrderTraversal(root);

            void InOrderTraversal(Node node) {
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


        public Movie[] GetTopTenList() {
            Movie[] array = GetAllNodes();
            Movie[] sorted = new Movie[array.Length];
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

        public string Top10Text() {
            string text = "";
            foreach (Movie m in GetTopTenList()) {
                text += m.title + "-" + m.NumBorrowed;
                text += ", ";
            }
            return text;
        }

        //static void Main(string[] args) {

        //    BinarySearchTree tree = new BinarySearchTree();

        //    Movie[] data = {
        //        new Movie("ghk", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("fkk", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("kqk", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("opq", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("ack", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("ghj", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("fkj", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("kqj", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("opp", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
        //        new Movie("acj", "1", "11", "111", Genre.Action, Classification.General, "1111", 10)
        //    };

        //    data[0].Borrowed();
        //    data[0].Borrowed();
        //    data[0].Borrowed();
        //    data[0].Borrowed(); //ghk -4
        //    data[1].Borrowed(); 
        //    data[1].Borrowed(); //fkk -2
        //    data[2].Borrowed(); //kqk - 1
        //    data[3].Borrowed(); //opq - 1
        //    data[5].Borrowed(); //ghj - 1 

        //    for (int i = 0; i < data.Length; i++) {
        //        tree.Add(data[i]);
        //    }

        //    Console.WriteLine(tree.GetAllMovieTitle());
        //    Console.WriteLine(tree.Top10Text());
        //}
    }
}
