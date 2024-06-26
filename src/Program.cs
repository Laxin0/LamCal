using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace LamCal
{
    public static class Program
    {
        public static void Main()
        {
            var a = new Application(
                new Application(
                    new Abstraction(
                        "x",
                        new Abstraction(
                            "y",
                            new Application(
                                new Variable("x"),
                                new Variable("y")
                            )
                        )
                    ),
                    //new Variable("M")
                    new Abstraction("d", new Variable("K"))
                ),
                new Variable("N")
            );

            Console.WriteLine(a);
            var interpreter = new Interpreter();
            Console.WriteLine(interpreter.Evaluate(a));
            var tokenizer = new Tokenizer();
            var t = tokenizer.GetTokens(a.ToString());
            foreach(var i in t)
            {
                Console.WriteLine(i);
            }
        }

        
    }
}