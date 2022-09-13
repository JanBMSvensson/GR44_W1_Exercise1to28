






/* This code is just for playing around with C# - all exercises are (somewhat) solved but not always as suggested/intenden. */






using GR44_W1_Exercise1to28.CardClasses;
using System;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Console;

namespace GR44_W1_Exercise1to28
{
    internal class Program
    {

        delegate void Exercise();

        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;

            List<Exercise> Exercises = new(new Exercise[] { Ex01, Ex02, Ex03, Ex04, Ex05, Ex06, Ex07, Ex08, Ex09, Ex10,
                                                            Ex11, Ex12, Ex13, Ex14, Ex15, Ex16, Ex17, Ex18, Ex19, Ex20,
                                                            Ex21, Ex22, Ex23, Ex24, Ex25, Ex26, Ex27, Ex28 });

            string? MenuChoice;
            bool KeppLooping = true;

            while (KeppLooping)
            {
                WriteLine("----- MAIN MENU ------");
                Write($"Enter assignment number 1 - {Exercises.Count} (or anything else to exit): ");

                MenuChoice = ReadLine();
                if (int.TryParse(MenuChoice, out int num))
                {
                    if (num >= 1 && num <= Exercises.Count)
                    {
                        Exercises[num - 1].Invoke();
                        WriteLine();
                    }
                    else
                    {
                        KeppLooping = false;
                    }
                }
                else
                {
                    KeppLooping = false;
                }
            }

            WriteLine("Bye ...");
        }

        static void Ex01()
        {
            /* Inside the RunExerciseOne method, add two new variables to your program that stores string values. 
            One of them is going to store you first name and the other your last name, so give them informative 
            names. Then let the program output: 
            “Hello <firstname> <lastname>! I’m glad to inform you that you are the test subject of my very first assignment!” */

            string FirstName = "Jan", LastName = "Svensson";
            WriteLine($"Hello {FirstName} {LastName}! I’m glad to inform you that I am the test subject of my very first assignment!");

        }

        static void Ex02()
        {
            /* Inside the RunExerciseTwo method, create three new variables of type 
            DateTime and let them store yesterdays, todays and tomorrows date. 
            Remember to give them informative names. Then let your program output 
            them to the screen like: */

            var OldCult = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            WriteLine($"Todays it is the {Program.OrdinalSuffix(DateTime.Today.Day)} day in {DateTime.Today:MMMM} and it is a {DateTime.Today:dddd}");
            WriteLine($"Tomorrows date is {DateTime.Today.AddDays(1):d}");
            WriteLine($"Yesterday date was {DateTime.Today.AddDays(-1):D}");

            System.Threading.Thread.CurrentThread.CurrentCulture = OldCult;
        }

        static void Ex03()
        {
            /* Create a new method named RunExerciseThree and write the program code inside that prompts the 
            user to input his first and last name like shown below (with correct line breaks). Also, create two new 
            variables that stores string values and save the input from the user into these (So that one variable stores the 
            first name and the other stores the last name). Then output the full name to the screen on one line. Inside 
            the switch-statement in the main method, call you new method (see the calls to the previous methods) after 
            case 3. */

            string? FirstName = Program.AskUserForString("Enter your first name: ");
            string? LastName = Program.AskUserForString("Enter your last name: ");
            WriteLine($"{FirstName} {LastName}");
        }

        static void Ex04()
        {
            /* The code snippet below will be used for this exercise, so create a new method for exercise 4 and 
            make sure to call in inside the switch statement after case 4. 
            Inside the method body, create a new empty string variable below the variable str. Use string manipulation
            methods like SubString, IndexOf, Remove, Replace, Insert to get the string “The brown fox jumped over the 
            lazy dog”, where all characters matches exactly and output these to the screen. */

            string str = "The quick fox Jumped Over the DOG";
            WriteLine(str.Substring(0, 1) + str.Substring(1).ToLower().Replace("quick", "brown"));
        }

