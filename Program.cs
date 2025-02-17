using System.Text.RegularExpressions;

namespace HQSP_Assignment_2_Task_1
{
    //Defining the Customer class
    class Customer
    {
        //Creating private fields that stores customer's information
        private string name; //Stores customer's name
        private string buildingType; //Stores building's type
        private int size; //Stores building's size in sq. ft.
        private int lightBulbs; //Stores number of light bulbs
        private int outlets; //Stores number of outlets
        private string creditCard; //Stores customer's credit card number

        //Creating property for Name field with get and set accessors
        public string Name
        {
            // Get accessor returns the value of the field name
            get => name;

            // Set accessor assigns a value to the name field after validating it
            set
            {
                //Validating the name field to contain only letters
                Validate(value, @"^[A-Za-z]+$", "Name should contain only letters");

                //Assigning the value to the name field if it passes the validation
                name = value;
            }
        }

        //Creating property for BuildingType field with get and set accessors
        public string BuildingType
        {
            // Get accessor returns the value of the field buildingType
            get => buildingType;

            // Set accessor assigns a value to the buildingType field after validating it
            set
            {
                //Validating the buildingType field to contain only 'house' or 'barn' or 'garage' and throwing an exception if it doesn't
                if (value.ToLower() != "house" && value.ToLower() != "barn" && value.ToLower() != "garage")
                    throw new ArgumentException("Building type must be 'house' or 'barn' or 'garage'.");

                //Assigning the value to the buildingType field if it passes the validation
                buildingType = value;
            }
        }

        //Creating property for Size field with get and set accessors
        public int Size
        {
            // Get accessor returns the value of the field size
            get => size;

            // Set accessor assigns a value to the size field after validating it
            set
            {
                //Validating the size field to be in the range of 1000 to 50000 sq. ft. and throwing an exception if it doesn't
                if (value < 1000 || value > 50000)
                    throw new ArgumentOutOfRangeException("Size should range from 1000 to 50,000 sq. ft.");

                //Assigning the value to the size field if it passes the validation
                size = value;
            }
        }

        //Creating property for LightBulbs field with get and set accessors
        public int LightBulbs
        {
            // Get accessor returns the value of the field lightBulbs
            get => lightBulbs;

            // Set accessor assigns a value to the lightBulbs field after validating it
            set
            {
                //Validating the lightBulbs field to be in the range of 1 to 20 and throwing an exception if it doesn't
                if (value < 1 || value > 20)
                    throw new ArgumentOutOfRangeException("Light bulbs should range from 1 to 20.");

                //Assigning the value to the lightBulbs field if it passes the validation
                lightBulbs = value;
            }
        }

        //Creating property for Outlets field with get and set accessors
        public int Outlets
        {
            // Get accessor returns the value of the field outlets
            get => outlets;

            // Set accessor assigns a value to the outlets field after validating it
            set
            {
                //Validating the outlets field to be in the range of 1 to 50 and throwing an exception if it doesn't
                if (value < 1 || value > 50)
                    throw new ArgumentOutOfRangeException("Outlets should range from 1 to 50.");

                //Assigning the value to the outlets field if it passes the validation
                outlets = value;
            }
        }

        //Creating property for CreditCard field with get and set accessors
        public string CreditCard
        {
            // Get accessor returns the value of the field creditCard
            get => creditCard;

            // Set accessor assigns a value to the creditCard field after validating it
            set
            {
                //Validating the creditCard field to contain exact 16 digits
                Validate(value, @"^\d{16}$", "Credit card should have exact 16 digits.");

                //Assigning the value to the creditCard field if it passes the validation
                creditCard = value;
            }
        }

        //Creating a method to validate the input value with the given pattern and error message
        private void Validate(string value, string pattern, string errorMessage)
        {
            //Checking if the value matches the pattern and throwing an exception with the error message if it doesn't
            if (!Regex.IsMatch(value, pattern))
                throw new ArgumentException(errorMessage);
        }

        //Creating a method to display the customer information
        public void CreateWiringSchema() => Console.WriteLine($"{Name}: Creating wiring schema for {BuildingType}.");

