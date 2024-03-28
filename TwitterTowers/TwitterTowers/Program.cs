// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

TwitterTowers();
static void TwitterTowers()
{


    bool exit = false;

    while (!exit)
    {
        string option;
        Console.WriteLine("To select a rectangle tower, press 1");
        Console.WriteLine("To select a triangular tower, press 2");
        Console.WriteLine("To exit, press 3");

        option = Console.ReadLine();

        switch (option)
        {
            case "1":
                ChoosingRectangleTower();
                break;
            case "2":
                ChoosingTriangleTower();
                break;
            case "3":
                Console.WriteLine("Exiting the program...");
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid option. Please choose a valid option (1, 2, or 3).");
                break;
        }

    }


    static void ChoosingRectangleTower()
    {
        int width, height, area, scope;

        width = GetTowerWidth();
        height = GetTowerHeight();
        area = width * height;
        scope = 2 * (height + width);
        if (width == height || Math.Abs(height - width) > 5)
        {

            Console.WriteLine($"Tower area: {area}");
        }
        else
        {
            Console.WriteLine($"Tower scope : {scope}");
        }

    }
    static void ChoosingTriangleTower()
    {
        int width, height, scope;
        string option;

        width = GetTowerWidth();
        height = GetTowerHeight();

        Console.WriteLine("To calculate the scope of the tower, press 1:");
        Console.WriteLine("To print the tower, press 2:");
        option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CalculateTriangleTowerScope(width, height);
                break;
            case "2":
                PrintTriangleTower(width, height);
                break;
            default:
                Console.WriteLine("Invalid option. Please choose a valid option (1, 2).");
                break;
        }

    }
    static void PrintTriangleTower(int width, int height)
    {
        if (width % 2 == 0 || width > 2 * height)
        {
            Console.WriteLine("The triangle cannot be printed");

        }
        else
        {

            int countOddNumbers, linesWithhoutFirstAndLast, timesLine, SecondPartLength;
            int[] spaces = new int[height];
            int[] lines = new int[height];

            countOddNumbers = (width - 3) / 2;
            linesWithhoutFirstAndLast = height - 2;
            timesLine = linesWithhoutFirstAndLast / countOddNumbers;
            SecondPartLength = (linesWithhoutFirstAndLast % countOddNumbers) + timesLine;

            string currentLine = "";

            lines[0] = 1;
            lines[lines.Length - 1] = width;

            for (int i = 1; i < SecondPartLength + 1; i++)
            {
                lines[i] = 3;
            }

            for (int i = SecondPartLength + 1; i < lines.Length - 1; i++)
            {

                for (int j = 0; j < timesLine; j++)
                {

                    if (j == 0)
                    {
                        lines[i] = lines[i - 1] + 2;
                    }
                    else
                    {
                        lines[i] = lines[i - 1];
                    }
                    if (j < timesLine - 1)
                        i++;
                }

            }

            for (int i = 0; i < spaces.Length; i++)
            {
                spaces[i] = (width - lines[i]) / 2;
            }

            for (int i = 0; i < height; i++)
            {
                currentLine = "";
                for (int j = 0; j < spaces[i]; j++)
                {
                    currentLine += " ";
                }
                for (int j = 0; j < lines[i]; j++)
                {
                    currentLine += "*";
                }
                Console.WriteLine(currentLine);


            }

        }

    }
    static void CalculateTriangleTowerScope(int width, int height)
    {
        int scope, sideLength;
        sideLength = (int)Math.Sqrt(Math.Pow(height, 2) + Math.Pow(width / 2, 2));
        scope = 2 * sideLength + width;
        Console.WriteLine($"Scope of the triangle tower: {scope}");

    }
    static int GetTowerHeight()
    {
        bool success;
        int height;

        Console.WriteLine("Enter the height of the tower, it must be greater than or equal to 2:");
        do
        {
            success = System.Int32.TryParse(Console.ReadLine(), out height);
            if (success)
            {
                if (height < 2)
                {
                    Console.WriteLine("The height of the tower must be greater than or equal to 2. try again");
                    success = false;
                }

            }
            else
                Console.WriteLine("you entered invalid value. try again");
        }
        while (!success);
        return height;
    }
    static int GetTowerWidth()
    {
        bool success;
        int width;
        Console.WriteLine("Enter the width of the tower:");

        do
        {
            success = System.Int32.TryParse(Console.ReadLine(), out width);
            if (success)
            {
                if (width < 0)
                {
                    Console.WriteLine("The width of the tower must be greater than 0. try again");
                    success = false;
                }

            }
            else
                Console.WriteLine("you entered invalid value. try again");
        }
        while (!success);

        return width;
    }
}