        static void Ex05()
        {
            /* Below is a given string. Use string manipulations to get the [1,2,3,4,5] part from the string and store it
            into a new string variable. Then remove the values 2 and 3 and insert 6-10 into it in the end, comma 
            separated so that the result is [1,4,5,6,7,8,9,10] and let your program output that to the console window. */

            List<string> ListOfNumbers = new();
            string str = "Arrays are very common in programming, they look something like: [1,2,3,4,5]";
            WriteLine(str);

            var BracketStartPos = str.IndexOf("[");
            var BracketEndPos = str.IndexOf("]");
            if (BracketStartPos >= 0 && BracketEndPos >= 0 && BracketStartPos < BracketEndPos)
            {
                ListOfNumbers.AddRange(str.Substring(BracketStartPos + 1, BracketEndPos - BracketStartPos - 1).Split(","));
                ListOfNumbers.RemoveAll(NumbersToRemove);
                for (int i = 6; i <= 10; i++)
                {
                    ListOfNumbers.Add(i.ToString());
                }
                WriteLine(str.Substring(0, BracketStartPos + 1) + String.Join(",", ListOfNumbers.ToArray()) + str.Substring(BracketEndPos));
            }
            else
                WriteLine("Not possible!");


            static bool NumbersToRemove(string s)
            {
                return (s == "2") || (s == "3");
            }

        }

        static void Ex06()
        {
            /* Write the program code that lets the user input 2 integers from the 
            console. Then let the program output the biggest, smallest, difference
            ( - ), sum (+), product ( * ) and ratio ( / ) between the two numbers. */

            int int1 = Program.AskUserForInt("Enter an integer: ");
            int int2 = Program.AskUserForInt("Enter a second integer: ");

            WriteLine($"{(int1 > int2 ? int1 : (int1 < int2 ? int2 : "None of them"))} is the bigger int.");
            WriteLine($"{(int1 < int2 ? int1 : (int1 > int2 ? int2 : "None of them"))} is the smaller int.");
            WriteLine($"{int1} + {int2} = {int1 + int2}");
            WriteLine($"{int1} - {int2} = {int1 - int2}");
            WriteLine($"{int1} * {int2} = {int1 * int2}");
            WriteLine($"{int1} / {int2} = {(int2 == 0 ? "not possible to calculate" : (Decimal)int1 / int2)}");

        }
        static void Ex07()
        {
            /* Write the program code that lets the user input the radius (as a 
            double). Then calculate the area and volume of a circle respective 
            sphere with the given radius. (area = 2 πr 2, volume = (𝟒 × 𝛑 ×𝐫𝟑)/𝟑). Output 
            the result to the screen. */

            // The area of a circle is not as suggested in the exercise ... ;o)

            double Radius = Program.AskUserForDouble("Enter the radius: ");

            WriteLine($"The area of a circle with radius {Radius} is {Math.PI * Math.Pow(Radius, 2):F2}");
            WriteLine($"The volume of a sphere with radius {Radius} is {4.0/3.0 * Math.PI * Math.Pow(Radius, 3):F2}");
        }
        static void Ex08()
        {
            /* Let the user input a decimal number. Then output square root of the 
            number and the number raised to the power of 2 and 10. That is 
            √n, n2, n10. */

            decimal decNum = Program.AskUserForDecimal("Enter a decimal number: ");
            WriteLine($"The square root of {decNum} is {Math.Sqrt((double)decNum)}");
            WriteLine($"{decNum} raised to the power of 2 is {Math.Pow((double)decNum, 2.0)}");
            WriteLine($"{decNum} raised to the power of 10 is {Math.Pow((double)decNum, 10.0)}");
        }
        static void Ex09()
        {
            /* In this exercise, you are going to practice using selection. To start with, create a new exercise method
            and make a call to it after case 9.
            Let your program ask the user for his name and save it into a variable. 
            Let your program greet the user by his name, and ask for his/her birth year and convert it into an integer. 
            For example 1978 or 1983.
            Calculate the age of the user by simple integer subtraction from the current year. (You can use 
            DateTime.Now.Year to retrieve the current year). Depending in which month and day the user is born in, this 
            calculation might not give back the correct whole number of years, but it will do for this example. */


            // Just for the fun of it ... I'm trying to solve this by backward chaining ...


            BackwardChainedBartender Bartender = new();
            Bartender.AskGuestEvent += Bartender_AskGuestEvent;

            WriteLine($"The guest is served {Bartender.ServerDrink()}");

            Bartender.AskGuestEvent -= Bartender_AskGuestEvent;



            static void Bartender_AskGuestEvent(object? sender, AskGuestEventArg e)
            {
                Write(e.Question);
                Write(" ");
                e.Answer = ReadLine() ?? String.Empty;
            }
        }

