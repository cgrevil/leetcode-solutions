using System;

namespace Solutions.longest_valid_parentheses
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            int longest = 0;

            int currentLength = 0;
            int currentDepth = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    currentDepth++;
                }
                else if (c == ')')
                {
                    if (currentDepth == 0)
                    {
                        currentLength = 0;
                        continue;
                    }

                    currentDepth--;
                    currentLength += 2;
                    longest = Math.Max(longest, currentLength);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return longest;
        }
    }
}
