using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data.entities;
using GoldBadgeChallenge.Data.entities.Enums;

namespace GoldBadgeChallenge.Repository
{
    public class DeliveryRepository
    {
        // Pre-exsisting Deliveries
        public DeliveryRepository()
        {
            Seed();
        }

        private void Seed()
        {
            Delivery deli1 = new Delivery(new DateTime(2023, 09, 28),new DateTime(2023, 10, 4), OrderStatus.Scheduled, 3 );
            Delivery deli2 = new Delivery(new DateTime(2021, 04, 5),new DateTime(2021, 04, 12), OrderStatus.Complete, 1 );
            Delivery deli3 = new Delivery(new DateTime(2023, 06, 17),new DateTime(2023, 07, 1), OrderStatus.EnRoute, 11 );
            Delivery deli4 = new Delivery(new DateTime(2023, 09, 19),new DateTime(2023, 09, 22), OrderStatus.EnRoute, 2 );
            Delivery deli5 = new Delivery(new DateTime(2023, 08, 10), new DateTime(2023, 08, 15), OrderStatus.Complete, 5);
            Delivery deli6 = new Delivery(new DateTime(2023, 09, 5), new DateTime(2023, 09, 10), OrderStatus.Scheduled, 7);
            Delivery deli7 = new Delivery(new DateTime(2023, 07, 20), new DateTime(2023, 07, 25), OrderStatus.Complete, 4);
            Delivery deli8 = new Delivery(new DateTime(2023, 10, 1), new DateTime(2023, 10, 5), OrderStatus.Scheduled, 2);
            Delivery deli9 = new Delivery(new DateTime(2023, 11, 15), new DateTime(2023, 11, 20), OrderStatus.EnRoute, 6);
            Delivery deli10 = new Delivery(new DateTime(2023, 12, 5), new DateTime(2023, 12, 10), OrderStatus.Scheduled, 8);
            Delivery deli11 = new Delivery(new DateTime(2023, 10, 15), new DateTime(2023, 10, 20), OrderStatus.EnRoute, 9);
            Delivery deli12 = new Delivery(new DateTime(2023, 10, 25), new DateTime(2023, 11, 1), OrderStatus.Scheduled, 3);
            Delivery deli13 = new Delivery(new DateTime(2023, 11, 10), new DateTime(2023, 11, 15), OrderStatus.Complete, 2);
            Delivery deli14 = new Delivery(new DateTime(2023, 11, 25), new DateTime(2023, 11, 30), OrderStatus.Scheduled, 1);
            Delivery deli15 = new Delivery(new DateTime(2023, 12, 15), new DateTime(2023, 12, 20), OrderStatus.EnRoute, 4);
            Delivery deli16 = new Delivery(new DateTime(2023, 12, 25), new DateTime(2023, 12, 30), OrderStatus.Scheduled, 6);
            Delivery deli17 = new Delivery(new DateTime(2023, 10, 30), new DateTime(2023, 11, 5), OrderStatus.Complete, 3);
            Delivery deli18 = new Delivery(new DateTime(2023, 09, 15), new DateTime(2023, 09, 20), OrderStatus.EnRoute, 5);
            Delivery deli19 = new Delivery(new DateTime(2023, 12, 5), new DateTime(2023, 12, 10), OrderStatus.Scheduled, 7);
            Delivery deli20 = new Delivery(new DateTime(2023, 11, 5), new DateTime(2023, 11, 10), OrderStatus.Complete, 2);

            AddDelivery(deli1);
            AddDelivery(deli2);
            AddDelivery(deli3);
            AddDelivery(deli4);
            AddDelivery(deli5);
            AddDelivery(deli6);
            AddDelivery(deli7);
            AddDelivery(deli8);
            AddDelivery(deli9);
            AddDelivery(deli10);
            AddDelivery(deli11);
            AddDelivery(deli12);
            AddDelivery(deli13);
            AddDelivery(deli14);
            AddDelivery(deli15);
            AddDelivery(deli16);
            AddDelivery(deli17);
            AddDelivery(deli18);
            AddDelivery(deli19);
            AddDelivery(deli20);
            
        }

        // Fake Database
        private readonly List<Delivery> _deliveryDbContext = new List<Delivery>();
        private int _count = 0;

        // Create
        public bool AddDelivery(Delivery delivery)
        {
            if(delivery == null)
            {
                return false;
            }
            else
            {
                _count++;
                delivery.Id = _count;
                delivery.ItemNumber = _count;
                _deliveryDbContext.Add(delivery);
                return true;
            }
        }

        // Read - This will read all deliveries

        public List<Delivery> GetDeliveries()
        {
            return _deliveryDbContext;
        }

        // Read - This is read by ID

        public Delivery GetDeliveryByID(int id)
        {
            foreach(Delivery deli in _deliveryDbContext)
            {
                if(deli.Id == id)
                return deli;
            }
            return null;
        }

        // Read - All En route deliveries

        public Delivery GetDeliveryByEnRoute(OrderStatus status)
        {
            foreach(Delivery deli in _deliveryDbContext)
            {
                if(deli.Status == OrderStatus.EnRoute )
                return deli;
            }
            return null;
        }

        // Read - All Completed deliveries

        public Delivery GetDeliveryByCompleted(OrderStatus status)
        {
            foreach(Delivery deli in _deliveryDbContext)
            {
                if(deli.Status == OrderStatus.Complete )
                return deli;
            }
            return null;
        }

        // Update Delivery Status

        public bool UpdateDeliveryStatus(int deliId, Delivery newDeliData)
        {
            var deliInDb = GetDeliveryByID(deliId);
            if(deliInDb != null)
            {
                deliInDb.Status = newDeliData.Status;
                return true;
            }
            return false;
        }

        // Delete

        public bool DeleteDelivery(int deliId)
        {
            var deliInDb = GetDeliveryByID(deliId);
            return _deliveryDbContext.Remove(deliInDb);
        }

    }
}