        static void Ex10()
        {
            /* Write the program code that will ask to user to choose between 3 different options using a switchstatement.
            1. Let the first option invoke a method that let the user input two numbers (a and b). Check that b is 
            not equal to zero and then output a divided by b to the screen. If b is equal to zero, display an error
            message to the user. 
            2. Let the second option invoke the method used in exercise 4 (The quick fox jumped over the lazy 
            dog).
            3. Let the third option toggle the foreground colour between two different colours each time you 
            choose it. (Use an if-statement to check the current colour) */

            Write("Select option 1-3: ");
            
            switch (ReadLine()) {
                case "1":
                    int int1 = Program.AskUserForInt("Enter an integer: ");
                    int int2 = Program.AskUserForInt("Enter a second integer: ");
                    WriteLine($"{int1} / {int2} = {(int2 == 0 ? "not possible to calculate" : (Decimal)int1 / int2)}");
                    break;

                case "2":
                    Ex04();
                    break;

                case "3":
                    ForegroundColor = ForegroundColor == ConsoleColor.Yellow ? ConsoleColor.Gray: ConsoleColor.Yellow;
                    break;

                default:
                    WriteLine("Bad choice!");
                    break;
            }
        }
        
        static void Ex11()
        {
            /* In the exercise method, write the code that lets the user input an integer number. Check 
            that the given number is greater than 0. If not display an error message. 
            Then write two for-loops, where one start from 
            zero and counts up to the given number 
            (0,1,2,3,4…, n) and another for-loop that starts 
            counting from the given number down to zero 
            (n,…,3,2,1,0).
            In both loops, check each number if it’s evenly 
            divisible by 2. If it is, change the console colour to 
            red, else to green.  */

            int num = Program.AskUserForInt("Enter an integer value above zero: ");
            if (num <= 0)
            {
                WriteLine("That was not above zero!");
                return;
            }

            for (int i = 0; i <= num; i++)
            {
                ForegroundColor = i % 2 == 0 ? ConsoleColor.Red : ConsoleColor.Green;
                WriteLine(i);
            }

            ForegroundColor = ConsoleColor.Gray;
            WriteLine("------------------");

            for (int i = num; i >= 0; i--)
            {
                ForegroundColor = i % 2 == 0 ? ConsoleColor.Red : ConsoleColor.Green;
                WriteLine(i);
            }

            ForegroundColor = ConsoleColor.Gray;
        }
        
        static void Ex12()
        {
            /* Write a program that output the multiplication table for 1 to 10 using nested for-loops. The format is 
            not of great important but to make the code readably, add a tab after each number using the 
            escape character \t. */

            for (int r = 1; r <= 10; r++)
            {
                for (int c = 1; c <= 10; c++)
                {
                    ForegroundColor = r==1 | c== 1 ? ConsoleColor.White : ConsoleColor.Gray;
                    Write((r * c).ToString().PadLeft(4));
                }
                WriteLine();
            }
            ForegroundColor= ConsoleColor.Gray;
        }

        static int? Ex13_Lowscore = null;

        static void Ex13()
        {
            /* Write a program that first generates a random number between 1 and 500 and stores it into a 
            variable (see the Random class). Then let the user make a guess for which number it is. If the user 
            types the correct number, he should be presented with a message (including the number of guesses he has 
            made). If he types a number that is greater or smaller than the given number, display either “Your guess was 
            too small” or “Your guess was too big”. The program should keep executing until the user input the correct 
            guess. */

            var num = new Random().Next(500) + 1;
            int guess = Program.AskUserForInt("Guess a number between 1 and 500: ");
            int counter = 1;

            while (guess != num)
            {
                guess = Program.AskUserForInt($"Your {Program.OrdinalSuffix(counter)} guess is too {(guess < num ? "small" : "big")}. Guess again: ");
                counter++;
            }

            if (!Ex13_Lowscore.HasValue)
            {
                WriteLine($"Correct! You got it right on your {Program.OrdinalSuffix(counter)} guess. Can you do better?");
                Ex13_Lowscore = counter;
            }
            else if (Ex13_Lowscore.HasValue && counter < Ex13_Lowscore)
            {
                WriteLine($"YEAH! Only {Program.OrdinalSuffix(counter)} guesses. That's the lowest score ever ... but surely you can do even better?");
                Ex13_Lowscore = counter;
            }
            else
                WriteLine($"Correct! You got it right on your {Program.OrdinalSuffix(counter)} guess but the lowscore is {Ex13_Lowscore} guesses.");
        }

