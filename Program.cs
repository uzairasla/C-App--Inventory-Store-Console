using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam2
{
    class InventoryItem
    {
        internal string Name { get; set; }
        internal int Price { get; set; }
    }

    class Customer

    {
        internal string Name
        {
            get;
            set;
        }
        internal List<InventoryItem> 
            ShoppingCart
        {
            get;
            set;
        }
    }
    

    class Program
    {
        const string NEWKeyword = "NEW";
        static List<InventoryItem> StoreInventory = new List<InventoryItem>
{
new InventoryItem{Name = "Xbox", Price = 300},
new InventoryItem{Name = "PS4", Price = 280},
new InventoryItem{Name = "iphonex", Price = 900},
new InventoryItem{Name = "Laptop", Price = 580},
new InventoryItem{Name = "Games", Price = 50},
new InventoryItem{Name = "SamsugS9", Price = 980},
new InventoryItem{Name = "Pouch", Price = 70},
new InventoryItem{Name = "i8", Price = 80},
new InventoryItem{Name = "i9", Price = 90},
new InventoryItem{Name = "i10", Price = 100},
new InventoryItem{Name = "i11", Price = 1200},
new InventoryItem{Name = "i12", Price = 125},
new InventoryItem{Name = "i13", Price = 195},
new InventoryItem{Name = "i14", Price = 148},
new InventoryItem{Name = "i15", Price = 130},
new InventoryItem{Name = "i16", Price = 160},
new InventoryItem{Name = "i17", Price = 170},
new InventoryItem{Name = "i18", Price = 180},
new InventoryItem{Name = "i19", Price = 190},
new InventoryItem{Name = "i20", Price = 200},
new InventoryItem{Name = "i21", Price = 215},
new InventoryItem{Name = "i22", Price = 227},
new InventoryItem{Name = "i23", Price = 23},
new InventoryItem{Name = "i24", Price = 240},
new InventoryItem{Name = "i25", Price = 251},

};
        static List<Customer> Customers = new List<Customer>();

        static Dictionary<string, Customer> ActiveCustomers = new Dictionary<string, Customer>();
        static string OptionSeleted;
        static Customer CurrentCustomer = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Customers!!!\n Console App created by Uzair Aslam!!!\n To begin. First Enter 1 and then add yourself as a new customer, and then add products and complete purchase.");
            while (AskUser())
            {

            }

        }
        private static bool AskUser()
        {
            OptionSeleted = GetUserOption();
            switch (OptionSeleted)
            {
                case "Select current shopper":
                    GetCustomer();
                    break;

                case "View store inventory":
                    ViewStoreinventory();
                    AddItemToCart();
                    break;

                case "View cart":
                    ViewCart();
                    break;

                case "Add item to cart":
                    AddItemToCart();
                    break;

                case "Remove item from cart":
                    RemoveItemFromCart();
                    break;

                case "Complete purchase":
                    CompletePurchase();
                    break;
                case "Exit":
                    return false;
                                
            }
            return true;
        }

        private static string GetUserOption()
        {
            Console.WriteLine("Select any option below  (Select corresponding number from 1 to 6 or enter 7 to exit. ) : ");
            Console.WriteLine("1 - Select current shopper");
            Console.WriteLine("2 - View store inventory");
            Console.WriteLine("3 - View cart");
            Console.WriteLine("4 - Add item to cart");
            Console.WriteLine("5 - Remove item from cart");
            Console.WriteLine("6 - Complete purchase");
            Console.WriteLine("7 - Exit");

            string option = Console.ReadLine().ToLower();
            switch (option)
            {
                case "1":
                case "select current shopper":
                    return "Select current shopper";

                case "2":
                case "view store inventory":
                  return "View store inventory";
                                   
                case "3":
                case "view cart":
                    return "View cart";

                case "4":
                case "add item to cart":
                    return "Add item to cart";

                case "5":
                case "remove item from cart":
                    return "Remove item from cart";

                case "6":
                case "complete purchase":
                    return "Complete purchase";

                case "7":
                case "exit":
                    return "Exit";
                default:
                    Console.WriteLine("enter valid option please");AskUser();
                    break;
                    
        }

            ViewStoreinventory();
            return "Add item to cart";
        }

        private static void GetCustomer()
        {
            Console.WriteLine("Here is the list of customers - ");
            if (Customers.Count > 0)
            {
                foreach (var customer in Customers)
                {
                    Console.WriteLine(customer.Name);
                }
                Console.WriteLine("");
                Console.WriteLine("Select any of the above customers by entering the Name");
                Console.WriteLine("OR");
            }
            else
            {
                Console.WriteLine("Currently there are no customers");
            }
            Console.WriteLine("Add a new customer by entering " + NEWKeyword);

            string input = Console.ReadLine();

            if (input.Equals(NEWKeyword, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Please enter the customer name : ");
                string name = Console.ReadLine();
                while (Customers.Exists(customer => customer.Name == name))
                {
                    if (name.Equals(NEWKeyword))
                    {
                        Console.WriteLine("Customer name cannot be NEW");
                    }
                    else
                    {
                        Console.WriteLine("Customer already exists");
                    }
                    Console.Write("Please enter the customer name : ");
                    name = Console.ReadLine();
                }
                Customer newCustomer = new Customer { Name = name, ShoppingCart = new List<InventoryItem>() };
                Customers.Add(newCustomer);
                CurrentCustomer = newCustomer;
            }
            else
            {
                CurrentCustomer = Customers.FirstOrDefault(customer => customer.Name == input);
            }

            if (CurrentCustomer == null)
            {
                Console.WriteLine("No such customer found!");
                AskUser();
            }
            if (!ActiveCustomers.ContainsKey(CurrentCustomer.Name))
            {
                ActiveCustomers.Add(CurrentCustomer.Name, CurrentCustomer);
            }
            Console.WriteLine("Current customer name : " + CurrentCustomer.Name);
            
        }

        private static void ViewStoreinventory()
        {
            Console.WriteLine("Items in Store - ");
            foreach (var inventoryItem in StoreInventory)
            {
                Console.WriteLine(" Item \n " + " \"" + inventoryItem.Name + "\" \n Price \n " + "\""+ inventoryItem.Price+"\"");
            }
            Console.WriteLine("");
        }

        private static void ViewCart()
        {
            if (CurrentCustomer == null)
            {
                Console.WriteLine("No customer selected!  add a customer by pressing \"1\"");
                return;
            }

            Console.WriteLine("Current customer name : " + CurrentCustomer.Name);
            Console.WriteLine("Items in shopping cart - ");
            if (CurrentCustomer.ShoppingCart.Count == 0)
            {
                Console.WriteLine("No items in shopping cart!");
            }
            foreach (var inventoryItem in CurrentCustomer.ShoppingCart)
            {
                Console.Write(": " + inventoryItem.Name + "Price : " + inventoryItem.Price);
            }
            Console.WriteLine("");
        }

        private static void AddItemToCart()
        {
            if (CurrentCustomer == null)
            {
                Console.WriteLine("No customer selected! Add yourself as a customer first.");
                return;
            }

            Console.Write("Enter item name ( Case Sensitive, otherwise it will say item won't found ) :- ");
            string itemName = Console.ReadLine();

            InventoryItem inventoryItem = StoreInventory.FirstOrDefault(i => i.Name == itemName);
            if (inventoryItem == null)
            {
                Console.WriteLine("No such item found!");
                return;
            }
            if (ActiveCustomers.Keys.Contains(CurrentCustomer.Name))
            {
                CurrentCustomer.ShoppingCart.Add(inventoryItem);
                StoreInventory.Remove(inventoryItem);
            }
            else
            {
                Console.WriteLine("No customer selected!");
            }
            ViewCart();
           
        }

        private static void RemoveItemFromCart()
        {
            if (CurrentCustomer == null)
            {
                Console.WriteLine("No customer selected!");
                return;
            }

            Console.Write("Enter name of the item please (Case Sensitive, otherwise it will say item won't found) :- ");
            string itemName = Console.ReadLine();

            InventoryItem inventoryItem = CurrentCustomer.ShoppingCart.FirstOrDefault(i => i.Name == itemName);
            if (inventoryItem == null)
            {
                Console.WriteLine("No such item found!");
                AskUser();
            }
            StoreInventory.Add(inventoryItem);
            CurrentCustomer.ShoppingCart.Remove(inventoryItem);
            ViewCart();
            
        }

        private static void CompletePurchase()
        {
            if (CurrentCustomer == null)
            {
                Console.WriteLine("No customer selected!");
                return;
            }

            int totalValue = 0;
            foreach (var item in CurrentCustomer.ShoppingCart)
            {
                totalValue += item.Price;
            }
            if(totalValue == 0)
            {
               
                ViewStoreinventory();
                Console.WriteLine("Add items to cart in order to complete your purchase..");
                AddItemToCart();

            }

            Console.WriteLine("Total Value : " + totalValue);
            Console.WriteLine("Purchase Completed. Come back to shop more.Appreciate the business. ");
            ActiveCustomers.Remove(CurrentCustomer.Name);
            
        }
    }
}

