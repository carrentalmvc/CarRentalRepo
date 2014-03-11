using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleTestApp
{
   public class SchemaErrorResponseMessage
    {
        public int? LineNumber { get; set; }

        public int? LinePosition { get; set; }

        public string ErrorMessage { get; set; }
    }
}