        static void Ex14()
        {
            /* Write a program that keeps asking the user for input numbers, 
            until he enters -1. Store the amount of numbers the user have 
            entered and the sum of the numbers added together. When the user 
            types -1, the program should display the sum and the average of the 
            numbers */

            int value;
            int sum = 0;
            int counter = 0;

            do
            {
                value = Program.AskUserForInt("Enter a number: ");
                sum += value;
                counter++;
            } 
            while (value != -1);

            sum -= value; // remove the -1

            WriteLine($"Sum: {sum}");
            WriteLine($"Avg: {(decimal)sum / counter:N2}");
        }
        
        static void Ex15()
        {
            /*  Write the program code that asks the user for a number. Then display all numbers that the number 
            is divisible by. Example entering 12, should output 6, 4, 3, 2 and 1. Tip: use modulo and a loop.
             Write the program code that outputs the 3 first perfect numbers. A perfect number is a number 
            where all its positive divisors sums up to the actual number. The first number is 6, where 3 + 2 + 1 = 
            6 and the second is 28, where 14 + 7 + 4 + 2 + 1 = 28. Tip: look at the previous exercise and build 
            on top of it. */

            WriteLine(String.Join(", ", IsDividableBy(Program.AskUserForInt("Enter a number: "))));

            
            var testNumber = 1;
            Dictionary<int, List<int>> perfectNumbers = new();

            while (perfectNumbers.Count < 4)
            {
                if(testNumber == IsDividableBy(testNumber).Sum())
                    perfectNumbers.Add(testNumber, IsDividableBy(testNumber));
                
                testNumber++;
            }

            var counter = 1;
            foreach (var item in perfectNumbers)
                WriteLine($"The {Program.OrdinalSuffix(counter++)} perfect number is {item.Key} ({string.Join(" + ", item.Value.Reverse<int>()) + " = " + item.Key})");

            List<int> IsDividableBy(int n)
            {
                List<int> list = new();
                for (int i = n - 1; i > 0; i--)
                    if (n % i == 0)
                        list.Add(i);
                
                return list;
            }
        }
        
        static void Ex16()
        {
            /* Write a program that asks the user for a number. Use this number to output the Fibonacci series up 
            until that number. Entering 10 should then output: 0, 1, 1, 2, 3, 5, 8, 13, 21 and 34. */

            List<int> output = new(new int[] {0,1});
            int steps = Program.AskUserForInt("Enter the number of steps to calculate in the Fibonacci sequence: ");
            for (int i = 1; i <= steps - 2; i++) // allready pre-calculated the first two
                output.Add(output[i - 1] + output[i]);

            if (steps < 2)
                output.RemoveAt(1);
            if (steps < 1)
                output.RemoveAt(0);
            
            WriteLine(String.Join(", ", output));
        }
        
        static void Ex17()
        {
            /* Let the user input a string, then check if the string is a palindrome sentence. A palindrome is a word 
            or sentence that reads the same in both directions. Example of palindrome sentences are Loops at a 
            spool, wet stew and level. However, the spaces might look different depending on which direction you read 
            it, so these should be excluded in your calculations, and a tip is to use some string manipulation to remove 
            them */

            string input = Program.AskUserForString("Test if sentance is a palindrome: ");
            string testString = input.ToUpper().Replace(" ", "");

            if (testString == String.Join("", testString.Reverse().ToArray())) // not very nice ):
                WriteLine($"'{input}' is a palindrome!");
            else
                WriteLine($"'{input}' is not a palindrome!");
        }

        static void Ex18()
        {
            /* Create a new empty integer array of 10 elements. Loop through the array and assign each element 
            to a new random value.
            Create a new empty array of doubles, having the same size as the previous array. Loop through that array 
            and assign the values to 1 divided by the value on the same position of the previous array. So if the first 
            array has the value 42 on position 3, the second array should hold the double value 1 / 42.
            Finally, loop through both arrays and output the values to the screen using a foreach-loop. */

            var arraySize = 10;
            var rand = new Random();
            var ints = new int[arraySize];
            var doubles = new double[arraySize];

            for (int i = 0; i < ints.Length; i++)
                ints[i] = rand.Next();

            for(int i = 0; i < ints.Length; i++)
                doubles[i] = 1.0 / ints[i];

            for (int i = 0; i < ints.Length; i++) // not doing a single foreach ... too tricky to access both arrays!
                WriteLine($"1 / {ints[i]} = {doubles[i]}");
        }

