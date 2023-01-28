using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

public class Loops
{

    public void Exercise1()
    {
        var count = 0;
        for (var i = 1; i <= 100; i++)
        {
            if (i % 3 == 0)
                count++;
        }
        Console.WriteLine("There are {0} numbers divisible by 3 between 1 and 100.", count);
    }


    public void Exercise2()
    {
        var sum = 0;
        while (true)
        {
            Console.Write("Enter a number (or 'ok' to exit): ");
            var input = Console.ReadLine();

            if (input.ToLower() == "ok")
                break;

            sum += Convert.ToInt32(input);
        }
        Console.WriteLine("Sum of all numbers is: " + sum);
    }


    public void Exercise3()
    {
        Console.Write("Enter a number: ");
        var number = Convert.ToInt32(Console.ReadLine());

        var factorial = 1;
        for (var i = 1; i <= number; i++)
            factorial *= i;

        Console.WriteLine("{0}! = {1}", number, factorial);
    }

    public void Exercise4()
    {
        var number = new Random().Next(1, 10);

        Console.WriteLine("Secret is " + number);
        for (var i = 0; i < 4; i++)
        {
            Console.Write("Guess the secret number: ");
            var guess = Convert.ToInt32(Console.ReadLine());

            if (guess == number)
            {
                Console.WriteLine("You won!");
                return;
            }
        }

        Console.WriteLine("You lost!");
    }

    public void Exercise5()
    {
        Console.Write("Enter commoa separated numbers: ");
        var input = Console.ReadLine();

        var numbers = input.Split(',');

        // Assume the first number is the max 
        var max = Convert.ToInt32(numbers[0]);

        foreach (var str in numbers)
        {
            var number = Convert.ToInt32(str);
            if (number > max)
                max = number;
        }

        Console.WriteLine("Max is " + max);

    }
}

static void Exercise6()
{
    var names = new List<string>();

    while (true)
    {
        var name = AskForName();

        if (string.IsNullOrEmpty(name))
            break;

        names.Add(name);
        Console.WriteLine(GetLikesMessage(names));
    }
}

private static string AskForName()
{
    Console.WriteLine("Enter a name: (Leave it empty to close the program)");
    return Console.ReadLine();
}

private static string GetLikesMessage(List<string> names)
{
    if (names.Count > 2)
        return names[0] + ", " + names[1] + " and " + GetExtraLikes(names).Count + " liked your post";
    if (names.Count == 2)
        return names[0] + " and " + names[1] + " liked your post";

    return names[0] + " liked your post";
}

private static List<string> GetExtraLikes(List<string> names)
{
    return names.GetRange(2, names.Count - 2);
}
    

        static void Exercise7()
        {
            Console.WriteLine("Enter the name you wish to reverse: ");
            var name = Console.ReadLine();
            var reversedName = GetReversedName(name);

            Console.WriteLine("The name {0} gets reversed to {1}", name, reversedName);
        }

        private static string GetReversedName(string name)
        {
            var list = name.ToList();
            list.Reverse();

            return string.Join("", list.ToArray());
        }
    }
}



public void Exercise8()
{

    var number = new int[5];
    Console.WriteLine("Enter 5 unique numbers");

    for (int i = 0; i < 5; i++)
    {
        while (true)
        {
            var newValue = Convert.ToInt32(Console.ReadLine());
            var currentNumber = Array.IndexOf(number, newValue);
            if (currentNumber == -1)
            {
                number[i] = newValue;
                break;
            }
            Console.WriteLine("Hold on, you already entered that number. Try again.");
        }
    }

    Array.Sort(number);
    Console.WriteLine();

    foreach (var n in number)
        Console.WriteLine(n);

    Console.ReadLine();

}

    
        static void Exercise9()
{


    var numberList = new List<int>();

    int rawNumber;
    bool check;

    do
    {
        var rawEntry = Console.ReadLine();
        check = int.TryParse(rawEntry, out rawNumber);

        if (check == false && rawEntry.ToLowerInvariant() == "quit")
        {
            Console.WriteLine("List contains duplicate values but presented below are only unique numbers:");


            List<int> distinctList = numberList.Distinct().ToList();
            foreach (var element in distinctList)
                Console.WriteLine(element);

            break;

        }
        if (check == false)
            Console.WriteLine("To exit type quit or enter more numbers");

        else
            numberList.Add(rawNumber);

    }
    while (true);
}


namespace ConsoleApp13
{
    internal class Program
    {
        static void Exercise10()
        {

            string[] elements;

            while (true)
            {
                Console.WriteLine("Enter a list of  numbers");
                var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    elements = input.Split(',');
                    if (elements.Length >= 5)
                        break;
                }
                else
                    Console.WriteLine("invalid List  try again");
            }

