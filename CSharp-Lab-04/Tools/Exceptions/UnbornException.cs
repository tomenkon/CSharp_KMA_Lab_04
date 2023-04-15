using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_04.Tools.Exceptions
{
    internal class UnbornException : Exception
    {
        public UnbornException() : base("The person haven't been born yet!")
        {
        }
    }
}
