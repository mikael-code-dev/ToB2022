
var isRunning = true;
var isValidSelection = false;
int userInput = -1;

while (isRunning)
{
    Console.WriteLine("Welcome to this program. Please use the menu:\n");
    RunMenuUI();
    Console.Write("\nSelect from the menu\n:> ");

    isValidSelection = false;
    while (!isValidSelection)
    {
        if (int.TryParse(Console.ReadLine(), out userInput))
        {
            if (userInput < 0 || userInput > 16)
            {
                Console.WriteLine("You must select 0-16. Try again");

            }
            else
            {
                isValidSelection = true;
            }
        }
        else
        {
            Console.WriteLine("Invalid input, try again!");
        }
    }

    Console.Clear();
    switch (userInput)
    {
        case 0:
            isRunning = false;
            break;
        case 1:
            RunHelloWorld();
            break;
        case 2:
            PersonalDetails();
            break;
        case 3:
            ChangeTextColor();
            break;
        case 4:
            DisplayTodaysDate();
            break;
        case 5:
            BiggestNumber();
            break;
        case 6:
            GuessTheNumber();
            break;
        case 7:
            WriteToFile();
            break;
        case 8:
            ReadFile();
            break;
        case 9:
            MathOnDecimalNumber();
            break;
        case 10:
            MultiplicationTable();
            break;
        case 11:
            ArraySort();
            break;
        case 12:
            Palindrom();
            break;
        case 13:
            NumbersBetweenUI();
            break;
        case 14:
            OddsAndEven();
            break;
        case 15:
            AddNumbers();
            break;
        case 16:
            GameCharacters();
            break;

        default:
            Console.WriteLine("Something went wrong try again or restart the program");
            break;
    }

    if (isRunning && userInput != 3)
    {
        Console.WriteLine("\nPress any key to continue . . .");
        Console.ReadKey();
        Console.Clear();
    }
}

Console.WriteLine("\n\nYou have stopped the program.\n\n");


// **** METHODS ****
// *****************
static void RunMenuUI()
{
    Console.WriteLine("  0. Exit the program");
    Console.WriteLine("  1. Run Hello World");
    Console.WriteLine("  2. Enter your personal details");
    Console.WriteLine("  3. Change text color");
    Console.WriteLine("  4. Todays date");
    Console.WriteLine("  5. Biggest number");
    Console.WriteLine("  6. Guess the number");
    Console.WriteLine("  7. Write to file");
    Console.WriteLine("  8. Read from file");
    Console.WriteLine("  9. Mathematical operations on a decimal number");
    Console.WriteLine(" 10. Multiplication table");
    Console.WriteLine(" 11. Sort the numbers from an array");
    Console.WriteLine(" 12. Check if word is palindrom");
    Console.WriteLine(" 13. Numbers between numbers");
    Console.WriteLine(" 14. Odd and Even numbers sorted");
    Console.WriteLine(" 15. Add your numbers");
    Console.WriteLine(" 16. The Game characters");
}

static void RunHelloWorld()
{
    Console.WriteLine("\n\n\n\t\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC");
    Console.WriteLine("\tHello World!");
    Console.WriteLine("\t\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\x25B2\x25BC\n\n");
}

static void PersonalDetails()
{
    string? firstName;
    string? lastName;
    int age = 0;
    var ageIsValid = false;

    Console.Write("Enter your first name :> ");
    firstName = Console.ReadLine();
    Console.Write("Enter your last name :> ");
    lastName = Console.ReadLine();
    Console.Write("Enter your age :> ");

    while (!ageIsValid)
    {
        if (int.TryParse(Console.ReadLine(), out age))
        {
            if (age < 1)
            {
                Console.WriteLine("You have to be older, try again!");
            }
            else
            {
                ageIsValid = true;
            }
        }
        else
        {
            Console.WriteLine("Invalid input, try again!");
        }
    }

    Console.Clear();
    Console.WriteLine($"Your name is {firstName} {lastName}, your are {age} years old.");
}

