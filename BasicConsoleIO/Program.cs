Console.WriteLine("***** Basic Console I/O *****");
// GetUserData();

FormatNumericalData();

Console.ReadLine();
static void GetUserData()
{
    System.Console.Write("Please enter your name: ");
    string userName = Console.ReadLine();
    System.Console.Write("Please enter your age: ");
    string userAge = Console.ReadLine();
   

    ConsoleColor prevColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Yellow;

    // System.Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);

    Console.ForegroundColor = prevColor;
}

static void FormatNumericalData()
{
    System.Console.WriteLine("The value 99999 in variou formats:");
    System.Console.WriteLine("c format: {0:c}", 99999);
    System.Console.WriteLine("d9 format: {0:d9}", 99999);
    System.Console.WriteLine("f3 format: {0:f3}", 99999);
    System.Console.WriteLine("n format: {0:n}", 99999);

    System.Console.WriteLine("E format: {0:E}", 99999);
    System.Console.WriteLine("e format: {0:e}", 99999);
    System.Console.WriteLine("X format: {0:X}", 99999);
    System.Console.WriteLine("x format: {0:x}", 99999);
     string userMessage = string.Format("100000 in hex is {0:x}", 100000);
         System.Console.WriteLine(userMessage);
}