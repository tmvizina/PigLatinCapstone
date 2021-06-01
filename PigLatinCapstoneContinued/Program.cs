using System;


namespace PigLatinCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator");

            bool goOn = true;

            while (goOn == true)
            {

                //This prompts the user for input
                string userInput = GetUserInput("Enter a message (space delimited)");

                //splits the users input along the spaces into different words
                string[] words = userInput.Split(' ');

                //holds the string piglatin for later
                string phrasepiglatin = "";


                //for each loop that iterates through the string array and calls my traslate method for each word
                //then it takes the preheld empty string and adds each translated word back into it
                foreach (var word in words)
                {


                    if (NumberSymbolCheck(word) == false)
                    {

                        string wordpiglatin = PigLatinTranslate(word);
                        // Console.WriteLine(wordpiglatin);

                        phrasepiglatin = phrasepiglatin + wordpiglatin + " ";
                    }
                    else
                    {
                        phrasepiglatin = phrasepiglatin + word;
                    }



                }

                Console.WriteLine("Inputted Phrase in PigLatin");
                Console.WriteLine(phrasepiglatin);

                Console.WriteLine("Would you like to translate another Phrase? (y/n)");
                string userContinue = Console.ReadLine().ToLower();
                if (userContinue == "n")
                {
                    goOn = false;
                }
                else
                {
                    continue;
                }

            }


        }


        public static bool NumberSymbolCheck(string userInput)
        {
            char[] userInputArray = userInput.ToCharArray();

            string numbersAndSpecialChar = "0123456789@#$%^&*()";

            char[] numsschararry = numbersAndSpecialChar.ToCharArray();

            if (userInput.Contains('0') == true || userInput.Contains('1') == true || userInput.Contains('2') == true || userInput.Contains('3') == true || userInput.Contains('4') == true || userInput.Contains('5') == true || userInput.Contains('6') == true || userInput.Contains('7') == true || userInput.Contains('8') == true || userInput.Contains('9') == true || userInput.Contains('@') == true || userInput.Contains('#') == true || userInput.Contains('$') == true || userInput.Contains('%') == true || userInput.Contains('^') == true || userInput.Contains('&') == true || userInput.Contains('*') == true || userInput.Contains('(') == true || userInput.Contains(')') == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public static string PigLatinTranslate(string userInput)
        {

            char[] userInputArray = userInput.ToCharArray();




            // gives me a char array of all vowels that I am checking for
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };


            //This was the long drawn out way of checking for a vowel in the first index location. I am glad I found IndexOfAny because it saves
            //me from having to write a for loop to manually check the chars in every location from 0 to userInput.Length-1
            //though as I am I writing it it doesn't sound too hard really
            if (userInputArray[0] == 'a' || userInputArray[0] == 'e' || userInputArray[0] == 'i' || userInputArray[0] == 'o' || userInputArray[0] == 'u')
            {
                string userpiglatin = userInput + "way";

                return userpiglatin;
            }
            else
            {

                //this will give me the first index location of a vowel in the input string
                int firstvowelindex = userInput.IndexOfAny(vowels);

                string prevowel = userInput.Substring(0, firstvowelindex);

                string userpiglatin = userInput.Substring(userInput.IndexOfAny(vowels)) + prevowel + "ay";

                return userpiglatin;

            }

        }


        //This was a method that would have taken an input and compared it to char array of all alpha char to see if it contained only lettesr
        //this was incomplete and was not implemented into the final push
        //public static bool TextCheck(string userInput)
        //{
        //    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //    char[] alphaarray = alphabet.ToCharArray();
        //    int match = userInput.IndexOfAny(alphaarray);
        //    if(match !=-1)
        //    {
        //        return true
        //    } else
        //    {
        //      return false
        //    }
        //}



        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static bool VowelCheck(string userInput)
        {
            if (userInput.Contains("a") == true || userInput.Contains("e") == true || userInput.Contains("i") == true || userInput.Contains("o") == true || userInput.Contains("u") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
