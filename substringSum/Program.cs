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

        SumSubStrings(inputStr!);
    }

    static void SumSubStrings(string inputStr)
    {
        long total = 0;

        for (int i = 0; i < inputStr.Length - 1; i++) // Hämtar den första tecknet
        {

            /* Boolean för att kontrollera om ett matchande tecken har hittats, och avsluta loopen om det stämmer.
            * På detta sätt undviker vi att bygga upp en delsträng som har ett mellantecken som matchar det första tecknet.
            */
            bool firstMatchFound = false;

            // Hämtar ett andra tecken om firstMatchFound är falskt
            for (int j = i + 1; j < inputStr.Length && !firstMatchFound; j++) 
            {
                if (inputStr[i] == inputStr[j]) // jämför tecknen
                {
                    bool isValid = true; // Boolean för att kontrollera att tecknen är siffror
                    long subStrLong = 0; // Long för att lagra delsträngens heltalsvärde


                    for (int k = i; isValid && k <= j; k++)
                    {
                        // Ogiltigförklara icke-siffror
                        if (!char.IsDigit(inputStr[k]))
                        {
                            isValid = false;
                        }

                        // Här byggs delsträngens värde genom att lägga till en siffras värde i taget och konvertera det till en long.
                        if (isValid)
                        {
                            subStrLong = subStrLong * 10 + (inputStr[k] - '0');
                        }
                    }

                    /* Om delsträngen är giltig, sammanfoga den med totalen, färga den och sätt firstMatchFound
                     till true för att avsluta den firsta inre loopen,
                    */
                    if (isValid)
                    {
                        firstMatchFound = true;
                        total += subStrLong;
                        ColorizeSubstring(inputStr, i, j);
                    }
                }


            }
        }

        // Skriv ut totalen
        string Total = total.ToString();
        ColorizeSubstring($"Total = {Total}", 0, $"Total = {Total}".Length-1);

    }

    static void ColorizeSubstring(string inputStr, int start, int end)
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < start; i++)
        {
            Console.Write(inputStr[i]);
        }

        Console.ForegroundColor = ConsoleColor.Red;
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