        static void Ex19()
        {
            /* Create a program that outputs a price that the 
            customer (user) needs to pay. This should be an
            integer value. Then let the user input the sum he hands 
            the cashier. 
            Let your program then calculate the change that the 
            customer should get back in different coin unit. For 
            example, if the user hands the cashier 500 kr. and the 
            price is 376 kr., the change will be 124. This can be 
            divided up into 100x1 kr. + 20x1 kr. + 4x1 kr.
            The goal here is to get as few coins as possible. */

            Dictionary<int, int> StoreMoneyBag = new();
            Random rand = new();

            foreach (int type in new int[] { 1000, 500, 100, 50, 20, 10, 5, 1 })
                StoreMoneyBag.Add(type, rand.Next(10));

            WriteLine($"Available money in store: {GetMoneyString(StoreMoneyBag)} ");

            int pay = Program.AskUserForInt("Money to pay: ");
            bool transactionComplete = false;
            do
            {
                int paid = Program.AskUserForInt("Paid: ");
                int toBeReturnedSum = paid - pay;

                // Add paid money
                var PaidMoneyBag = SumToMoneyBag(ref paid);
                WriteLine($"Received : {GetMoneyString(PaidMoneyBag)} ");

                // Add the paid money to the store
                DoMoneyTransaction(PaidMoneyBag, StoreMoneyBag);
                WriteLine($"Available money in store: {GetMoneyString(StoreMoneyBag)} ");

                WriteLine($"Sum to be returned: {toBeReturnedSum}");
                var toBeReturnedMoneyBag = SumToMoneyBag(ref toBeReturnedSum, true);
                if (toBeReturnedSum == 0)
                {
                    WriteLine("Return " + GetMoneyString(toBeReturnedMoneyBag));
                    DoMoneyTransaction(toBeReturnedMoneyBag, StoreMoneyBag, true);
                    WriteLine($"Available money in store: {GetMoneyString(StoreMoneyBag)} ");

                    transactionComplete = true;
                    WriteLine("Transaction complete!");
                }
                else
                {
                    WriteLine("Sorry, we don't have enough change!");
                    WriteLine("Just having " + GetMoneyString(toBeReturnedMoneyBag));

                    var missingMoneyBag = SumToMoneyBag(ref toBeReturnedSum);
                    WriteLine(GetMoneyString(missingMoneyBag) + " could not be returned in change so try to pay that much more");

                    // Remove paid money
                    DoMoneyTransaction(PaidMoneyBag, StoreMoneyBag, true);
                    WriteLine("All money returned.");

                    WriteLine($"Available money in store: {GetMoneyString(StoreMoneyBag)} ");
                }
            } while (!transactionComplete);


            void DoMoneyTransaction(Dictionary<int,int> from, Dictionary<int,int> to, bool remove = false)
            {
                int modifier = remove ? -1 : 1;
                foreach(var item in from)
                {
                    if (to.ContainsKey(item.Key))
                        to[item.Key] += item.Value * modifier;
                    else
                        to.Add(item.Key, item.Value * modifier);
                }
            }

            string GetMoneyString(Dictionary<int, int> money)
            {
                System.Text.StringBuilder sb = new();
                int sum = 0;
                foreach (var item in money)
                {
                    sb.Append(item.Value);
                    sb.Append("x");
                    sb.Append(item.Key);
                    sb.Append("kr ");
                    
                    sum+=item.Value * item.Key;
                }
                sb.Append("(");
                sb.Append(sum);
                sb.Append(" kr)");
                return sb.ToString();
            }

            Dictionary<int, int> SumToMoneyBag(ref int amount, bool checkAvailability = false)
            {
                Dictionary<int, int> output = new();

                foreach (var item in StoreMoneyBag)
                {
                    var itemsNeeded = amount / item.Key; // int-div ok
                    if (itemsNeeded > 0)
                    {
                        if(checkAvailability && (itemsNeeded > item.Value))
                        {
                            output.Add(item.Key, item.Value); // use all available
                            amount -= item.Key * item.Value;
                        }
                        else
                        {
                            output.Add(item.Key, itemsNeeded);
                            amount %= item.Key;
                        }
                    }
                }

                return output;
            }
        }

