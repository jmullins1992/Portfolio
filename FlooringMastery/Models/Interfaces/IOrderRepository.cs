using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderNumber, DateTime orderDate);

        void AddOrder(Order orderToAdd);
        void EditOrder(Order orderToEdit,DateTime orderDate);
        void DeleteOrder(int orderNumber, DateTime orderDate);

        List<Order> GetAllOrders(DateTime date);
    }
}
