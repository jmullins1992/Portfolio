using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        //user-editable fields        
        public string CustomerName { get; set; }
        public decimal Area { get; set; } 
        public string State { get; set; }
        public string ProductType { get; set; } 

        //derived fields
        public int OrderNumber { get; set; }
        public decimal TaxRate { get; set; }        
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}

