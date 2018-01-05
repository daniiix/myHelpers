using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public class Salutation
    {
        private readonly IMessageWriter writer;

        public Salutation(IMessageWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("kein writer definiert");
            this.writer = writer;
        }

        public void Exclaim()
        {
            this.writer.Write("hello from daniel");
        }
    }
}