static void ChangeTextColor()
{
    if (Console.ForegroundColor == ConsoleColor.Gray)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

static void DisplayTodaysDate()
{
    Console.WriteLine($"Todays date: {DateTime.Now.Day}");
}

static double GetDoubleNumInput(string prompt)
{
    double number;

    Console.Write(prompt);

    while (true)
    {
        if (double.TryParse(Console.ReadLine(), out number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Invalid input, try again!");
            Console.Write(prompt);
        }
    }
}

static void BiggestNumber()
{
    var numOne = GetDoubleNumInput("Give me a number\n:> ");
    var numTwo = GetDoubleNumInput("Give me another number\n:> ");

    if (numOne == numTwo)
    {
        Console.WriteLine($"You entered the same number: {numOne}. They are equal");
    }
    else if (numOne > numTwo)
    {
        Console.Clear();
        Console.WriteLine($"{numOne} is bigger than {numTwo}");
    }
    else
    {
        Console.Clear();
        Console.WriteLine($"{numTwo} is bigger than {numOne}");
    }
}

static void GuessTheNumber()
{
    var shouldRun = true;
    Random rand = new Random();
    int generatedNumber = rand.Next(1, 101);
    var guessCounter = 0;

    Console.WriteLine("Guess the number between 1 and 100 (including 1 and 100)");
    Console.Write(":> ");

    while (shouldRun)
    {
        guessCounter++;

        if (int.TryParse(Console.ReadLine(), out int theGuess) && theGuess < 101 && theGuess > 0)
        {
            if (theGuess == generatedNumber)
            {
                Console.WriteLine($"\nYou guessed right. It is number {theGuess}. You had to guess {guessCounter} time(s)");
                shouldRun = false;
            }
            else if (theGuess < generatedNumber)
            {
                Console.Write($"Guess No {guessCounter}:\t {theGuess} is too low. Guess again :> ");
            }
            else if (theGuess > generatedNumber)
            {
                Console.Write($"Guess No {guessCounter}:\t {theGuess} is too high. Guess again :> ");
            }
        }
        else
        {
            guessCounter--;
            Console.WriteLine("Invalid input, enter a number 1 - 100. Try again!");
            Console.Write(":> ");
        }
    }
}

static void SaveFile(string? input)
{
    using (StreamWriter writer = new("userData.txt", true))
    {
        writer.WriteLine(input);
    }
}

static void WriteToFile()
{
    Console.WriteLine("Write a few words to save in a file");
    Console.Write(":> ");
    string? userInput = Console.ReadLine();

    SaveFile(userInput);
}

static IEnumerable<string> ReadFromFile(string fileName)
{
    using (StreamReader read = new(File.Open(fileName, FileMode.OpenOrCreate)))
    {
        yield return read.ReadToEnd();
    }
}

static void ReadFile()
{
    Console.WriteLine("This is the info from the file:\n");

    foreach(string textLine in ReadFromFile("userData.txt"))
    {
        Console.WriteLine(textLine);
    }
}

static void MathOnDecimalNumber()
{
    double decimalNumInput;
    double squareRoot;
    double numPowerTwo;
    double numPowerTen;

    Console.WriteLine("Enter a number (can be a decimal number)");
    Console.Write(":> ");

    while(!double.TryParse(Console.ReadLine(), out decimalNumInput))
    {
        Console.WriteLine("You must write a numeric number. Try again!");
        Console.Write(":> ");
    }

    if (decimalNumInput < 0)
    {
        squareRoot = Math.Sqrt(Math.Abs(decimalNumInput));
        Console.WriteLine($"The Square root is: \t{squareRoot}i");
    }
    else
    {
        squareRoot = Math.Sqrt(decimalNumInput);
        Console.WriteLine($"The Square root is: \t{squareRoot}");
    }

    numPowerTwo = Math.Pow(decimalNumInput, 2);
    numPowerTen = Math.Pow(decimalNumInput, 10);

    Console.WriteLine($"To the Power of 2: \t{numPowerTwo}");
    Console.WriteLine($"To the Power of 10: \t{numPowerTen}");
}

static void MultiplicationTable()
{
    Console.WriteLine();
    for(var i = 1; i <= 10; i++)
    {
        Console.Write($" {i}:");
        for (var j = 1; j <= 10; j++)
        {
            Console.Write($"\t{i}*{j}={i * j}");
        }
        Console.Write("\n\n");
    }
}

static void MyArraySort(int[] arr, int startIndex, int lastIndex)
{
    int x = startIndex;
    int y = lastIndex;
    var controlPoint = arr[(x + y) / 2];

    while(x <= y)
    {
        while (arr[x] < controlPoint)
        {
            x++;
        }

        while (arr[y] > controlPoint)
        {
            y--;
        }

        if (x <= y)
        {
            var temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;

            x++;
            y--;
        }
    }

    if (startIndex < y)
    {
        MyArraySort(arr, startIndex, y);
    }

    if (x < lastIndex)
    {
        MyArraySort(arr, x, lastIndex);
    }
}

static void ArraySort()
{
    var arraySize = 12;
    var min = 40;
    var max = 80;

    // Backup for easy solution. But with risk for duplicate numbers.
    //int[] arrWithRandomNums = Enumerable.Repeat(0, 12).Select(i => GetRandomNum(min, max)).ToArray();

    var arrWithRandomNums = new int[arraySize];

    // I decide that I don't want duplicates
    HashSet<int> nonDupesCollection = new();
    while (nonDupesCollection.Count < 12)
    {
        // Using method from other task to generate random number (integer).
        nonDupesCollection.Add(GetRandomNum(min, max));
    }

    arrWithRandomNums = nonDupesCollection.ToArray();

    int[] arrSorted = new int[arraySize];
    for (var i = 0; i < arrSorted.Length; i++)
    {
        arrSorted[i] = arrWithRandomNums[i];
    }

    MyArraySort(arrSorted, 0, arrSorted.Length - 1);

    // Now we have two separate arrays. One with the random numbers
    // and one with the numbers sorted.
    // Now print them:
    Console.WriteLine(" Unsorted array:\t\tSorted array:");
    for (var i = 0; i < arrWithRandomNums.Length -1; i++)
    {
        Console.WriteLine($"\t{arrWithRandomNums[i]}\t\t\t     {arrSorted[i]}");
    }
}

static bool CheckIfPalindrome(string word)
{
    return word.SequenceEqual(word.Reverse());
}

static void Palindrom()
{
    Console.WriteLine("Give me a word and I will check if it is a palindrome (will ignore letter case)");
    Console.Write(":> ");
    if (CheckIfPalindrome(Console.ReadLine().ToLower()))
    {
        Console.WriteLine("Yes it's a palindrome!");
    }
    else
    {
        Console.WriteLine("No, it's not a palindrome!");
    }
}

static int GetUserinputInt()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.Write("INVALID INPUT! Try again :>");
    }

    return number;
}

