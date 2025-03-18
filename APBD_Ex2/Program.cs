
namespace APBD_Ex2;

internal static class Program
{
    public static void Main(string[] args)
    {
       
            Console.WriteLine("=== Ship and Container System Test ===\n");

            // Create ships
            var ship1 = new Ship("Poseidon", 5, 5, 30);
            var ship2 = new Ship("Neptune", 5, 6, 25);

            // Create containers 
            var danLiqContainer = new LiquidContainer(1000, 500, 300, 6000, true);
            var liqContainer = new LiquidContainer(1000, 500, 300, 3000, false);

            var gasContainer = new GasContainer(900, 250, 400, 2500, 10);

            var refBananasContainer =
                new RefrigeratedContainer(420, 150, 700, 2500, ProductType.Bananas, 14); // Bananas (13.3) - good temp 
            
            // var refMeatContainer =
            //     new RefrigeratedContainer(360, 220, 300, 1500, ProductType.Meat, -90); // Meat (-14) - bad temp


            Console.WriteLine(refBananasContainer.PrintContainerInfo());


    }
}