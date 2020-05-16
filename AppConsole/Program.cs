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
            
            Dictionary<Char, Char> charPairs = new Dictionary<Char, Char>() {
                {'[', ']'},
                {'{', '}'},
                {'(', ')'}
            };

            foreach(Char character in arrChars)
            {
                
                if(charPairs.Keys.Contains(character)) 
                { // opening scope char
                    stackChars.Push(character);
                } else { 
                    // closing scope char
                    if(!charPairs.Values.Contains(character))
                        return false;

                    Char lastOpened = stackChars.Pop();

                    if(character == charPairs.GetValueOrDefault(lastOpened))
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
