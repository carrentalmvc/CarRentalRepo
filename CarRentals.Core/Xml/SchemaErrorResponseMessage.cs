using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Core
{
   public class SchemaErrorResponseMessage
    {
        public int? LineNumber { get; set; }

        public int? LinePosition { get; set; }

        public string ErrorMessage { get; set; }
    }
}
