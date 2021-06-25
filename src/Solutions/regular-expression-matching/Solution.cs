using System.Collections.Generic;

namespace Solutions.regular_expression_matching
{
    public class Solution
    {
        public bool IsMatch(string input, string pattern)
        {
            Node start = ParsePattern(pattern);

            return IsMatchRecursive(start, input, 0);
        }

        private bool IsMatchRecursive(Node node, string input, int index)
        {
            if (index == input.Length && node.IsEnd)
            {
                return true;
            }

            foreach (var edge in node.Edges)
            {
                char? c = index < input.Length ? input[index] : default(char?);

                if (!edge.Matches(c))
                    continue;

                bool matchFoundRecursively = IsMatchRecursive(edge.To, input, index + edge.Weight);
                if (matchFoundRecursively)
                    return true;
            }
            return false;
        }

        private Node ParsePattern(string pattern)
        {
            Node start = new Node();
            Node previous = start;

            for (int i = 0; i < pattern.Length; i++)
            {
                Node next = new Node();

                char c = pattern[i];

                bool zeroOrMore = i + 1 < pattern.Length && pattern[i + 1] == '*';
                if (zeroOrMore)
                {
                    i++;

                    previous.AddEdgeJump(next);
                    previous.AddEdge(previous, c);
                }
                else
                {
                    previous.AddEdge(next, c);
                }

                previous = next;
            }

            previous.IsEnd = true;

            return start;
        }

        class Node
        {
            private static int _idCounter = 0;
            private int _id = _idCounter++;

            public bool IsEnd { get; set; }
            public List<Edge> Edges { get; } = new List<Edge>();

            public void AddEdgeJump(Node to)
            {
                Edges.Add(new Edge(this, to, null));
            }

            public void AddEdge(Node to, char c)
            {
                Edges.Add(new Edge(this, to, c));
            }

            public override string ToString()
            {
                return _id.ToString();
            }
        }

        class Edge
        {
            public Edge(Node from, Node to, char? c)
            {
                From = from;
                To = to;
                C = c;
            }

            public Node From { get; }
            public Node To { get; }
            public char? C { get; }
            public int Weight => C.HasValue ? 1 : 0;

            internal bool Matches(char? c)
            {
                return !C.HasValue || C == c || (c.HasValue && C == '.');
            }

            public override string ToString()
            {
                if (C.HasValue)
                {
                    return $"'{C}' from {From} to {To}";
                }
                else
                {
                    return $"Skip from {From} to {To}";
                }
            }
        }
    }
}
