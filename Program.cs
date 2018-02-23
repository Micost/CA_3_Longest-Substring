using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_3_Longest_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abcdaace";
            Solution s1 = new Solution();
            Console.WriteLine(input[2]);
            Console.WriteLine(s1.LengthOfLongestSubstring(input));
            var a = Console.ReadLine();
        }
    }
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int length_pre = 0;
            int length_cur = 0;
            int start_point = 0;
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            for (int i=0; i<s.Length; i++)
            {
                if (!dictionary.ContainsKey(s[i]))
                {
                    dictionary.Add(s[i], i);
                    length_cur++;
                }
                else
                {
                    int temp = dictionary[s[i]];
                    for (int j = start_point; j < temp + 1; j++)
                        dictionary.Remove(s[j]);
                    length_pre = Math.Max(i - start_point,length_pre);
                    length_cur = i - temp;
                    start_point = temp + 1;
                    dictionary.Add(s[i], i);
                }
            }
            return Math.Max(length_pre,length_cur);
        }
    }
}
