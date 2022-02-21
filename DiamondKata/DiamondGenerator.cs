using System.Collections.Specialized;

namespace DiamondKata;

public class DiamondGenerator
{

    public StringCollection PrintDiamond(char input)
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var diamondLines = new StringCollection();
        var inputIndex = alphabet.IndexOf(Char.ToUpper(input));

        if (inputIndex < 0)
        {
            return new StringCollection() {"Input character is invalid - it must be a letter."};
        }
        var step = 1;
        var lineIndex = 0;
        var letterIndex = 0;
        while (lineIndex < 2 * (inputIndex + 1) - 1)
        {
            if (lineIndex == inputIndex)
            {
                step = -1;
            }

            diamondLines.Add(new string(BuildLine(alphabet[letterIndex], inputIndex, letterIndex)));

            letterIndex += step;
            lineIndex++;
        }

        return diamondLines;
    }

    char[] BuildLine(char lineCharacter, int inputIndex, int lineIndex)
    {
        const char spaceChar = ' ';

        var lineArray = new char[inputIndex + lineIndex + 1];
        for (int i = 0; i <= inputIndex + lineIndex; i++)
        {
            if (i == inputIndex - lineIndex)
            {
                lineArray[i] = lineCharacter;
                continue;
            }

            if (i == inputIndex + lineIndex)
            {
                lineArray[i] = lineCharacter;
                continue;
            }

            lineArray[i] = spaceChar;
        }
        return lineArray;
    }
}