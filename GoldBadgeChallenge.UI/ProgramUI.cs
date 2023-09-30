using System.Runtime.CompilerServices;
using GoldBadgeChallenge.Data.entities;
using GoldBadgeChallenge.Data.entities.Enums;
using GoldBadgeChallenge.Repository;


namespace GoldBadgeChallenge.UI
{
    public class ProgramUI
    {
        private readonly DeliveryRepository _deliRepo = new DeliveryRepository();
        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isrunning = true;
            while (isrunning)
            {
                System.Console.WriteLine("██████╗ ███████╗██╗     ██╗██╗   ██╗███████╗██████╗ ██╗   ██╗    ██████╗  █████╗ ████████╗ █████╗ \n" +
                                         "██╔══██╗██╔════╝██║     ██║██║   ██║██╔════╝██╔══██╗╚██╗ ██╔╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗\n" +
                                         "██║  ██║█████╗  ██║     ██║██║   ██║█████╗  ██████╔╝ ╚████╔╝     ██║  ██║███████║   ██║   ███████║\n" +
                                         "██║  ██║██╔══╝  ██║     ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗  ╚██╔╝      ██║  ██║██╔══██║   ██║   ██╔══██║\n" +
                                         "██████╔╝███████╗███████╗██║ ╚████╔╝ ███████╗██║  ██║   ██║       ██████╔╝██║  ██║   ██║   ██║  ██║\n" +
                                         "╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝\n");
                System.Console.WriteLine("Welcome to The Delivery Data Application\n" +
                "1. List All Deliveries\n" +
                "2. Get Delivery by ID\n" +
                "3. Get Enroute Deliveries\n" +
                "4. Get All Completed Deliveries\n" +
                "5. Create a New Delivery\n" +
                "6. Update Delivery Status\n" +
                "7. Delete a Delivery\n" +
                "0. Close Application\n");

                var userInput = int.Parse(Console.ReadLine()!);
                switch (userInput)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        GetDeliById();
                        break;
                    case 3:
                        GetDeliByEnroute();
                        break;
                    case 4:
                        GetDeliByComplete();
                        break;
                    case 5:
                        CreateDeli();
                        break;
                    case 6:
                        UpdateDeli();
                        break;
                    case 7:
                        DeleteDeli();
                        break;
                    case 0:
                        isrunning = CloseApp();
                        break;
                    default:
                        System.Console.WriteLine("Inavlid Selection");
                        PressAnyKey();
                        break;
                }
            }
        }

        private void ListAll()
        {
            Console.Clear();
            var dataFromDb = _deliRepo.GetDeliveries();
            if (dataFromDb.Count() > 0)
            {
                foreach (var deli in dataFromDb)
                {
                    DisplayDeliveries(deli);
                }
            }
            else
            {
                System.Console.WriteLine("There are no deliveries.");
            }

            PressAnyKey();
        }

        private void DisplayDeliveries(Delivery deli)
        {
            System.Console.WriteLine(deli);
        }

        private void GetDeliById()
        {
            Console.Clear();
            System.Console.WriteLine("Please select a delivery by ID");
            var userInputIntValue = int.Parse(Console.ReadLine()!);
            var deliFromDb = _deliRepo.GetDeliveryByID(userInputIntValue);
            if (deliFromDb != null)
                DisplayDeliveries(deliFromDb);
            else
                System.Console.WriteLine("This doesn't exist");

            PressAnyKey();
        }

        private void GetDeliByEnroute()
        {
            Console.Clear();
            var enrouteValue = OrderStatus.EnRoute;
            var deliFromDb = _deliRepo.GetDeliveryByEnRoute(enrouteValue);
            if (deliFromDb != null)
                DisplayDeliveries(deliFromDb);
            else
                System.Console.WriteLine("This doesn't exist");

            PressAnyKey();
        }

        private void GetDeliByComplete()
        {
            Console.Clear();
            var completeValue = OrderStatus.Complete;
            var deliFromDb = _deliRepo.GetDeliveryByCompleted(completeValue);
            if (deliFromDb != null)
                DisplayDeliveries(deliFromDb);
            else
                System.Console.WriteLine("This doesn't exist");

            PressAnyKey();
        }

        private void CreateDeli()
        {
            Console.Clear();
            Delivery deliForm = FillOutDeliForm();
            if (_deliRepo.AddDelivery(deliForm))
                System.Console.WriteLine("Success");
            else
                System.Console.WriteLine("Fail");
            PressAnyKey();
        }

        private Delivery FillOutDeliForm()
        {
            Console.Clear();
            var deliData = new Delivery();
            System.Console.Write("Enter Order Date mm/dd/yyyy: ");
            deliData.OrderDate = DateTime.Parse(Console.ReadLine()!);
            System.Console.Write("Enter Delivery Date mm/dd/yyyy: ");
            deliData.DeliveryDate = DateTime.Parse(Console.ReadLine()!);
            System.Console.Write("Enter Order Item Quantity: ");
            deliData.ItemQuantity = int.Parse(Console.ReadLine()!);
            System.Console.WriteLine("Please select an option:\n"
            + "1. Scheduled\n"
            + "2. Enroute\n"
            + "3. Complete\n"
            + "4. Canceled\n");
            int userInputIntValue = int.Parse(Console.ReadLine()!);
            OrderStatus status = (OrderStatus)userInputIntValue;
            deliData.Status = status;

            return deliData;
        }

        private void UpdateDeli()
        {
            Console.Clear();
            var dataFromDb = _deliRepo.GetDeliveries();

            if (dataFromDb.Count() > 0)
            {
                foreach (var deli in dataFromDb)
                {
                    DisplayDeliveries(deli);
                }
                System.Console.WriteLine("Please select a package by by ID");
                var userInputIntValue = int.Parse(Console.ReadLine()!);
                var deliveryFromDb = _deliRepo.GetDeliveryByID(userInputIntValue);
                if (deliveryFromDb != null)
                {
                    Delivery deliForm = FillOutDeliStatus();
                    if (_deliRepo.UpdateDeliveryStatus(deliveryFromDb.Id, deliForm))
                        System.Console.WriteLine("Success");
                    else
                        System.Console.WriteLine("Fail");
                }
                else
                    System.Console.WriteLine("This doesn't exist");
            }
            else
            {
                System.Console.WriteLine("There are no Deliveries");
            }

            PressAnyKey();
        }

        private Delivery FillOutDeliStatus()
        {
            Console.Clear();
            var deliData = new Delivery();
            System.Console.WriteLine("Update Delivery Status!");
            System.Console.WriteLine("Please select an option:\n"
            + "1. Scheduled\n"
            + "2. Enroute\n"
            + "3. Complete\n"
            + "4. Canceled\n");
            int userInputIntValue = int.Parse(Console.ReadLine()!);
            OrderStatus status = (OrderStatus)userInputIntValue;
            deliData.Status = status;

            return deliData;
        }

        private void DeleteDeli()
        {
            Console.Clear();
            var dataFromDb = _deliRepo.GetDeliveries();

            if (dataFromDb.Count() > 0)
            {
                foreach (var deli in dataFromDb)
                {
                    DisplayDeliveries(deli);
                }
                System.Console.WriteLine("Please select a delivery to delete by ID");
                var userInputIntValue = int.Parse(Console.ReadLine()!);
                var deliveryFromDb = _deliRepo.GetDeliveryByID(userInputIntValue);
                if (deliveryFromDb != null)
                {
                    if (_deliRepo.DeleteDelivery(deliveryFromDb.Id))
                        System.Console.WriteLine("success");
                    else
                        System.Console.WriteLine("fail");
                }
                else
                    System.Console.WriteLine("This doesn't exist");
            }
            else
            {
                System.Console.WriteLine("There are no Instruments");
            }
            PressAnyKey();
        }

        private bool CloseApp()
        {
            Console.Clear();
            System.Console.WriteLine("Thank you for using the application.");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}