        static void Ex20()
        {
            /* Create two arrays with arbitrary size and fill one with random numbers. Then copy over the numbers 
            from the array with random numbers so that the even numbers are located in the rear (the right 
            side) part of the array and the odd numbers are located in the front part (the left side). */

            int numbers = 20;
            int[] rndNums = new int[numbers];
            int[] srtNums = new int[numbers];
            Random R = new();

            for (int i = 0; i < numbers; i++)
                rndNums[i] = R.Next(10);

            WriteLine(string.Join(",", rndNums));

            var LPos = 0;
            var RPos = numbers;

            for(int i = 0; i < numbers; i++)
                if (rndNums[i] % 2 == 0)
                    srtNums[--RPos] = rndNums[i];
                else
                    srtNums[LPos++] = rndNums[i];

            WriteLine(string.Join(",", srtNums));
        }
        
        static void Ex21()
        {
            /* Let the user input a string with numbers comma separated like “1,2,34,83,19,45”. Create the code to 
            separate the numbers in the string into an array and find the min, max and average value. Print these 
            out to the screen.  */

            var str = Program.AskUserForString("Enter a comma-delimited list of integers: ");
            var numsStrings = str.Replace(" ", "").Split(",");

            var min = int.MaxValue;
            var max = int.MinValue;
            var sum = 0;
            var validCount = 0;

            foreach(string s in numsStrings)
            {
                if (int.TryParse(s, out int val))
                {
                    validCount++;
                    sum += val;
                    if(val < min)
                        min = val;
                    if(val > max)
                        max = val;
                }
            }

            WriteLine($"MIN: {min} MAX: {max} AVG: {(decimal)sum/validCount}");

            var invalidCount = numsStrings.Length - validCount;
            if (invalidCount == 1)
                WriteLine($"NOTE: that a number has been ignored due to not beeing an integer");
            else if(invalidCount > 1)
                WriteLine($"NOTE: that {invalidCount} numbers have been ignored due to not beeing integers");
        }
       
        static void Ex22()
        {
            /* The company See sharp AB have discovered that the users on their forums use a very harsh 
            language when interacting with each other. So now they have asked you to write a swear word filter 
            to censor these occurring words. Before implementing this filter on their website, they want a demonstration 
            in form of a console program. 
            The program should ask the user for a textual input. Then it should check for all occurrences of swear words. 
            Store the swear words in an array and check the textual input against the array and use string manipulation 
            to replace all swear words with something more appropriate. */

            // Give me a list of harsh words and I do it ... but until then I do it for colors

            List<string> HarshWords = new(new string[] { "blue", "green", "red", "black", "white", "gray" });

            // can't use simple string.replace() ... i.e "I'm bored!" becomes "I'm bo***!"
            var words = Program.AskUserForString("Enter a text with harsh colors: ").Split(" ");
            for (int i = 0; i < words.Length; i++)
                if (HarshWords.Contains(words[i].ToLower()))
                    words[i] = global::Microsoft.VisualBasic.Strings.Space(words[i].Length).Replace(" ", "*");

            WriteLine(string.Join(" ", words));
        }

        static void Ex23()
        {
            /* Create a program that generates 7 unique numbers into an array. The numbers should be between 1 
            and 40. Each of the numbers may only appear once in the array! The numbers should be generated 
            using the Random-class, and should be different each time you run the program. */

            Random rnd = new();
            List<int> uniqueInts = new();
            var test = 0;

            for(var i=0; i<7; i++)
            {
                do
                {
                    test = rnd.Next(10) + 1; // using smaller numbers
                } while (uniqueInts.Contains(test));

                uniqueInts.Add(test);
            }
            uniqueInts.Sort();
            WriteLine(String.Join(", ", uniqueInts));
        }

        static void Ex24()
        {
            /* Create a program that can shuffle a deck of cards. The cards can be represented as an array of 
            integers, like [1,1,1,1,2,2,2,2,3,3,…n]. Then make it possible to draw 1 card from the deck and add to 
            another array. (The card should then disappear from the card deck and appear in the array with the drawn 
            cards. Tip: You can use Array.Resize( ref array, newSize) to change the size of an existing array, and 
            Array.Copy. There is however not a requirement that the array needs to be in a specific order after a card 
            has been drawn. Complete the functions below. */

            // Just playing around ... not finished yet.

            Board gameBoard = new(CardinalDirection.North);
            Deck deckOfCards = new();
            WriteLine("Deck\t" + String.Join(" ", deckOfCards.CardShortNames()));

            deckOfCards.Shuffle();
            WriteLine("Shuffle\t" + String.Join(" ", deckOfCards.CardShortNames()));

            gameBoard.DealCards(deckOfCards);
            gameBoard.Hands.North.Sort();

            WriteDeckInfo(CardinalDirection.North);
            WriteDeckInfo(CardinalDirection.East);
            WriteDeckInfo(CardinalDirection.South);
            WriteDeckInfo(CardinalDirection.West);



            void WriteDeckInfo(CardinalDirection player)
            {
                var hand = gameBoard.Hands.Hand(player);
                WriteLine($"{player.ToString()}\t{String.Join("", hand.CardShortNames())}  HP {hand.HP} {hand.DistributionType}");
            }
        
        }

