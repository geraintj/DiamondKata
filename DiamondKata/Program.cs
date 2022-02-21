using DiamondKata;

bool quitFlag = false;
while (!quitFlag)
{
    Console.WriteLine("Enter character (Type 'Quit' to exit):");
    var input = Console.ReadLine();

    if (input == "Quit")
    {
        quitFlag = true;
    }

    var diamond = new DiamondGenerator();
    foreach (var line in diamond.PrintDiamond(input[0]))
    {
        Console.WriteLine(line);
    }
}



