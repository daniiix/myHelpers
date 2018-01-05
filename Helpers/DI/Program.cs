using System;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Benefits from Depency Injection are:
            // (1) late binding
            // (2) extensibility
            // (3) parallel development
            // (4) Maintainability
            // (5) Testability (Unit Test)

            IMessageWriter writer = new ConsolenMessageWriter();

            var salutation = new Salutation(writer);
            salutation.Exclaim();

            Console.ReadKey();
        }
    }
}
