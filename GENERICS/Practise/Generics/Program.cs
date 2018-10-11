using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Generics
{
    class Program
    {

        static int CheckTheSame(Dictionary<int, List<string>> keyValuePairs, string value)
        {
            for (int i = 0; i < keyValuePairs.Values.Count; i++)
            {
                List<string> list = keyValuePairs[i];
                if (list[0] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        static bool CheckSame(Dictionary<int, List<string>> keyValuePairs, string value)
        {
            if (keyValuePairs.Values.Count == 0) return false;
            for(int i = 0; i< keyValuePairs.Values.Count; i++)
            {
                List<string> list = keyValuePairs[i];
                if (list[0] == value) return true;
            }
            return false;
        }

        static void ShowInfo(Dictionary<int, List<string>> keyValuePairs)
        {
            WriteLine("\tСлово: \t\tКол-во:");
            for (int i = 0; i < keyValuePairs.Values.Count; i++)
            {
                List<string> value = keyValuePairs[i];
                WriteLine((i+1)+ ".\t" + value[0] + "\t\t" + value.Count);
            } 
        }

        static void Main(string[] args)
        {
            Dictionary<int, List<string>> keyValuePairs = new Dictionary<int, List<string>>();

            string text = "Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном  чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

            string[] words = text.Split(' ', ',' , '.'); 
            for(int i = 0; i < words.Length; i++)
            {
                if (words[i] == "")
                {
                    var list = words.ToList();
                    list.RemoveAt(i);
                    words = list.ToArray();
                    i--;
                }
            }

             int countOfWords = words.Length;

            for (int i = 0; i < words.Length; i++)
            {
                if(CheckSame(keyValuePairs, words[i]))
                {
                    int j = CheckTheSame(keyValuePairs, words[i]);
                    if (j != -1) {
                        keyValuePairs[j].Add(words[i]);
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(words[i]);

                    keyValuePairs.Add(keyValuePairs.Count, list);
                }
            }

            ShowInfo(keyValuePairs);

        }
    }
}
