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
        private Node root;

        public void add(Movie movie) {
            if (root==null) {
                root = new Node(movie);
                return;
            }

            Node current = root;
            while (true) {
                if (movie.CompareTo(current.movie) < 0) {
                    if (current.left == null) {
                        current.left = new Node(movie);
                        return;
                    }
                    current = current.left;
                } else if (current.movie.CompareTo(movie) <= 0) {
                    if (current.right == null) {
                        current.right = new Node(movie);
                        return;
                    }
                    current = current.right;
                }
            }
        }

        public bool contains(string title) {
            Node current = root;
            while (current != null) {
                //if (compareMovie(current.movie.title, title) == 0) {
                //    return true;
                //} else if (compareMovie(title, current.movie.title) < 0) {
                //    current = current.left;
                //} else if (compareMovie(current.movie.title, title) < 0) {
                //    current = current.right;
                //}
                if (current.movie.CompareTo(movie) == 0) {
                    return true;
                } else if (movie.CompareTo(current.movie) < 0) {
                    current = current.left;
                } else if (current.movie.CompareTo(movie) < 0) {
                    current = current.right;
                }
            }
            return false;
        }

        public void Remove(Movie movie) {
            Node parent = null;
            Node current = root;
            while (current != null) {
                if (current.movie.CompareTo(movie) == 0) {
                    if (current.left == null && current.right == null) {
                        if (current == root) {
                            root = null;
                        } else {
                            UpdateLink(parent, current, null);
                        }
                    } else if (current.left != null && current.right == null) {
                        if (current == root) {
                            root = root.left;
                        } else {
                            UpdateLink(parent, current, current.left);
                        }
                    } else if (current.left == null & current.right != null) {
                        if (current == root) {
                            root = root.right;
                        } else {
                            UpdateLink(parent, current, current.right);
                        }
                    } else {
                        Node minParent = current;
                        Node min = current.right;
                        while (min.left!= null) {
                            minParent = min;
                            min = min.left;
                        }

                        if(minParent == current) {
                            minParent.right = min.right;
                        } else {
                            minParent.left = min.right;
                        }

                        min.left = current.left;
                        min.right = current.right;
                        if (current == root) {
                            root = min;
                        } else {
                            UpdateLink(parent, current, min);
                        }
                    }
                    return;
                } else if(movie.CompareTo(current.movie) < 0) {
                    parent = current;
                    current = current.left;
                } else if (current.movie.CompareTo(movie) < 0) {
                    parent = current;
                    current = current.right;
                }
            }
        }

        private void UpdateLink(Node parent, Node target, Node replace) {
            if (parent.left == target) {
                parent.left = replace;
            } else {
                parent.right = replace;
            }
        }

        private int compareMovie(string title, string anotherTitle) {
            return string.Compare(title, anotherTitle);
        }

        static void Main(string[] args) {

            BinarySearchTree tree = new BinarySearchTree();

            Movie[] data = {
                new Movie("GHK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
                new Movie("FKK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
                new Movie("KQK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
                new Movie("OPK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10),
                new Movie("ACK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10)
            };

            for (int i = 0; i < data.Length; i++) {
                tree.add(data[i]);
            }

            Console.WriteLine(tree.contains(new Movie("GHK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10)));
            Console.WriteLine(tree.contains(new Movie("FUK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10)));
            Console.WriteLine(tree.contains(new Movie("AKK", "1", "11", "111", Genre.Action, Classification.General, "1111", 10)));

        }
    }
}
