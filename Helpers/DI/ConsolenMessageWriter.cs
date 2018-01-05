using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public class ConsolenMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