        static void Ex25()
        {
            /* Create a separate function (from the exercise method) that asks the user to input a valid 
            integer value. The function should keep executing until the user has inputted a valid integer 
            value. Use a Try-catch combined with a while-loop. If the user inputs a none-valid number, display 
            an error asking him/her to try again. 
            Then in the exercise method, call the method you just wrote twice to retrieve 2 integers from the 
            user and store them in variables. Then divide one of the number with the other and use a try-catch 
            to catch any potential division by zero. Display the result to the screen. */

            int num1 = Program.AskUserForInt("Enter an Integer: ");
            int num2 = Program.AskUserForInt("Enter a second Integer: ");

            try
            {
                WriteLine($"{num1} / {num2} = {(Decimal)num1 / num2}"); // I would never use a try/catch to handle a division by zero (it's expected ... and exceptions should never be expected)
            }
            catch (DivideByZeroException DbzEx)
            {
                WriteLine($"{num1} / {num2} = DivByZeroException '{DbzEx.Message}'");
            }
            catch (Exception ex)
            {
                WriteLine($"{num1} / {num2} = OtherException '{ex.Message}'");
            }
        }

        static void Ex26()
        {
            /* In this exercise, you are going to print out the folder path to some different locations on 
            your computer. These can be found in the Enviroment-class. To print one of the common 
            folders on your computer, you can use the Enviroment.GetFolderPath, passing it one of the values 
            from the Enviroment.SpecialFolder enumeration. 
            For example Enviroment.GetFolderPath(Enviroment.SpecialFolder.Desktop) will give back a string 
            representing the folder path to the desktop.
            Print out the following locations on your computer:
             My documents
             My Pictures
             Program files (x86)
             The folder containing information about cookies
             Current Directory (found inside in the Enviroment class)
            In the same method, create a new file on the desktop, using File.Create(filepath), by retrieving the 
            folder path to the desktop and append the filename at the end of the file path. When creating a 
            new file using File.Create, a new FileStream will be created, and this must be closed using the 
            Close method. Note: Depending on which computer you are running your application, some 
            special folders might not exist. */

            string? commandLine = string.Empty;
            var exit = false;

            WriteLine($"{Environment.OSVersion}");
            WriteLine($"For information on available commands, type HELP");
            
            do
            {
                Write(Environment.CurrentDirectory + ">");
                commandLine = ReadLine();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    var commandParts = commandLine.Split(" ");
                    switch (commandParts[0].ToUpper())
                    {
                        case "EXIT":
                            exit = true;
                            break;
                        case "DIR":
                            int pos = Environment.CurrentDirectory.Length;
                            foreach (string item in Directory.GetDirectories(Environment.CurrentDirectory))
                                WriteLine("<DIR>\t" + item.Substring(pos));

                            foreach (string item in Directory.GetFiles(Environment.CurrentDirectory))
                                WriteLine("\t" + item.Substring(pos));

                            break;
                        case "CD":
                            
                            if (commandParts.Length > 1 && !string.IsNullOrEmpty(commandParts[1]))
                            {
                                string dir = string.Empty;
                                if (commandParts[1].StartsWith("@"))
                                {
                                    if (Enum.TryParse<Environment.SpecialFolder>(commandParts[1].Substring(1).TrimEnd(), true, out var enumValue))
                                        dir = Environment.GetFolderPath(enumValue);
                                    else
                                        WriteLine("No such special folder could be found");
                                }
                                else
                                    dir = commandParts[1].Trim();
                                
                                if (Directory.Exists(dir))
                                    Directory.SetCurrentDirectory(dir);
                                else
                                    WriteLine("The path could not be found.");
                            }

                            break;
                        case "MKTEXT":
                            if (commandParts.Length > 1)
                            {
                                var txtfile = commandParts[1].Trim();
                                if (!txtfile.ToLower().EndsWith(".txt"))
                                    txtfile += ".txt";

                                if (File.Exists(txtfile))
                                    WriteLine("That file name allready exists.");
                                else
                                {
                                    using (StreamWriter sw = File.CreateText(txtfile))
                                        sw.WriteLine("Test file ...");

                                    WriteLine($"{txtfile} was created in directory {Environment.CurrentDirectory}.");
                                }
                            }
                            break;
                        case "HELP":
                            WriteLine("CD\tChanges the current directory (or @[special-folder], i.e. @Desktop or @MyDocuments).\n" +
                                      "DIR\tDisplays a list of files and subdirectories in a directory.\n" +
                                      "EXIT\tQuits exercise no 26.\n" +
                                      "HELP\tProvides help information.\n" +
                                      "MKTEXT\tCreates a text file in the current directort.");
                            break;
                        default:
                            WriteLine($"'{commandParts[0]}' is not recognized as an internal or external command, operable program or batch file.");
                            break;
                    }
                }
            }
            while (!exit);