        //Creating a method to purchase the necessary parts

        //Creating a method to perform a specific task based on the building type
        public void PurchaseParts() => Console.WriteLine($"{Name}: Purchasing necessary parts for {BuildingType}.");
        
        //Creating a method to perform a specific task based on the building type
        public void SpecificTask()
        {
            //Checking the building type and performing a specific task based on it
            string task = BuildingType.ToLower() switch
            {
                "house" => "Installing fire alarms.",
                "barn" => "Wiring milking equipment.",
                "garage" => "Installing automatic doors.",
                _ => "No specific tasks for this building type."
            };

            //Displaying the specific task
            Console.WriteLine($"{Name}: {task}");
        }

        //Creating a method to display the customer information
        public void DisplayInfo()
        {
            //Masking the credit card number
            string maskedCreditCard = CreditCard.Substring(0, 4) + " XXXX XXXX " + CreditCard.Substring(12, 4);

            //Displaying the customer information
            Console.WriteLine($"{Name} | {BuildingType} | {Size} sq. ft. | {LightBulbs} bulbs | {Outlets} outlets | {maskedCreditCard}");
        }
    }

    //Main program class
    internal class Program
    {
        //Implementing the Main method
        static void Main(string[] args)
        {
            //Creating a list to store the customer objects
            List<Customer> customers = new List<Customer>();

            //Creating a string variable to store the user input
            string input;

            //Creating a loop to add customers
            do
            {
                //Creating a new customer object
                Customer customer = new Customer();

                //Getting the customer name and validating it
                customer.Name = GetValidatedInput("Enter customer name: ",
                    @"^[A-Za-z]+$", "Invalid Input. Name should contain only letters.");

                //Getting the building type and validating it
                customer.BuildingType = GetValidatedInput("Enter building type (house or barn or garage) : ",
                    @"^(house|barn|garage)$", "Invalid Input. Building type should be either 'house' or 'barn' or 'garage'.");

                //Getting the building size and validating it
                customer.Size = GetValidatedIntInput("Enter size (1000 sq.ft. to 50000 sq. ft.) : ", 1000, 50000);

                //Getting the number of light bulbs and validating it
                customer.LightBulbs = GetValidatedIntInput("Enter number of light bulbs (1 to 20) : ", 1, 20);

                //Getting the number of outlets and validating it
                customer.Outlets = GetValidatedIntInput("Enter number of outlets (1 to 50) : ", 1, 50);

                //Getting the credit card number and validating it
                customer.CreditCard = GetValidatedInput("Enter 16 digits credit card number : ",
                    @"^\d{16}$", "Invalid Input. Credit card should be exact 16 digits.");

                //Adding the customer object to the list
                customers.Add(customer);

                //Asking the user if they want to add another customer
                Console.Write("\nWould you like to add another customer? (yes/no): ");

                //Getting user's input
                input = Console.ReadLine().ToLower();
            }

            //Looping until the user enters 'no'
            while (input == "yes");

            //Displaying the customer's information
            Console.WriteLine("\nCustomer Information:");
            Console.WriteLine("************************\n");

            //Looping through the customers list and displaying the information
            foreach (var customer in customers)
            {
                //Calling the methods to create wiring schema
                customer.CreateWiringSchema();

                //Calling the methods to purchase parts
                customer.PurchaseParts();

                //Calling the methods to perform specific tasks
                customer.SpecificTask();

                //Displaying the customer information
                customer.DisplayInfo();
                Console.WriteLine("---------------------------------------------------------------------------");
            }
        }

        //Creating a method to get validated input
        static string GetValidatedInput(string prompt, string pattern, string errorMessage)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
                if (Regex.IsMatch(input, pattern))
                    return input;
                Console.WriteLine($"{errorMessage}");
            } while (true);
        }

        //Creating a method to get validated integer input
        static int GetValidatedIntInput(string prompt, int min, int max)
        {
            int value;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Invalid Input. Value should range from {min} and {max}.");
            }
            while (true);
        }
    }
}
