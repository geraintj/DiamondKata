using System.ComponentModel.Design;
using DiamondKata;

var inputArgs = Environment.GetCommandLineArgs();
if (inputArgs.Length > 1 && !string.IsNullOrEmpty(inputArgs[1]))
{
    PrintDiamond(inputArgs[1][0]);
}
else
{
    bool quitFlag = false;
    while (!quitFlag)
    {
        Console.WriteLine("Enter character (Type 'Quit' to exit):");
        var input = Console.ReadLine();

        if (input == "Quit")
        {
            quitFlag = true;
        }

        PrintDiamond(input[0]);
    }
}

void PrintDiamond(char input)
{
    var diamond = new DiamondGenerator();
    foreach (var line in diamond.PrintDiamond(input))
    {
        Console.WriteLine(line);
    }
}

