using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            var consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries) 
                .Select(char.Parse));



            var words = new Dictionary<string, string>()
            {
                { "pear", "pear" },
                { "flour", "flour"},
                { "pork", "pork"},
                { "olive", "olive"},
            };

            var listWords = new List<string>()
            {
                { "pear" },
                { "flour" },
                { "pork" },
                { "olive" },

            };

            while (consonants.Any())
            {
                var c = consonants.Pop().ToString();   
                var v = vowels.Dequeue().ToString();   

                foreach ( var word in listWords)
                {
                    if (words[word].Contains(c))
                    {
                        words[word] = words[word].Replace(c, string.Empty);
                    }

                    if (words[word].Contains(v))
                    {
                        words[word] = words[word].Replace(v, string.Empty);
                    }
                }

                vowels.Enqueue(char.Parse(v));

            }

            Console.WriteLine($"Words found: {words.Where(w => w.Value == string.Empty).Count()}");
            foreach ( var word in words)
            {
                if (word.Value == string.Empty)
                {
                    Console.WriteLine(word.Key);
                }
            }


        }

        

    }
}
