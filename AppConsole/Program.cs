using System.Linq;
using System;
using System.Collections.Generic;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] expressions = new String[] {"(){}", "({})", "aaa", "abba", "{}()[]{"};

            foreach (String expression in expressions)
            {
                bool isValid = ExValidator.Valid(expression);
                Console.WriteLine($"Testando a expressao \"{expression}\": {isValid}");
            }

        }
    }

    public class ExValidator {
        public static bool Valid(String inputExpression)
        {
            Stack<Char> stackChars = new Stack<Char>();
            Char[] arrChars = inputExpression.ToArray();
            
            String openChars = "[{(", closeChars = "]})";

            foreach(Char character in arrChars)
            {
                int openCharsIndex = openChars.LastIndexOf(character);
                if(openCharsIndex > -1) 
                { // opening scope char
                    stackChars.Push(character);
                } else {
                    int closingCharIndex = closeChars.LastIndexOf(character);
                    if(closingCharIndex < 0)
                        return false;
                    
                    Char openingCharCorrespondingToThisChar = openChars.ToArray()[closingCharIndex];
                    Char lastOpenedScopeChar = stackChars.Pop();
                    if(openingCharCorrespondingToThisChar == lastOpenedScopeChar)
                        continue;
                    else
                        return false;
                }
            }

            if(stackChars.Count() > 0)
                return false;
            else
                return true;
        }
    }
}
