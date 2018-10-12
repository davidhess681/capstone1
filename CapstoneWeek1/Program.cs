using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWeek1
{
    class Program
    {
        // define these strings in the class so any of the methods can use it
        static string[] words;
        static string wordLower;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                Console.Write("Enter a line to be translated: ");

                // store user input as a string
                string userPhrase = Console.ReadLine();

                // split user input into individual words in an array
                words = userPhrase.Split(' ');

                translatePigLatin();
                Console.Write("\n\nWant to play again? (y/n): ");
            }
            while (PlayAgain());
        }

        static void translatePigLatin()
        {
            // use a foreach loop to translate each word
            foreach (string word in words) {
                
                // convert to lower case
                wordLower = word.ToLower();

                // skip empty strings in the "words" array so it doesn't crash
                if (wordLower == "")
                {
                    continue;
                }

                // if first letter is a vowel, write word + "way"
                if (indexFirstVowel() == 0)
                {
                    Console.Write(wordLower + "way ");
                }
                else
                {

                    // write each letter from the first vowel to the end of the word
                    for (int n = indexFirstVowel(); n < wordLower.Length; n++)
                    {
                        Console.Write(wordLower[n]);
                    }

                    // write each letter from the first letter to the first vowel
                    for (int i = 0; i < indexFirstVowel(); i++)
                    {
                        Console.Write(wordLower[i]);
                    }

                    // add "ay" to the end of the word
                    Console.Write("ay ");
                }
            }
        }
        static int indexFirstVowel()
        {
            // check each character for the first vowel; return the index of that first vowel
            for (int i = 0; i < wordLower.Length; i++)
            {
                if (wordLower[i] == 'a' || wordLower[i] == 'e' || wordLower[i] == 'i' || wordLower[i] == 'o' || wordLower[i] == 'u')
                {
                    return i;
                }
            }
            // if there are no vowels, just return the length of the word
            return wordLower.Length;
        }

        static bool PlayAgain()
        {
            // repeat the program if user types "y", close if "n"
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        return true;
                    }
                case "n":
                    {
                        return false;
                    }
                default:
                    {
                        Console.Write("Invalid. Try again: ");
                        return PlayAgain();
                    }
            }
        }
    }

}
