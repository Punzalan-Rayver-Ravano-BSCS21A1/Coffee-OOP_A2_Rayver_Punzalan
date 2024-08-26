using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Text;

namespace ShopCoffee
{
  class butFirstCoffee
  {
    public static void Main()
    {
      // List of the items
      List<Tuple<string ,decimal>> checkOut = new List<Tuple<string, decimal>>();
      List<Tuple<string ,decimal>> menuItems = new List<Tuple<string, decimal>>();


      //Outer Loop
      while (true)
      { 
        //breaker for the inner loop
        bool returnToMain = false;
        colorCyan();
        Print("Welcome to the but First Coffee!");
        colorWhite();
        Print("1. Add Menu Item");
        Print("2. View Menu");
        Print("3. Place Order");
        Print("4. View Order");
        Print("5. Calculate Total");
        Print("6. Exit");
        Console.Write("Select an option: ");
        string uInput = Console.ReadLine();
        int uchoice;
        Console.Clear();
        // Checker if choice are correct
        if (!int.TryParse(uInput, out uchoice))
        {
          Print("Invalid input. Don't type letter or special characters");
          Print("Press any key to continue..");
          Console.ReadKey();
          Console.Clear();
        }
        else if (uchoice < 1 || uchoice > 6)
        { 
          Print("Invalid input. Choose a number between 1 to 6");
          Print("Press any key to continue..");
          Console.ReadKey();
          Console.Clear();
        }
        // Holds the function for the options :>
        else
        {
          // to exit the program
          if (uchoice == 6)
          {
            break;
          }
          // inner loop, my breaker wil end this loop going back to menu
          while(true)
          {
            //Option 1
            if(uchoice == 1)
            {
              while(true)
              {
                Print("Enter a menu item. Type exit if your Done");
                string foodName = Console.ReadLine();
                if (foodName.ToLower() == "exit")
                {
                  Print("Press any key to return to the main menu...");
                  returnToMain = true;
                  Console.ReadKey();
                  Console.Clear();
                  break;
                }
                Print("Enter the price of your item");
                string intPrice = Console.ReadLine();
                if (decimal.TryParse(intPrice, out decimal price))
                {
                  menuItems.Add(new Tuple<string, decimal>(foodName, price));
                  Print($"The item '{foodName}' with a price of {price} Pesos is added successfully!");
                }
                else
                { 
                  Console.ForegroundColor = ConsoleColor.Red;
                  Print("Please enter valid price");
                  Console.ForegroundColor = ConsoleColor.White;
                }
              }
            }
            //Option 2
            else if (uchoice == 2)
            {
              int numbering = 1;
              if (menuItems.Count == 0)
              {
                Print("You have nothing here..");
              }
              else
              {
              Print("Your cart:");
                foreach (var itemList in menuItems)
                {
                  Print($"{numbering} {itemList.Item1} - {itemList.Item2:C}");
                  numbering++;
                }
              }
              Print("Press any key to return to the main menu...");
              returnToMain = true;
              Console.ReadKey();
              Console.Clear();

            }
            // Option 3
            else if (uchoice == 3)
            {
              while(true)
              {
                if (menuItems.Count == 0)
                {
                  Print("You have nothing on your cart");
                  Print("Press any key to return to the main menu...");
                  returnToMain = true;
                  Console.ReadKey();
                  Console.Clear();
                  break;
                }
                else 
                {
                  Print("List of your orders");
                  int numbering1 = 1;
                  foreach (var orderList in menuItems)
                  {
                    Print($"{numbering1}. {orderList.Item1} - {orderList.Item2}");
                    numbering1++;
                  }
                
                  Console.Write("Type exit to go back in main menu. Enter the number you want to order: ");
                  string oChoice = Console.ReadLine();
                    if (oChoice == "exit")
                    {
                      Print("Press any key to return to the main menu...");
                      returnToMain = true;
                      Console.ReadKey();
                      Console.Clear();
                      break;
                    }

                    if (int.TryParse(oChoice,out int itemNumber) && itemNumber > 0 && menuItems.Count >= itemNumber)
                    {
                      var selectedItem = menuItems[itemNumber - 1];
                      checkOut.Add(selectedItem);
                      Print($"Item '{selectedItem.Item1}' added to your order.");
                      Print("Press any key to continue...");
                      Console.ReadKey();
                      Console.Clear();
                      
                    }
                    else
                    {
                      Console.ForegroundColor = ConsoleColor.Red;
                      Print("Invalid item number. Please enter a valid number from the list.");
                      Console.ForegroundColor = ConsoleColor.White;
                      Print("Press any key to return to continue...");
                      Console.ReadKey();
                      Console.Clear();
                      break;
                    }
                }
              }
            }
            // Option 4
            else if (uchoice == 4)
            {
              Print("Your Order:");
              
              foreach (var lastOrder in checkOut)
              {
                Print($"{lastOrder.Item1} - {lastOrder.Item2}");
              }
                Print("Press any key to return to the main menu...");
                returnToMain = true;
                Console.ReadKey();
                Console.Clear();
                  
            }
            // Option 5
            else if (uchoice == 5)
            {
              decimal total = 0;
              foreach (var item in checkOut)
              {
                  total += item.Item2;
              }

              Print($"The total amount for your order is: {total:C}");
              Print("Press any key to return to the main menu...");
              returnToMain = true;
              Console.ReadKey();
              Console.Clear();
              break;
            }
            

            //breaker for inner loop
            if (returnToMain)
            {
              break;
            }


            //breaker for inner loop
            if (returnToMain)
            {
              break;
            }
          }
        }

      }



    }
    static void Print(string message)
    {
      Console.WriteLine(message);
    }
    static void colorCyan()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
    }
    static void colorWhite()
    {
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
} 
