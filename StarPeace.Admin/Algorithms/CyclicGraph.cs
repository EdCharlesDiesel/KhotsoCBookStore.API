using System;
using System.Collections.Generic;
using System.Linq;

namespace StarPeace.Admin.Algorithms
{
    // /// <summary> 
    // /// Checks the graph is cyclic.
    // /// </summary>
    // public class CyclicGraph
    // {
    //   public static void Main()
    //     {
    //         Graph g = new Graph(ReadGraph());
    //         var allCycles = g.PrintAllCycles();
    //         Console.WriteLine("All Cycles {0}", allCycles);
            
    //         Console.ReadLine();
    //     }

    //     static List<int>[] ReadGraph()
    //     {
    //         // Read number of nodes N
    //         Console.WriteLine("Please enter graph limit");
    //         string input = Console.ReadLine();
    //         int N = int.Parse(input);

    //         // Read graph as adjacency list
    //         List<int>[] graph = new List<int>[N];

    //         for (int i = 0; i < N; i++)
    //         {
    //             graph[i] = new List<int>();
    //             Console.WriteLine("Please enter graph value");
    //             input = Console.ReadLine();
    //             string[] childs = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

    //             foreach (var child in childs)
    //             {
    //                 graph[i].Add(int.Parse(child));
    //             }
    //         }

    //         return graph;
    //     }
    // }
    // public class Graph
    // {
    //     private List<int>[] childNodes;
    //     private bool[] visited;

    //     private List<int> currentPath;
    //     private List<List<int>> foundCycles;

    //     public Int32 NodesCount
    //     {
    //         get
    //         {
    //             return this.childNodes.Length;
    //         }
    //     }

    //     public List<int>[] Childs
    //     {
    //         get
    //         {
    //             return this.childNodes;
    //         }
    //     }

    //     public Graph(List<int>[] nodes)
    //     {
    //         this.childNodes = nodes;
    //         this.visited = new bool[childNodes.GetLength(0)];
    //         this.currentPath = new List<int>();
    //         this.foundCycles = new List<List<int>>();

    //     }

    //     private bool FindAllCycles(int startNode)
    //     {
    //         if (visited[startNode])
    //         {
    //             return true;
    //         }
    //         else
    //         {
    //             visited[startNode] = true;

    //             foreach (int node in childNodes[startNode])
    //             {
    //                 currentPath.Add(node);
    //                 if (FindAllCycles(node))
    //                 {
    //                     return true;
    //                 }
    //                 currentPath.RemoveAt(currentPath.Count - 1);
    //             }

    //             visited[startNode] = false;
    //         }
    //         return false;
    //     }

    //     public bool PrintAllCycles()
    //     {
    //         for (int node = 0; node < childNodes.GetLength(0); node++)
    //         {
    //             currentPath.Add(node);
    //             if (FindAllCycles(node))
    //             {
    //                 return true;
    //             }
    //             currentPath.RemoveAt(currentPath.Count - 1);
    //         }

    //         return false;
    //     }
    // }
}

