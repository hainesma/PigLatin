using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {

                string word = GetUserInput();
                Console.WriteLine(word);

                string piggified = Translate(word);
                Console.WriteLine(piggified);

                string matchedCase = MatchCase(word, piggified);
                Console.WriteLine(matchedCase);

                goOn = GetContinue();
            }
        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please enter a word.");
            string input = Console.ReadLine();
            return input;
        }

        public static string Translate(string input)
        {
            string output = input.ToLower();
            
            int firstA = output.IndexOf('a');
            int firstE = output.IndexOf('e');
            int firstI = output.IndexOf('i');
            int firstO = output.IndexOf('o');
            int firstU = output.IndexOf('u');

            int[] vowelLocations = { firstA, firstE, firstI, firstO, firstU };

            int firstVowelLocation = 10;
            Console.WriteLine(firstVowelLocation);

            foreach (int vowelLocation in vowelLocations)
            {
                if(vowelLocation == -1)
                {
                    continue;
                } 
                else if(vowelLocation < firstVowelLocation)
                {
                    firstVowelLocation = vowelLocation;
                }
            }

            Console.WriteLine(firstVowelLocation);

            string translated = "";
            if (firstVowelLocation == 0)
            {
                translated = output + "way";
            } 
            else
            {
                string firstHalf = output.Substring(0, firstVowelLocation);
                string secondHalf = output.Substring(firstVowelLocation, output.Length - firstVowelLocation);
                translated = secondHalf + firstHalf + "ay";
            }
            return translated;
        }

        public static string MatchCase(string original, string translated)
        {
            char[] originalLetters = original.ToCharArray();
            char[] translatedLetters = translated.ToCharArray();
            string output = string.Empty;

            if ( Char.IsUpper(originalLetters[0]) == true && Char.IsUpper(originalLetters[1]) == true )
            {
                string upperOutput = string.Empty;
                foreach( char t in translatedLetters )
                {
                    char upperLetter =  Char.ToUpper(t);
                    upperOutput += upperLetter;

                }
                output = upperOutput;
            } 
            else if ( Char.IsUpper(originalLetters[0]) == true && Char.IsUpper(originalLetters[1]) == false )
            {
                translatedLetters[0] = Char.ToUpper(translatedLetters[0]);
                output = new string(translatedLetters);
            }
            
            
            // This is the way to make a char array into a string
            

            return output;
        }

        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to translate another word? (Y/N)");
            string input = Console.ReadLine();
            if(input.ToLower() == "y")
            {
                return true;
            } 
            else if(input.ToLower() == "n")
            {
                return false;
            } else
            {
                Console.WriteLine("I don't understand that input. Please try again.");
                return GetContinue();
            }
        }
    }
}
