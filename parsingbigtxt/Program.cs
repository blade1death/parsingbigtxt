using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string fileName = @"C:\Users\Администратор\source\repos\parsingbigtxt\parsingbigtxt\input.txt";
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // читаем каждую строку из файла и разбиваем ее на слова
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    foreach (string word in words)
                    {
                        // очищаем слово от знаков препинания и приводим его к нижнему регистру
                        string cleanedWord = new string(word.Where(char.IsLetter).ToArray()).ToLower();
                        if (cleanedWord.Length > 0)
                        {
                            // увеличиваем счетчик для слова или добавляем его в словарь, если оно не встречалось раньше
                            if (wordCount.ContainsKey(cleanedWord))
                            {
                                wordCount[cleanedWord]++;
                            }
                            else
                            {
                                wordCount.Add(cleanedWord, 1);
                            }
                        }
                    }
                }
            }

            // сортируем словарь по убыванию количества употреблений
            var sortedWords = wordCount.OrderByDescending(w => w.Value);

            // записываем отсортированный список слов и их частот в выходной файл
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Администратор\\source\\repos\\parsingbigtxt\\parsingbigtxt\\output.txt"))
            {
                foreach (var word in sortedWords)
                {
                    sw.WriteLine("{0}: {1}", word.Key, word.Value);
                }
            }

            Console.WriteLine("Word count complete. Results saved to output.txt.");
        }
    }
}