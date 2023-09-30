using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data.entities.Enums;

namespace GoldBadgeChallenge.Data.entities
{
    public class Delivery
    {

        public Delivery(){}
        public Delivery(DateTime orderDate, DateTime deliveryDate, OrderStatus status, int itemQuantity)
        {
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Status = status;
            ItemQuantity = itemQuantity;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public int ItemNumber { get; set; }
        public int ItemQuantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Order Status: {Status} - Order Date: {OrderDate} Delivery Date: {DeliveryDate} - Item Number: {ItemNumber} Item Quantity: {ItemQuantity}";
        }
    }
}