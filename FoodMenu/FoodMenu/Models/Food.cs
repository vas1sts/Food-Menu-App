namespace FoodMenu
{
    public interface IFood
    {
        string FoodTitle { get; }
        int OptionNumber { get; }
    }

    public class Steak : IFood
    {
        public string FoodTitle => "Steak";
        public int OptionNumber => 1;
    }

    public class Fries : IFood
    {
        public string FoodTitle => "Fries";
        public int OptionNumber => 2;
    }

    public class Burger : IFood
    {
        public string FoodTitle => "Burger";
        public int OptionNumber => 3;
    }

    public class Pasta : IFood
    {
        public string FoodTitle => "Pasta";
        public int OptionNumber => 4;
    }


    public class Menu
    {
        public static IFood[] GetMenuItems()
        {
            return new IFood[]
            {
                new Steak(),
                new Fries(),
                new Burger(),
                new Pasta(),
            };
        }
    }
}
