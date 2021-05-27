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

                goOn = GetContinue();
            }
        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please enter a word.");
            string input = Console.ReadLine();
            string output = input.ToLower();
            return output;
        }

        public static string Translate(string output)
        {
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
            } else
            {
                string[] splits = output.Split(output[firstVowelLocation]);
                foreach(string split in splits)
                {
                    Console.WriteLine(split);
                }
                
                translated = output[firstVowelLocation] + splits[1] + splits[0] + "ay";
            }

            return translated;
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
