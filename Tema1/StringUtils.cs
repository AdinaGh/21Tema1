using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class StringUtils
    {
        public string Reverse(string input)
        {
            if (input == "")
            {
                throw new ArgumentNullException("String is invalid");
            }

            var result = input.ToCharArray();
            var indexEnd = result.Length - 1;
            var indexStart = 0;

            while (indexStart < indexEnd)
            {
                if (!char.IsLetter(result[indexStart]))
                    indexStart++;
                else if (!char.IsLetter(result[indexEnd]))
                    indexEnd--;

                else
                {
                    char tmp = result[indexStart];
                    result[indexStart] = result[indexEnd];
                    result[indexEnd] = tmp;
                    indexStart++;
                    indexEnd--;
                }
            }
            return String.Join("", result);
        }

        public string GoatLatin(string input)
        {
            var vowelCh = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            var vowel = new HashSet<char>(vowelCh);
            int t = 1;
            StringBuilder ans = new StringBuilder();
            foreach(var word in input.Split(' '))
            {
                char first = word[0];
                if (vowel.Contains(first))
                {
                    ans.Append(word);
                }
                else
                {
                    ans.Append(word.Substring(1));
                    ans.Append(word.Substring(0, 1));
                }
                ans.Append("ma");
                for (int i = 0; i < t; i++)
                    ans.Append("a");
                t++;
                ans.Append(" ");
            }
            ans.Remove(ans.Length - 1, 1);
            return ans.ToString();
        }
    }
}
