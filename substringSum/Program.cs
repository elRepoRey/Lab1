using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mata in en sträng:");
        string? inputStr = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputStr))
        {
            inputStr = "29535123p48723487597645723645";
        }

        try
        {
            SumSubStrings(inputStr!);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    static void SumSubStrings(string inputStr)
    {
        long total = 0;

        for (int i = 0; i < inputStr.Length - 1; i++) // Hämtar den första tecknet
        {
            for (int j = i + 1; j < inputStr.Length; j++) // Hämtar ett andra tecken
            {
                if (inputStr[i] == inputStr[j]) // jämför dem
                {
                    bool isValid = true; // Boolean för att kontrollera giltigheten av delsträngen
                    long subInt = 0;

                    for (int k = i; isValid && k <= j; k++)
                    {
                        if (!char.IsDigit(inputStr[k])) // Ogiltigförklara delsträngen om något tecken inte är en siffra
                        {
                            isValid = false;
                        }

                        /* För att säkerställa att endast den första och sista karaktären i delsträngen är densamma,
                        * kontrollerar detta if-uttryck varje karaktär i delsträngen.
                        * Den ogiltigförklarar de delsträngar där någon mellanliggande karaktär matchar startkaraktären. 
                        */
                        if (k != i && k != j && inputStr[k] == inputStr[i])
                        {
                            isValid = false;
                        }

                        
                        if (isValid) // Beräkna heltalsvärdet för delsträngen
                        {
                            subInt = subInt * 10 + (inputStr[k] - '0');
                        }
                    }

                    if (isValid)
                    {
                        total += subInt;
                        HighlightSubstring(inputStr, i, j);
                    }
                }
            }
        }

        string Total = total.ToString();
        HighlightSubstring($"Total = {Total}", 0, $"Total = {Total}".Length-1);
    }

    static void HighlightSubstring(string inputStr, int start, int end)
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < start; i++)
        {
            Console.Write(inputStr[i]);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = start; i <= end; i++)
        {
            Console.Write(inputStr[i]);
        }

        Console.ForegroundColor = ConsoleColor.White;
        for (int i = end + 1; i < inputStr.Length; i++)
        {
            Console.Write(inputStr[i]);
        }
        Console.WriteLine();
    }
}
