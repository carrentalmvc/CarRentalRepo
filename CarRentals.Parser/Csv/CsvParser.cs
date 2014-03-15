using System;

namespace CarRentals.Parser
{
    public class CsvParser<T> : IParser<T> where T : class
    {
        public bool Parse(T input)
        {
            throw new NotImplementedException();
        }
    }
}