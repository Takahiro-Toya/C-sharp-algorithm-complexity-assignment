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
                if (compareMovie(current.movie.title, title) == 0) {
                    return true;
                } else if (compareMovie(title, current.movie.title) < 0) {
                    current = current.left;
                } else if (compareMovie(current.movie.title, title) < 0) {
                    current = current.right;
                }
            }
            return false;
        }

        public void Remove(string title) {
            Node parent = null;
            Node current = root;
            while (current != null) {
                if (compareMovie(current.movie.title, title) == 0) {
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
                        while (min.left != null) {
                            minParent = min;
                            min = min.left;
                        }

                        if (minParent == current) {
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
                } else if (compareMovie(title, current.movie.title) < 0) {
                    parent = current;
                    current = current.left;
                } else if (compareMovie(current.movie.title, title) < 0) { 
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

            Console.WriteLine(tree.contains("GHK")); // true
            Console.WriteLine(tree.contains("FKK")); // true
            Console.WriteLine(tree.contains("KQK")); // true
            Console.WriteLine(tree.contains("ADK")); // false
            tree.Remove("GHK");
            tree.Remove("FKK");
            Console.WriteLine(tree.contains("GHK")); // false
            Console.WriteLine(tree.contains("FKK")); // false
            Console.WriteLine(tree.contains("OPK")); // true
            Console.WriteLine(tree.contains("KQK")); // true

        }
    }
}
