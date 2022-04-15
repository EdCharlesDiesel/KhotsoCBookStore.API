using System;
using System.Collections.Generic;
using System.Linq;

namespace StarPeace.Admin.Algorithms
{
    /// <summary>
    /// Breadth first search (BFS), based on a queue, to traverse a directed graph.
    /// </summary>
    public class  QueueBasedBFS
    {
        public   static void QueueBasedBFSMain()
        {
        
            GraphQueueBasedBFS g = new GraphQueueBasedBFS(ReadGraphQueueBasedBFS());

            g.TraverseBFS(0);

            PrintResult(g.BFSPath);
            Console.ReadLine();
        }

        static List<int>[] ReadGraphQueueBasedBFS()
        {
            // Read number of nodes N
            Console.WriteLine("Please enter number of nodes");
            string input = Console.ReadLine();
            int N = int.Parse(input);

            // Read graph as adjacency list
            List<int>[] graph = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
                Console.WriteLine("Please enter a leaf node");
                input = Console.ReadLine();
                string[] childs = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var child in childs)
                {
                    graph[i].Add(int.Parse(child));
                }
            }

            return graph;
        }

        static void PrintResult(List<int> path)
        {
            // Print result path in format {start node1 node2 ... end}
            StringBuilder builder = new StringBuilder(path.Count * 2);

            for (int i = 0; i < path.Count; i++)
            {
                if (i < path.Count - 1)
                {
                    builder.Append(String.Format("{0} ", path[i]));
                }
                else
                {
                    builder.Append(path[i]);
                }
            }

            Console.WriteLine(builder);
        }
    }
    public class GraphQueueBasedBFS
    {
        internal const int MaxNode = 1024;
        private List<int>[] childNodes;
        private List<int> bfsPath;

        public GraphQueueBasedBFS(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
            this.bfsPath = new List<int>();
        }

        public List<int> BFSPath
        {
            get
            {
                return bfsPath;
            }
        }

        public void TraverseBFS(int node)
        {
            bool[] visited = new bool[MaxNode];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                bfsPath.Add(currentNode);
                foreach (int childNode in childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }
    }
}