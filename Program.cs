namespace HQSP_Assignment_2_Task_1
{
    class Customer
    {
        private string name;
        private string buildingType;
        private int size;
        private int lightBulbs;
        private int outlets;
        private string creditCard;

        public string Name
        {
            get => name;
            set
            {
                Validate(value, @"^[A-Za-z]+$", "Name should contain only letters");
                name = value;
            }
        }

        public string BuildingType
        {
            get => buildingType;
            set
            {
                if (value.ToLower() != "house" && value.ToLower() != "barn" && value.ToLower() != "garage")
                    throw new ArgumentException("Building type must be 'house' or 'barn' or 'garage'.");
                buildingType = value;
            }
        }

        public int Size
        {
            get => size;
            set
            {
                if (value < 1000 || value > 50000)
                    throw new ArgumentOutOfRangeException("Size should range from 1000 to 50,000 sq. ft.");
                size = value;
            }
        }

        public int LightBulbs
        {
            get => lightBulbs;
            set
            {
                if (value < 1 || value > 20)
                    throw new ArgumentOutOfRangeException("Light bulbs should range from 1 to 20.");
                lightBulbs = value;
            }
        }

        public int Outlets
        {
            get => outlets;
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentOutOfRangeException("Outlets should range from 1 to 50.");
                outlets = value;
            }
        }

        public string CreditCard
        {
            get => creditCard;
            set
            {
                Validate(value, @"^\d{16}$", "Credit card should have exact 16 digits.");
                creditCard = value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
        }
    }
}
