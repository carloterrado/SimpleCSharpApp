using System.Runtime.CompilerServices;
using System.Text;

// BasicStringFunctionality();
// StringConcatenation();
EscapeChars();

static void EscapeChars()
{
    System.Console.WriteLine("=> Escape Characters:");
    string strWithTabs = "Model\tColor\tSpeed\tPet Name ";
    System.Console.WriteLine(strWithTabs);


    System.Console.WriteLine("Everyone loves \"Hello world!\" ");
    System.Console.WriteLine("C:\\MyApps\\bin\\Debug ");

    System.Console.WriteLine("All finished.\n\n\n ");
    System.Console.WriteLine();
}

static void StringConcatenation()
{
    System.Console.WriteLine("=> String concatenation:");
    string s1 = "Programming the ";
    string s2 = "PsychoDrill (PTP)";
    string s3 = s1 + s2;
    System.Console.WriteLine(s3);
    System.Console.WriteLine();
}

static void BasicStringFunctionality()
{
    System.Console.WriteLine("=> Basic String functionality:");
    string firstName = "Freddy";
    System.Console.WriteLine("Value of firstName: {0}", firstName);
    System.Console.WriteLine("firstName has {0} characters", firstName.Length);
    System.Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
    System.Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
    System.Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y"));
    System.Console.WriteLine("New first name: {0}", firstName.Replace("dy",""));
    System.Console.WriteLine();
}