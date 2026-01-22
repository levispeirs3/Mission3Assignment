// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using Mission3Assignment;

List<FoodItem> foodItems = new List<FoodItem>();

string[] categories = { "Fruit", "Vegetable", "Grain", "Dairy", "Protein" };

bool running = true;
while (running)
{
    Console.WriteLine();
    Console.WriteLine("1) Add Food");
    Console.WriteLine("2) View Food");
    Console.WriteLine("3) Remove Food");
    Console.WriteLine("4) Quit");
    Console.Write("Choice: ");

    string menuChoice = Console.ReadLine();

    // Compare menuChoice variable to options
    switch (menuChoice)
    {
        // Add Food Items
        case "1":
            // Get food item details
            Console.WriteLine("Please enter the food item name:");
            string name = Console.ReadLine();

            Console.WriteLine("Select a category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            int categoryChoice;
            Console.Write("Enter choice (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out categoryChoice) ||
                   categoryChoice < 1 || categoryChoice > categories.Length)
            {
                Console.Write("Invalid choice. Enter a number 1-5: ");
            }

            string category = categories[categoryChoice - 1];

            int quantity;
            Console.Write("Enter a Quantity: ");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.Write("Invalid quantity. Enter a whole number 0 or higher: ");
            }

            DateTime expDate;
            Console.Write("Enter expiration date (MM/DD/YYYY): ");
            while (!DateTime.TryParse(Console.ReadLine(), out expDate))
            {
                Console.Write("Invalid date. Use MM/DD/YYYY: ");
            }

            // Create new food item and add to list
            FoodItem newItem = new FoodItem(name, category, quantity, expDate);
            foodItems.Add(newItem);

            Console.WriteLine("Food item added.");
            break;

        // View Food Items
        case "2":
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items to display.");
            }
            else
            {
                // Use for loop to display food items
                Console.WriteLine("Food Items:");
                for (int i = 0; i < foodItems.Count; i++)
                {
                    FoodItem item = foodItems[i];
                    Console.WriteLine(
                        $"{i + 1}. {item.Name} | {item.Category} | Qty: {item.Quantity} | Exp: {item.ExpirationDate:d}"
                    );
                }
            }
            break;

        // Remove Food Items
        case "3":
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items to remove.");
                break;
            }

            // Display food items with indices
            Console.WriteLine("Select a food item to remove:");
            // Loop through food list to show items
            for (int i = 0; i < foodItems.Count; i++)
            {
                // Show index + 1, name, and category
                Console.WriteLine($"{i + 1}. {foodItems[i].Name} - {foodItems[i].Category}");
            }

            // Enter index number to remove
            int removeChoice;
            Console.Write("Enter choice: ");
            // Parse input into integer and store in removeChoice variable
            // Check if removeChoice is less than 1 or greater than foodItems count
            while (!int.TryParse(Console.ReadLine(), out removeChoice) ||
                   removeChoice < 1 || removeChoice > foodItems.Count)
            {
                Console.Write("Invalid choice. Enter a valid number: ");
            }

            // Remove from foodItems list at index (removeChoice - 1)
            foodItems.RemoveAt(removeChoice - 1);
            Console.WriteLine("Food item removed.");

            // Quit Application
            break;

        case "4":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}