static void PrintNumInterval(int num1, int num2)
{
    if (Math.Abs(num1 - num2) > 30 || Math.Abs(num2 - num1) > 30)
    {
        Console.Write("The intervall is big (many numbers), Print anyway? j for YES, n for NO :> ");
        var choiceInput = Console.ReadLine();
        while (choiceInput != "j" ^ choiceInput == "n")
        {
            Console.Write("Invalid input, try again. Only 'j' or 'n' works :>");
            choiceInput = Console.ReadLine();
        }

        if (choiceInput != "j")
        {
            return;
        }
    }
    
    if (num1 == num2)
    {
        Console.WriteLine("The numbers are equal. You shuld try again.");
        Console.WriteLine("Try again? press 'j'. Any other key to skip.");
        var input = Console.ReadLine();
        if (input == "j")
        {
            NumbersBetweenUI();
            return;
        }
        else
        {
            return;
        }
    }
    
    if (Math.Abs(num1 - num2) < 2)
    {
        Console.WriteLine("There is no intervall between your numbers. Try again.");
    }
    else if (num1 < num2)
    {
        Console.WriteLine($"The numbers between {num1} and {num2} are:");
        for (var i = num1; i < num2 - 1; i++)
        {
            Console.Write($"{i + 1} ");
        }
    }
    else
    {
        Console.WriteLine($"The numbers between {num2} and {num1} are:");
        for (var i = num2; i < num1 - 1; i++)
        {
            Console.Write($"{i + 1} ");
        }
    }
}

