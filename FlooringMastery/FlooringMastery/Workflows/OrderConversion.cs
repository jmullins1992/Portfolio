using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FlooringMastery.Workflows
{
    public class OrderConversion
    {
        public static string OrderConvert(Order order)
        {
            if (order.OrderNumber == 0)
            {
                return string.Format(
                    "\tCustomer: {0,34}\n" +
                    "\tArea: {1,38}\n" +
                    "\tState: {2,37}\n" +
                    "\tTax Rate: {3,34}\n" +
                    "\tProduct Type: {4,30}\n" +
                    "\tMaterial Cost Per Square Foot: {5,13}\n" +
                    "\tLabor Cost Per Square Foot: {6,16}\n" +
                    "\tTotal Material Cost: {7,23}\n" +
                    "\tTotal Labor Cost: {8,26}\n" +
                    "\tTax: {9,39}\n" +
                    "\tTotal: {10,37}\n",
                    order.CustomerName, order.Area, order.State, order.TaxRate, order.ProductType,
                    order.CostPerSquareFoot,
                    order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
            }

            return string.Format(
                "\nOrder Number: {0,31}\n" +
                "\tCustomer: {1,34}\n" +
                "\tArea: {2,38}\n" +
                "\tState: {3,37}\n" +
                "\tTax Rate: {4,34}\n" +
                "\tProduct Type: {5,30}\n" +
                "\tMaterial Cost Per Square Foot: {6,13}\n" +
                "\tLabor Cost Per Square Foot: {7,16}\n" +
                "\tTotal Material Cost: {8,23}\n" +
                "\tTotal Labor Cost: {9,26}\n" +
                "\tTax: {10,39}\n" +
                "\tTotal: {11,37}\n",
                order.OrderNumber, order.CustomerName, order.Area, order.State, order.TaxRate, order.ProductType,
                order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax,
                order.Total);
        }
    }
}
