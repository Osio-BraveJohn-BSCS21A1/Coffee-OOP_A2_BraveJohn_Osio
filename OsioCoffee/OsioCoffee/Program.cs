using System;
using System.Collections.Generic;

namespace OsioCofee
{
    class ShopItem
    {
        public string Item { get; }
        public double Price { get; }

        public ShopItem(string item, double price)
        {
            Item = item;
            Price = price;
        }
    }

    class Program
    {
        static List<ShopItem> menu = new List<ShopItem>();
        static List<ShopItem> order = new List<ShopItem>();
        static void Main(string[] args)
        {

            bool run = true;

            while (run)
            {

                Console.WriteLine("Welcome to the Coffee Shop!");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. View Menu");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Order");
                Console.WriteLine("5. Calculate Total");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        additem();                        
                        break;
                    case "2":
                        viewmenu();
                        break;
                    case "3":
                        placeorder();
                        break;
                    case "4":
                        vieworder();
                        break;
                    case "5":
                        total();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for visiting! Please come again.");
                        Console.Beep(); //:) -Brave
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }

        static void additem()
        {
            Console.Write("Enter item name: ");
            string newItem = Console.ReadLine();
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out double Price))
            {
                menu.Add(new ShopItem(newItem , Price));
                Console.WriteLine("Item added successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid price. Item not added.");
                Console.WriteLine();
            }
        
        }

        static void viewmenu()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("There are no items in the menu.");
            }
            else
            {
                Console.WriteLine("Menu: ");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Item} - ${menu[i].Price:F2}");
                }
            }
        }
        static void placeorder()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("There are no items in the menu.");
            }
            else
            {
                Console.WriteLine("Menu: ");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Item} - ${menu[i].Price:F2}");
                }
            }
            Console.Write("Enter the item number to order: ");
            if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber >= 1 && itemNumber <= menu.Count)
            {
                order.Add(menu[itemNumber - 1]);
                Console.WriteLine("Item added to order!");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
            
        }
        static void vieworder()
        {
            if(order.Count == 0)
            {
                Console.WriteLine("You do not have any orders.");
            }
            else
            {
                Console.WriteLine("Your Order: ");
                for (int i = 0; i < order.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {order[i].Item} - ${order[i].Price:F2}");
                }
            }
        }
        static void total()
        {
            double total = 0;
            foreach (var item in order)
            {
                total += item.Price;
            }
            Console.WriteLine($"Total Amount Payable by admin: ${total:F2}");
        }
    }
}