            WriteLine($"Bye ...");
        }

        static void Ex27()
        {
            /* Inside your project in Visual Studio, right-click on your project 
            and add a new text file. Open the file and add at least 10 names 
            on one row each. Right click on the file and hit Properties. In the 
            Properties window, make sure that Copy to Output Directory is set to 
            Copy Always. This will make sure that the files are copied to the binfolder when your program is compiled (see figure 5). 
            Now, use a StreamReader object (found inside System.IO) to read the 
            names from the file and output them to the console window. */

            var file = AppDomain.CurrentDomain.BaseDirectory + "TextFile1.txt";
            if (File.Exists(file))
            {
                using (var sr = new StreamReader(file))
                    while (!sr.EndOfStream)
                        WriteLine(sr.ReadLine());
            }
            else
                WriteLine($"Could not find the file {file}.");
        }

        static void Ex28()
        {
            /* In the exercise method, create 2 new string arrays containing 5 
            names each. 
            Create a new StreamWriter-object passing the file path to the file you 
            created on the desktop in the previous exercise using the 
            Enviroment-class. If you have not completed the previous task, 
            manually create a new text file on your desktop. 
            Write the 5 names from one of the arrays to the file on one row each
            using a StreamWriter-object. Finally close the StreamWriter.
            Create a new StreamWriter-object, passing the file path as previous 
            step, but this time provide the StreamWriter-constructor with the 
            second bool parameter set as true. If this is set to true, the writer will 
            append any text written instead of overwriting all the content. Now, 
            write the 5 names from the second array on one line each. 
            Remember to close the StreamWriter.
            Verify that all 10 names are located in the file. Try setting the second 
            parameter to false in the second StreamWriter and verify that only 
            the last 5 names are present. */

            string[] array1 = new string[] { "Adam", "Bertil", "Cesar", "David", "Erik" };
            string[] array2 = new string[] { "Fredrik", "Gustav", "Harald", "Ingvar", "Johan" };

            var file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\exercise26.txt";
            if (File.Exists(file))
            {
                WriteLine("File content before using StreamWriter:");
                Write(File.ReadAllText(file));
                WriteLine("-eof-\n");

                using (var sw = new StreamWriter(file))
                {
                    foreach (string item in array1)
                        sw.WriteLine(item);
                }
                using (var sw = new StreamWriter(file, true))
                {
                    foreach (string item in array2)
                        sw.WriteLine(item);
                }

                WriteLine("File content after using StreamWriter:");
                Write(File.ReadAllText(file));
                WriteLine("-eof-\n");
            }
            else
                WriteLine($"Could not find the file {file}.\nPlease create it using exercise 26.");

        }




        static string OrdinalSuffix(int number)
        {
            return number.ToString() + number switch
            {
                11 => "th",
                12 => "th",
                13 => "th",
                _ => (number % 10) switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                }
            };
        }

        static string AskUserForString(string msg)
        {
            Write(msg);
            return ReadLine() ?? "";
        }
        static int AskUserForInt(string msg)
        {
            while (true)
            {
                Write(msg);
                if (int.TryParse(ReadLine(), out int val))
                    return val;

                WriteLine("Not a valid Integer, please try again ...");
            }
        }

        static double AskUserForDouble(string msg)
        {
            while (true)
            {
                Write(msg);
                if (double.TryParse(ReadLine(), out double val))
                    return val;

                WriteLine("Not a valid Double, please try again ...");
            }
        }

        static decimal AskUserForDecimal(string msg)
        {
            while (true)
            {
                Write(msg);
                if (decimal.TryParse(ReadLine(), out decimal val))
                    return val;

                WriteLine("Not a valid Decimal, please try again ...");
            }
        }

    }

}
