using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = createDictionary();
            //1. Take a user input of a word an check if it has been spelled correctly
            Console.WriteLine("input a word");
            string UserWord = Console.ReadLine();
           int count = 0;
            int correct = 0;
            int incorrect = 0;
            bool valid = false;
           //spellchecking
            while (valid == false) 
            {
                if (words[count] == UserWord)
                {
                    valid = true;
                    correct++;
                }
                else if (valid == false)  //incorrectly spelled words
                {
                    incorrect++;
                    WordsFile.txt(UserWord); //adding incorrect words to a new file
                }
                count++;
            }
            Console.WriteLine(valid);
            if (valid == false)
            {
                incorrect++;
                WordsFile.txt(UserWord);
            }
            else
            {
                correct++;
            }
            string[] words2 = new string[3];
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Input a word.");
                words2[i] = Console.ReadLine();
            }
            bool valid1 = false;
            bool valid2 = false;
            bool valid3 = false;
            while (valid1 == false && valid2 == false && valid3 == false)
            {
                if (dictionaryData == words2[0])
                {
                    valid1 = true;
                }
                else if (dictionaryData == words2[1])
                {
                    valid2 = true;
                }
                else if (dictionaryData == words2[2])
                {
                    valid3 = true;
                }
            }
            Console.WriteLine(valid1 && valid2 && valid3);
            if (valid1 == false)
            {
                incorrect++;
                WordsFile.txt(words2[0]);
            }
            else if (valid2 == false)
            {
                incorrect++;
                WordsFile.txt(words2[1]);
            }
            else if (valid3 == false)
            {
                incorrect++;
                WordsFile.txt(words2[2]);
            }
            if (valid1 == true)
            {
                correct++;
            }
            else if (valid2 == true)
            {
                correct++;
            }
            else if (valid3 == true)
            {
                correct++;
            }
            Console.WriteLine(correct / (correct + incorrect) * 100 + "%");
            //2. Take a string of words as a user input and check they have all been spelled correctly

            //3.Create a spelling score based on the percentage of words spelled correctly

            //4.Create a new list of words that have been spelled incorrectly and save it in a new file

            //Challenge - Hard task

            //Try to work out which words the user is trying to spell by looking for similarities in
            //the spelling and ask the user did they mean that.

            //Add these suggested words to a spelling list that the user can save as a file to work on
            //their own spelling



        }
        static string[] createDictionary()
        {
            using StreamReader words = new("WordsFile.txt");
            int count = 0;
            string[] dictionaryData = new string[178636];
            while (!words.EndOfStream)
            {

                dictionaryData[count] = words.ReadLine();
                count++;
            }
            words.Close();
            return dictionaryData;
        }
    }
}
