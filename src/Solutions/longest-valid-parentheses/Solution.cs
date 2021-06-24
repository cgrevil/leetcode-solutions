using System;
using System.Collections.Generic;

namespace Solutions.longest_valid_parentheses
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            bool[] charValidations = new bool[s.Length];
            Stack<int> openLefts = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    openLefts.Push(i);
                }
                else if (c == ')')
                {
                    if (openLefts.Count == 0)
                    {
                        continue;
                    }

                    int left = openLefts.Pop();
                    charValidations[left] = true;
                    charValidations[i] = true;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            int longest = 0;
            int current = 0;
            foreach (bool charIsValid in charValidations)
            {
                if (charIsValid)
                {
                    current++;
                }
                else
                {
                    longest = Math.Max(longest, current);
                    current = 0;
                }
            }

            return Math.Max(longest, current);
        }
    }
}
