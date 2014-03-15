using System;

namespace CarRentals.Core
{
    public class CsvParser<T> : IParser<T> where T : class
    {
        public bool Parse(T input)
        {
            throw new NotImplementedException();
        }
    }
}