using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("***** Fun with Basic Data Types *****");
        // LocalVarDeclarations();
        // DefaultDeclarations();
        // NewingDataTypes();
        // NewingDataTypeWith9();
        // ObjectFunctionality();
        // DataTypeFunctionality();
        // CharFunctionality();
        // ParseFromStrings();
        // ParseFromStringsWithTryParse();
        // UseDatesAndTimes();
        // BinaryLiterals();
        // DigitSeparators();

        


        static void DigitSeparators()
        {
            Console.WriteLine("=> Use Digit Separators:");
            Console.Write("Integer:");
            Console.WriteLine(123_456);
            Console.Write("Long:");
            Console.WriteLine(123_456_789L);
            Console.Write("Float:");
            Console.WriteLine(123_456.1234F);
            Console.Write("Double:");
            Console.WriteLine(123_456.12);
            Console.Write("Decimal:");
            Console.WriteLine(123_456.12M);
            //Updated in 7.2, Hex can begin with _
            Console.Write("Hex:");
            Console.WriteLine(0x_00_00_FF);
        }

        static void BinaryLiterals()
        {
            //Updated in 7.2, Binary can begin with _
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}",0b_0001_0000);
            Console.WriteLine("Thirty Two: {0}",0b_0010_0000);
            Console.WriteLine("Sixty Four: {0}",0b_0100_0000);
            }


        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times:");

            DateTime dt = new DateTime(2015, 10, 17);
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());

            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));

            DateOnly d = new DateOnly(2021, 07, 21);
            System.Console.WriteLine(d);

            TimeOnly t = new TimeOnly(13,30,0,0);
            System.Console.WriteLine(t);

        }

        static void ParseFromStringsWithTryParse()
        {
            Console.WriteLine("=> Data type parsing with TryParse");
            if (bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b: {0}", b);
            }
            else
            {
                Console.WriteLine("Default value of b: {0}", b);
            }

            string value = "Hello";
            if (double.TryParse(value, out double d))
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double and the variable was assigned the default {1}", value, d);
            }
            Console.WriteLine();
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            Console.WriteLine();

        }

        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }

        static void DataTypeFunctionality()
        {
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinitu: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeIfinity: {0}", double.NegativeInfinity);
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine();
        }

        static void ObjectFunctionality()
        {
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 23.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }
        static void NewingDataTypeWith9()
        {
            Console.WriteLine("=> Using new to create variables");
            bool b = new();
            int i = new();
            double d = new();
            DateTime dt = new();

            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool();
            int i = new int();
            double d = new double();
            DateTime dt = new DateTime();
            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
        }

        static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Data Declarations:");
            int myInt = 0;
            string myString;
            myString = "This is my character data";

            bool b1 = true, b2 = false, b3 = b1;
            Console.WriteLine("Your data: {0}, {1}, {2}, {3}, {4}", myInt, myString, b1, b2, b3);

            Console.WriteLine();
        }
        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations:");
            int myInt = default;
            Console.WriteLine(myInt);
        }
    }
}