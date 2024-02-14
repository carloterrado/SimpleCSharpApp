using System;

namespace SimpleCSharpApp
{
    class Program
    {
        static int Main()
        {
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();
           
            ShowEnvironmentDetails();
            Console.ReadLine();
            return -1;
        }

        static void ShowEnvironmentDetails()
        {
            // Print out the drives on this mnachine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".Net Core Version: {0}", Environment.Version);
            Console.WriteLine("Is 64-bit OS: {0}", Environment.Is64BitOperatingSystem);
        }
    }
}



