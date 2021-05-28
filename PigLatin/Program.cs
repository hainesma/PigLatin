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
                Console.WriteLine(matchedCase.GetType());
                foreach(char m in matchedCase)
                {
                    Console.WriteLine(m);
                }

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


        //public static string MatchCase(string original, string translated)
        //{
        //    for (int i=0; i <= original.Length -1; i++)
        //    {
        //        bool result = Char.IsUpper(original, i);

        //        string properCase = translated;

        //        if (result == true)
        //        {
        //             properCase = translated[i].to;
        //        }
        //    }
        //}

        public static string MatchCase(string original, string translated)
        {
            char[] originalLetters = original.ToCharArray();
            char[] translatedLetters = translated.ToCharArray();

            for (int i = 0; i <= original.Length - 1; i++)
            {
                bool upperCheck = Char.IsUpper(originalLetters[i]);

                if (upperCheck == true)
                {
                    translatedLetters[i] = Char.ToUpper(translatedLetters[i]);
                }
            }

            string output = translatedLetters.ToString();

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
