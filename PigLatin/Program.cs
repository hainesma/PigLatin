using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = GetUserInput();
            Console.WriteLine(word);

            string piggified = Translate(word);
            Console.WriteLine(piggified);

        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please enter a word.");
            string input = Console.ReadLine();
            return input;
        }

        public static string Translate(string input)
        {
            

            int firstA = input.IndexOf('a');
            int firstE = input.IndexOf('e');
            int firstI = input.IndexOf('i');
            int firstO = input.IndexOf('o');
            int firstU = input.IndexOf('u');

            Console.WriteLine(firstA);

            int[] vowelLocations = { firstA, firstE, firstI, firstO, firstU };

            int firstVowelLocation = firstA;
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

            string translated = "initial";
            if (firstVowelLocation == 0)
            {
                translated = input + "way";
            } else
            {
                string[] splits = input.Split(input[firstVowelLocation]);
                foreach(string split in splits)
                {
                    Console.WriteLine(split);
                }
                
                translated = input[firstVowelLocation] + splits[1] + splits[0] + "ay";
            }

            return translated;
        }
    }
}
