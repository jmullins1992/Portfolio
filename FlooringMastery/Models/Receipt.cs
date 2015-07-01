using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Receipt
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Message { get; set; }
    }
}
