using System;
using System.Linq;
using Interfaces.TextOperations;

namespace Models.TextOperations
{
    public class UpperFirst : IUpperFirst
    {
        public string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("String is empty");
            return s.ToLower().First().ToString().ToUpper() + s.ToLower().Substring(1);
        }
    }
}