using System;
using System.Collections.Generic;
using System.Linq;

namespace StarPeace.Admin.Algorithms
{
    /// <summary>
    /// A recursive traversal in depth in an undirected graph.
    /// </summary>
    public class  UndirectedGraphUndirected
    {
        // static void UndirectedGraphUndirectedMain()
        // {
        //     GraphUndirected g = new GraphUndirected(ReadGraphUndirected());

        //     bool[] visited = new bool[GraphUndirected.MaxNode];
        //     g.TraverseDFSRecursive(0, visited);

        //     PrintResult(g.DFSPath);
        //     Console.ReadLine();
        // }

        // static List<int>[] ReadGraphUndirected()
        // {
        //     // Read number of nodes N
        //     Console.WriteLine("Please enter graph limit");
        //     string input = Console.ReadLine();
        //     int N = int.Parse(input);

        //     // Read graph as adjacency list
        //     List<int>[] graph = new List<int>[N];

        //     for (int i = 0; i < N; i++)
        //     {
        //         graph[i] = new List<int>();
        //         Console.WriteLine("Please enter graph value");
        //         input = Console.ReadLine();
        //         string[] childs = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //         foreach (var child in childs)
        //         {
        //             graph[i].Add(int.Parse(child));
        //         }
        //     }

        //     return graph;
        // }

        // static void PrintResult(List<int> path)
        // {
        //     // Print result path in format {start node1 node2 ... end}
        //     StringBuilder builder = new StringBuilder(path.Count * 2);

        //     for (int i = 0; i < path.Count; i++)
        //     {
        //         if (i < path.Count - 1)
        //         {
        //             builder.Append(String.Format("{0} ", path[i]));
        //         }
        //         else
        //         {
        //             builder.Append(path[i]);
        //         }
        //     }

        //     Console.WriteLine(builder);
        // }
    }
    public class GraphUndirected
    {
        // internal const int MaxNode = 1024;
        // private List<int>[] childNodes;
        // private List<int> dfsPath;

        // public GraphUndirected(List<int>[] childNodes)
        // {
        //     this.childNodes = childNodes;
        //     this.dfsPath = new List<int>();
        // }

        // public List<int> DFSPath
        // {
        //     get
        //     {
        //         return dfsPath;
        //     }
        // }

        // public void TraverseDFSRecursive(int node, bool[] visited)
        // {
        //     if (!visited[node])
        //     {
        //         visited[node] = true;
        //         dfsPath.Add(node);
        //         foreach (int childNode in childNodes[node])
        //         {
        //             TraverseDFSRecursive(childNode, visited);
        //         }
        //     }
        // }
    


        // private List<int>[] childNodes_;
        // private bool[] visited;

        // private List<int> currentPath;
        // private List<List<int>> foundCycles;

        // public Int32 NodesCount
        // {
        //     get
        //     {
        //         return this.childNodes_.Length;
        //     }
        // }

        // public List<int>[] Childs
        // {
        //     get
        //     {
        //         return this.childNodes_;
        //     }
        // }

        // public GraphUndirected(List<int>[] nodes)
        // {
        //     this.childNodes_ = nodes;
        //     this.visited = new bool[childNodes_.GetLength(0)];
        //     this.currentPath = new List<int>();
        //     this.foundCycles = new List<List<int>>();

        // }

        // private bool FindAllCycles(int startNode)
        // {
        //     if (visited[startNode])
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         visited[startNode] = true;

        //         foreach (int node in childNodes[startNode])
        //         {
        //             currentPath.Add(node);
        //             if (FindAllCycles(node))
        //             {
        //                 return true;
        //             }
        //             currentPath.RemoveAt(currentPath.Count - 1);
        //         }

        //         visited[startNode] = false;
        //     }
        //     return false;
        // }

        // public bool PrintAllCycles()
        // {
        //     for (int node = 0; node < childNodes_.GetLength(0); node++)
        //     {
        //         currentPath.Add(node);
        //         if (FindAllCycles(node))
        //         {
        //             return true;
        //         }
        //         currentPath.RemoveAt(currentPath.Count - 1);
        //     }

        //     return false;
        // }
    }
}


