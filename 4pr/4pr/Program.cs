using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4pr
{
    internal class Program
    {
        public class TreeNode
        {
            public int Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode()
            {

            }
            public TreeNode(int data)
            {
                this.Data = data;
            }
        }
        public class BinaryTree
        {
            private TreeNode _root;
            public BinaryTree()
            {
                _root = null;
            }
            public void Insert(int data)
            {
                if (_root == null)
                {
                    _root = new TreeNode(data);
                    return;
                }
                Record(_root, new TreeNode(data));
            }
            private void Record(TreeNode root, TreeNode newNode)
            {

                if (root == null)
                    root = newNode;

                if (newNode.Data < root.Data)
                {
                    if (root.Left == null)
                        root.Left = newNode;
                    else
                        Record(root.Left, newNode);

                }
                else
                {
                    if (root.Right == null)
                        root.Right = newNode;
                    else
                        Record(root.Right, newNode);
                }
            }
            private void Display(TreeNode root)
            {
                if (root == null) return;

                Display(root.Left);
                Console.Write(root.Data + " ");
                Display(root.Right);
            }
            public void Display()
            {
                Display(_root);
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Количество полей: ");
            BinaryTree tree = new BinaryTree();
            TreeNode root = new TreeNode();
            int countInfField = int.Parse(Console.ReadLine());
            for (int i = 0; i < countInfField; i++)
            {
                tree.Insert(random.Next(10, 1000));

            }
            tree.Display();
            Console.ReadKey();
        }
    }
}
    

