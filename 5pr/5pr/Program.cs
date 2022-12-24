using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5pr
{
    internal class Program
    {
        public class Node //класс вершины
        {
            private int id; // идентификатор смежной вершины
            private int weight; // вес ребра
            private Node link; // ссылка на соседний элемент списка вершин
            public int Id { get; set; } // свойства
            public int Weight { get; set; }
            public Node Link { get; set; }
            public Node() { } // конструкторы
            public Node(int id, int weight)
            {
                Id = id; Weight = weight;
            }
        }
        public class Graph
        {
            private int size; // количество вершин в графе
            private bool[,] adjacency; // матрица смежности графа
            private bool[] vector; // вектор посещенных вершин
            public int Size { get; set; }
            public bool[,] Adjacency { get; set; }
            public bool[] Vector { get; set; }
            public Graph(int size, bool[,] G) // конструктор класса «Графы»
            {
                Adjacency = new bool[size, size]; // инициализация матрицы смежности
                Adjacency = G;
                Vector = new bool[size];
                for (int i = 0; i < size; i++)
                    Vector[i] = false; // иниц-я вектора посещенных вершин
                Size = size;
            }
            public void Depth(int i) //i – вершина, с которой начинается обход
            {
                Vector[i] = true; // отметить вершину i как обработанную
                Console.Write("{0}" + ' ', i); // распечатать номер посещенной вершины
                for (int k = 0; k < Size; k++) // найти первую встретившуюся ранее непосещенную вершину k, смежную с вершиной i
            if (Adjacency[i, k] && !(Vector[k]))
                    Depth(k); // перейти к обработке вершины k
            }
        }
      
            static void Main(string[] args) {
            Console.WriteLine("Введите размер матрицы: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Matrix matrix = new Matrix(n);
            Console.WriteLine("Введите матрицу смежности: ");
            matrix.InputMatrix();

            Console.WriteLine("Матрица смежности: ");
            matrix.ReadMatrix();

            Matrix reachibilityMatrix = new Matrix(n);
            reachibilityMatrix = reachibilityMatrix.Reachability(matrix);

            Console.WriteLine("Матрица достижимости: ");
            reachibilityMatrix.ReadMatrix();

            Console.Write("Проверка на связность: ");
            Console.WriteLine(reachibilityMatrix.Connectedness(reachibilityMatrix));
            Console.ReadLine();
        }
        
        }
    }

