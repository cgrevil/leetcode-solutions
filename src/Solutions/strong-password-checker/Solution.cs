using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.strong_password_checker
{
    /// <summary>
    /// https://leetcode.com/problems/strong-password-checker/
    /// </summary>
    public class Solution
    {
        public int StrongPasswordChecker(string password)
        {
            int missingTypes = CountMissingTypes(password);

            // Too short password edge cases. Can always be fixed by adding characters.
            // Password can contain at most one repeat-sequence of length 3 or more, and it can always be broken by adding one of each missing type.
            // Add char for each missing type.
            // If password length is still not 6, add more chars as needed.
            if (password.Length < 6)
            {
                return Math.Max(missingTypes, 6 - password.Length);
            }

            int steps = 0;

            List<int> repeats = GetRepeatSequenceLengths(password);

            if (password.Length > 20)
            {
                int removals = password.Length - 20;

                steps += removals;
                repeats = GetBestCaseRepeatSequencesAfterRemovals(repeats, removals);
            }

            int replacementsNeededToFixRepeatSequences = repeats
                .Sum(l => l / 3);

            steps += Math.Max(missingTypes, replacementsNeededToFixRepeatSequences);

            return steps;
        }

        /// <summary>
        /// Too long passwords, can be reduced to length of 20 using removals.
        /// Missing types and remaining repeat-sequences can then be fixed by using replacements.
        /// A single replacement can decrease any of the repeats by 3, e.g. "aaaaaaaaaa" (10) -> "aa1aaaaaaa" (7).
        /// A repeated sequence of length X can be fixed, using only replacements, in X / 3 steps (integer division).
        /// This favors using replacements on those where X % 3 == 2.
        /// Therefore, we'll use each of the required removals to decrease the length of a repeat sequence by 1, prioritizing removing from a sequence by ascending size of X % 3.
        /// This will allow optimal fixing of repeat sequences using replacements afterwards.
        /// </summary>
        private List<int> GetBestCaseRepeatSequencesAfterRemovals(List<int> repeats, int removals)
        {
            List<int> repeatsMod0 = repeats.Where(l => l % 3 == 0).ToList();
            List<int> repeatsMod1 = repeats.Where(l => l % 3 == 1).ToList();
            List<int> repeatsMod2 = repeats.Where(l => l % 3 == 2).ToList();

            for (int i = 0; i < removals; i++)
            {
                if (repeatsMod0.Count > 0)
                {
                    int repeatLength = repeatsMod0.First();

                    repeatsMod0.Remove(repeatLength);

                    if (repeatLength != 3)
                    {
                        repeatsMod2.Add(repeatLength - 1);
                    }
                }
                else if (repeatsMod1.Count > 0)
                {
                    int repeatLength = repeatsMod1.First();

                    repeatsMod1.Remove(repeatLength);
                    repeatsMod0.Add(repeatLength - 1);
                }
                else if (repeatsMod2.Count > 0)
                {
                    int repeatLength = repeatsMod2.First();

                    repeatsMod2.Remove(repeatLength);
                    repeatsMod1.Add(repeatLength - 1);
                }
                else
                {
                    return new List<int>();
                }
            }

            var result = new List<int>();
            result.AddRange(repeatsMod0);
            result.AddRange(repeatsMod1);
            result.AddRange(repeatsMod2);

            return result;
        }

        /// <summary>
        /// Gets length of each repeated sequence of chars in password, where length is at least 3
        /// </summary>
        private List<int> GetRepeatSequenceLengths(string password)
        {
            var result = new List<int>();

            char? last = null;
            int length = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];

                if (c == last)
                {
                    length++;
                }
                else
                {
                    if (length >= 3)
                    {
                        result.Add(length);
                    }

                    last = c;
                    length = 1;
                }
            }

            if (length >= 3)
            {
                result.Add(length);
            }

            return result;
        }

        /// <summary>
        /// Counts the number (0-3) of types (digit/lowercase/uppercase) missing in password.
        /// </summary>
        private int CountMissingTypes(string password)
        {
            int result = 3;

            if (password.Any(c => char.IsDigit(c)))
                result--;

            if (password.Any(c => char.IsLower(c)))
                result--;

            if (password.Any(c => char.IsUpper(c)))
                result--;

            return result;
        }
    }
}
