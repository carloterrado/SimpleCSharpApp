using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

// BasicStringFunctionality();
// StringConcatenation();
// EscapeChars();
// StringInterpolation();
// StringVerbatim();
// StringEquality();
StringEqualitySpecifyingCompareRules();

static void StringEqualitySpecifyingCompareRules()
{
    System.Console.WriteLine("=> String equality Case Insensitive:");
    string s1 = "Hello!";
    string s2 = "HELLO!";
    System.Console.WriteLine("s1 = {0}", s1);
    System.Console.WriteLine("s2 = {0}", s2);
    System.Console.WriteLine();

    System.Console.WriteLine("Default rules: s1={0}, s2={1} s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
    System.Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
    System.Console.WriteLine();

    System.Console.WriteLine("Default rules: s1={0}, s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));
    System.Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
    System.Console.WriteLine("Ignore case, Invariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
    System.Console.WriteLine();
}

static void StringEquality()
{
    System.Console.WriteLine("=> String Equality:");
    string s1 = "Hello!";
    string s2 = "Yo!";
    System.Console.WriteLine("s1 = {0}", s1);
    System.Console.WriteLine("s2 = {0}", s2);
    System.Console.WriteLine();

    System.Console.WriteLine("s1 == s2: {0}", s1 == s2);
    System.Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
    System.Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
    System.Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
    System.Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
    System.Console.WriteLine("Yo!.Equals(s2): {0}", "Yo!".Equals(s2));
    System.Console.WriteLine();
}

static void StringVerbatim()
{
    System.Console.WriteLine(@"C:\MyApp\bin\Debug");
    System.Console.WriteLine(@"
    Hello
        Hello
            Hello
    ");

    System.Console.WriteLine(@"Hello There's a double quote "" inside a double quote");

    string inter = "interpolation";
    SqlString myLongString = $@"
    very
        very
            long
                string
                    {inter}";

    System.Console.WriteLine(myLongString);
                
}

static void StringInterpolation()
{
    System.Console.WriteLine("=> String Interpolation: \a");

    int age = 4;
    string name = "Soren";

    string greeting = string.Format("Hello {0} you are {1} years old.", name,age);
    System.Console.WriteLine(greeting);

    string greeting2 = $"Hello {name} you are {age} years old";
    System.Console.WriteLine(greeting2);

    string greeting3 = string.Format("Hello {0} you are {1} old.", name.ToUpper(), age);
    string greeting4 = $"Hello {name.ToUpper()} you are {age} years old.";
    string greeting5 = $"Hello {name} you are {age} years old.".ToUpper();
    System.Console.WriteLine(greeting3);
    System.Console.WriteLine(greeting4);
    System.Console.WriteLine(greeting5);
}

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