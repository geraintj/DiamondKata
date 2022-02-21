using System.Collections.Specialized;

namespace DiamondKata;

public class DiamondGenerator
{
    const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public StringCollection PrintDiamond(char input)
    {
        var diamondLines = new StringCollection();
        var inputIndex = Alphabet.IndexOf(Char.ToUpper(input));

        if (inputIndex < 0)
        {
            return new StringCollection() {"Input character is invalid - it must be a letter."};
        }

        var step = 1;
        var diaondLineIndex = 0;
        var letterIndex = 0;
        while (diaondLineIndex < 2 * (inputIndex + 1) - 1)
        {
            if (diaondLineIndex == inputIndex)
            {
                step = -1;
            }

            diamondLines.Add(new string(BuildLine(inputIndex, letterIndex)));

            letterIndex += step;
            diaondLineIndex++;
        }
        return diamondLines;
    }

    char[] BuildLine(int inputIndex, int letterIndex)
    {
        var lineCharacter = Alphabet[letterIndex];
        const char spaceChar = ' ';

        var lineArray = new char[inputIndex + letterIndex + 1];
        for (int i = 0; i <= inputIndex + letterIndex; i++)
        {
            if (i == inputIndex - letterIndex)
            {
                lineArray[i] = lineCharacter;
                continue;
            }

            if (i == inputIndex + letterIndex)
            {
                lineArray[i] = lineCharacter;
                continue;
            }

            lineArray[i] = spaceChar;
        }
        return lineArray;
    }
}