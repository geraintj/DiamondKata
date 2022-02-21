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
        var diamondLineIndex = 0;
        var lineLetterIndex = 0;
        var totalNumberOfLines = 2 * (inputIndex + 1) - 1;
        while (diamondLineIndex < totalNumberOfLines)
        {
            if (diamondLineIndex == inputIndex)
            {
                step = -1;
            }

            diamondLines.Add(new string(BuildLine(inputIndex, lineLetterIndex)));

            lineLetterIndex += step;
            diamondLineIndex++;
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