static void NumbersBetweenUI()
{
    Console.Write("Write a number (integer) :> ");
    var num1 = GetUserinputInt();
    Console.Write("Write a number (integer) :> ");
    var num2 = GetUserinputInt();

    PrintNumInterval(num1, num2);

    Console.WriteLine();
}

static IEnumerable<int> ReturnEvenNums(IEnumerable<int> numbers)
{
    foreach (var num in numbers)
    {
        if (num % 2 == 0)
        {
            yield return num;
        }
    }
}

static IEnumerable<int> ReturnOddNums(IEnumerable<int> numbers)
{
    foreach (var num in numbers)
    {
        if (num % 2 != 0)
        {
            yield return num;
        }
    }
}

static void OddsAndEven()
{
    Console.WriteLine("Enter numbers and separate them with comma (,):");
    var userInput = Console.ReadLine().Split(',').ToList();
    List<int> numbers = new();

    foreach (var num in userInput)
    {
        try
        {
            numbers.Add(int.Parse(num));
        }
        catch
        {
            Console.WriteLine("Error, task aborted - Try again!");
            return;
        }
    }

    var evenNums = ReturnEvenNums(numbers);
    Console.WriteLine("\nEven numbers:");
    if (evenNums.Count() > 0)
    {
        foreach (var num in evenNums)
        {
            Console.Write($"{num} ");
        }
    }
    else
    {
        Console.WriteLine("No even numbers entered");
    }

    Console.WriteLine("\n");

    var oddNums = ReturnOddNums(numbers);
    Console.WriteLine("Odd numbers:");
    if (oddNums.Count() > 0)
    {
        foreach (var num in oddNums)
        {
            Console.Write($"{num} ");
        }
    }
    else
    {
        Console.WriteLine("No odd numbers entered");
    }

    Console.WriteLine();
}

static void AddNumbers()
{
    Console.WriteLine("Enter comma (,) separated numbers and they will be added.");
    Console.Write(":> ");
    List<int> inputNums = new();
    int endNum = 0;

    try
    {
        inputNums = Console.ReadLine().Split(',').Select(int.Parse).ToList();
    }
    catch
    {
        Console.WriteLine("Invalid input. This will be aborted. Try again!");
        return;
    }

    if (inputNums.Count() > 1)
    {
        foreach (var num in inputNums)
        {
            endNum += num;
        }

        Console.Write("\nAdding numbers");
        for (int i = 0; i < 15; i++)
        {
            Thread.Sleep(100);
            Console.Write(".");
        }
        Console.WriteLine();

        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine($"Your entered numbers added: {endNum}");
    }
    else
    {
        Console.WriteLine($"You only entered one number. Adding {inputNums[0]} with nothing is: {inputNums[0]}");
    }
    
}

static int GetRandomNum(int min, int max)
{
    Random random = new();
    return random.Next(min, max);
}

static void GameCharacters()
{
    Console.WriteLine("Create your game characters\n");

    Console.WriteLine("Enter your name:");
    Console.Write(":> ");
    var playerName = Console.ReadLine();

    Console.WriteLine("Give a name to your enemy:");
    Console.Write(":> ");
    var enemyName = Console.ReadLine();

    var player = new GameCharacter(playerName, GetRandomNum(1, 101), GetRandomNum(1, 11), GetRandomNum(1, 500));
    var enemy = new GameCharacter(enemyName, GetRandomNum(1, 101), GetRandomNum(1, 11), GetRandomNum(1, 500));

    Console.Clear();

    Console.WriteLine("\nThe Player:");
    player.printUI();
    Console.WriteLine("\nThe Enemy:");
    enemy.printUI();
}

class GameCharacter
{
    public string? Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Luck { get; set; }

    public GameCharacter(string? name, int health, int strength, int luck)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Luck = luck;
    }

    public void printUI()
    {
        Console.SetCursorPosition(2, Console.CursorTop);
        Console.WriteLine(Name);
        Console.SetCursorPosition(4, Console.CursorTop);
        Console.WriteLine($"- Health: {Health}");
        Console.SetCursorPosition(4, Console.CursorTop);
        Console.WriteLine($"- Strength: {Strength}");
        Console.SetCursorPosition(4, Console.CursorTop);
        Console.WriteLine($"- Luck: {Luck}");
    }
}