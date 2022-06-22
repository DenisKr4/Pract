using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static List<string> words = new List<string>() { "слово", "пустой", "простой", "случайный", "основа" };
        static List<string> designation = new List<string>() { "Единица речи, служащая для выражения отдельного понятия.", "О вместилище: ничем не заполненный, полый внутри.", "Не сложный, не трудный, легко доступный пониманию.", "Бывающий лишь иногда, от случая к случаю.", "Внутренняя опорная часть предметов." };
        static void Main(string[] args)
        {
            Console.WriteLine("Список слов:");
            foreach (string x in words)
                Console.WriteLine(x);

            while(true)
            {
                Console.WriteLine();
                Console.Write("Введите слово: ");
                string word = Console.ReadLine();
                Console.WriteLine();

                string possibleWord = string.Empty;
                int index = words.IndexOf(word);

                if (index == -1)
                {
                    possibleWord = FindPossibleWord(word);
                    if (possibleWord == string.Empty)
                    {
                        Console.WriteLine("Нет подходяего слова");
                    }
                    else
                    {
                        Console.WriteLine("Возможно вы имели ввиду \"" + possibleWord + "\"? (да/нет)");
                        if (Console.ReadLine() == "да")
                        {
                            index = words.IndexOf(possibleWord);
                            Console.WriteLine(designation[index]);
                        }
                        else
                        {
                            Console.WriteLine("Нет подходяего слова");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(designation[index]);
                }
            }
        }

        static string FindPossibleWord(string word)
        {
            int len = words.Count;
            string[,] wordsMatrix = new string[len, 2];

            for(int i = 0; i < len; i++)
            {
                wordsMatrix[i, 0] = words[i];
                wordsMatrix[i, 1] = "0";
            }
            
            for(int i = 0; i < len; i++)
            {
                int coincidenceCounter = 0;
                
                if (wordsMatrix[i, 0].Length == word.Length)
                {
                    char[] inputWord = word.ToCharArray();
                    char[] possibleWord = words[i].ToCharArray();
                    for(int j = 0; j < word.Length; j++)
                    {
                        if (Char.ToLower(inputWord[j]) == Char.ToLower(possibleWord[j]))
                            coincidenceCounter++;
                    }
                }
                
                wordsMatrix[i, 1] = coincidenceCounter.ToString();
            }

            string temp1 = string.Empty;
            string temp2 = string.Empty;

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (Convert.ToInt32(wordsMatrix[i, 1]) < Convert.ToInt32(wordsMatrix[j, 1]))
                    {
                        temp1 = wordsMatrix[i, 0];
                        wordsMatrix[i, 0] = wordsMatrix[j, 0];
                        wordsMatrix[j, 0] = temp1;
                        temp2 = wordsMatrix[i, 1];
                        wordsMatrix[i, 1] = wordsMatrix[j, 1];
                        wordsMatrix[j, 1] = temp2;
                    }
                }
            }

            if (wordsMatrix[0, 1] != "0")
                return wordsMatrix[0, 0];
            else
                return string.Empty;
        }
    }
}
