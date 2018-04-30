using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anna_Baseley_Capstone1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Translate = true;

            while (Translate)
            {
                //input
                string UserPhrase = GetUserPhrase("What would you like to have translated?");

                //processing
                string PigLatinPhrase = TranslatetoPigLatin(UserPhrase);
                string PigLatinPhrasewithCase = PigLatinWithCase(PigLatinPhrase);

                //output
                Console.WriteLine($"{PigLatinPhrasewithCase}");

                //Continue?
                Translate = KeepTranslating();
            }

        }
        public static string GetUserPhrase(string Message)
        {

            Console.WriteLine(Message);
            string UserPhrase = Console.ReadLine();          
            return UserPhrase;           
        }
        public static string TranslatetoPigLatin(string UserPhrase)
        {
            const string Vowels = "aeiouAEIOU";

            char[] Symbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '@'};
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            char[] PunctuationEx = { ',', '.', '?', ':', ';', '-', '!', '"' };

            List<string> PigLatinPhrase = new List<string>();

            foreach (string Word in UserPhrase.Split(' '))
            {
                int VowelCheck = Word.IndexOfAny(vowels);
                int SymbolCheck = Word.IndexOfAny(Symbols);

                if (SymbolCheck >= 0)
                {
                    PigLatinPhrase.Add(Word);
                }
                    
                else if (VowelCheck == -1)
                {
                    PigLatinPhrase.Add(Word + "way");
                }

                else
                {
                    string FirstLetter = Word.Substring(0, Word.IndexOfAny(vowels));
                    string WordWPunc = Word.Substring(Word.IndexOfAny(vowels), Word.Length - Word.IndexOfAny(vowels) - 1);
                    string WordWOPunc = Word.Substring(Word.IndexOfAny(vowels), Word.Length - Word.IndexOfAny(vowels));
                    string Punctuation = Word.Substring(Word.Length - 1, 1);

                    int VowelIndex = Vowels.IndexOf(FirstLetter);
                    int PunctuationCheck = Punctuation.IndexOfAny(PunctuationEx);

                    if (PunctuationCheck >= 0)

                    {
                        if (VowelIndex == -1)
                        {
                            PigLatinPhrase.Add(WordWPunc + FirstLetter + "ay" + Punctuation);
                        }

                        else
                        {
                            PigLatinPhrase.Add(WordWPunc + "way" + Punctuation);
                        }
                    }

                    else
                    {
                        if (VowelIndex == -1)
                        {
                            PigLatinPhrase.Add(WordWOPunc + FirstLetter + "ay");
                        }

                        else
                        {
                            PigLatinPhrase.Add(WordWOPunc + "way");

                        }
                    }
                }
            }
            return string.Join(" ", PigLatinPhrase);
        }
        public static string PigLatinWithCase(string PigLatinPhrase)
        {
            List<string> PigLatinPhraseCase = new List<string>();

            foreach (string PigLatinWord in PigLatinPhrase.Split(' '))
            {
                string FirstLetter = PigLatinWord.Substring(0, 1);
                string RestofWord = PigLatinWord.Substring(1, PigLatinWord.Length - 1);
       
                if (PigLatinWord.Any(char.IsUpper))
                {
                    PigLatinPhraseCase.Add(FirstLetter.ToUpper() + RestofWord.ToLower());
                }
                else
                {
                    PigLatinPhraseCase.Add(PigLatinWord);
                }
            }
            return string.Join(" ", PigLatinPhraseCase);
        }
        public static bool KeepTranslating()
        {
            Console.WriteLine("Would you like to keep translating? y/n");
            string UserAnswer = Console.ReadLine().ToLower();
            
            while(UserAnswer != "n" && UserAnswer != "y")
            {
                Console.WriteLine("I'm sorry, I didn't quite get that. Continue? y/n");
                UserAnswer = Console.ReadLine().ToLower();
            }

            while(true)
            {
                if (UserAnswer == "n")
                {
                    Console.WriteLine("Okay! Bye!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
