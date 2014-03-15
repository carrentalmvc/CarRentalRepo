using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Parser
{
   public interface IParser<T> where T : class
    {
       
       bool Parse(T input);
    }
}