            var numbers = new List<int>();

            foreach (var number in elements)
            {
                numbers.Add(int.Parse(number));
            }

            var smallests = new List<int>();
            while (smallests.Count < 3)
            {
                var min = numbers[0];
                foreach (var number in numbers)
                {
                    if (number < min)
                        min = number;
                }
                smallests.Add(min);

                numbers.Remove(min);
            }
            Console.WriteLine("Smallest Numbers");
            foreach (var number in smallests)
            {
                Console.WriteLine(number);
            }
        }
    }
}


        static void Exercise11()
        {
            Console.Write("Enter a numbers   ");
            var input = Console.ReadLine();

            var numbers = new List<int>();
            foreach (var number in input.Split('-'))
                numbers.Add(Convert.ToInt32(number));

            numbers.Sort();

            var isConsecutive = true;
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] != numbers[i - 1] + 1)
                {
                    isConsecutive = false;
                    break;
                }
            }

            var message = isConsecutive ? "Consecutive" : "Not Consecutive";
            Console.WriteLine(message);
        }
    
        static void Exercise12()
        {
            Console.WriteLine("Enter a series of numbers separated by '-'");
            var answer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(answer))
                Environment.Exit(0);

            var numbers = answer.Split('-').Select(number => Convert.ToInt32(number)).ToList();

            Console.WriteLine(HasAnyDuplicate(numbers) ? "Has duplicates" : "No duplicates were found");
        }

        private static bool HasAnyDuplicate(List<int> numbers)
        {
            return numbers.GroupBy(number => number).Any(duplicate => duplicate.Count() > 1);
        }
    
static void Exercise13()
{
    Console.WriteLine("enter a time value (eg:19:00, 23:59)");
    var input = Console.ReadLine();
    try
    {
        var hour = Convert.ToInt32(input.Split(':').First());
        var minute = Convert.ToInt32(input.Split(':').Last());

        Console.WriteLine("hour " + hour + " min: " + minute);
        if (hour >= 00 && hour <= 23 && minute >= 00 && minute <= 59)
        {
            Console.WriteLine("ok");
        }
        else
            Console.WriteLine("Invalid Time");

    }
    catch (Exception ex)
    {
        Console.WriteLine("INVALID INPUT");
    }
}
static void Exercise14()
{
    Console.WriteLine("Type in any word/phrase to be converted to PascalCase");
    var input = Console.ReadLine();

    if (String.IsNullOrEmpty(input))
        throw new ArgumentException("Null, whitespaces or empty are not allowed.");

    var words = input.Split(' ')
        .Select(word => word.Trim().ToLower())
        .ToArray();

    Console.WriteLine("PascalCased: " + ConvertToPascalCase(words));
}

private static string ConvertToPascalCase(string[] words)
{
    if (!words.Any())
        throw new ArgumentException("Array or List has no elements.");

    var pascaled = "";
    foreach (var word in words)
        pascaled += CapitalizeFirstLetter(word);

    return pascaled;
}

private static string CapitalizeFirstLetter(string word)
{
    if (String.IsNullOrWhiteSpace(word))
        return string.Empty;

    var letters = word.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);

    return new string(letters);
}

static void Exercise15()
{
    int vCount = 0, cCount = 0;
    string str = "inadequate";
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
        {

            //Increments the vowel counter  
            vCount++;
        }

        //Checks whether a character is a consonant  
        else if (str[i] >= 'a' && str[i] <= 'z')
        {

            //Increments the consonant counter  
            cCount++;
        }
    }
    Console.WriteLine("Number of vowels : " + vCount);
    Console.WriteLine("Number of consonant : " + cCount);
}

//           Console.WriteLine("Question 1 \n");     
//           Console.WriteLine(Question1()); 
//           Console.WriteLine("=============================\n");
//
//           Console.WriteLine(Question2());           
//           Console.WriteLine("=============================\n");
//           
//           Console.WriteLine( Question3(5));        
//           Console.WriteLine("=============================\n");
//
//           Question4();                             
//           Console.WriteLine("=============================\n");  
//
//           Question5();                             
//           Console.WriteLine("=============================\n");
//
//           Question6();
//           Console.WriteLine("=============================\n");   
//
//           Console.WriteLine(Question7()); 
//           Console.WriteLine("=============================\n");
// 
//           Question8();
//           Console.WriteLine("=============================\n");
//
//           Question9();
//           Console.WriteLine("=============================\n");
//
//           Question10();
//           Console.WriteLine("=============================\n");
//
//           Question11();
//           Console.WriteLine("=============================\n"); 
// 
//           Question12();
//           Console.WriteLine("=============================\n"); 
//
//           Question13();
//           Console.WriteLine("=============================\n");
