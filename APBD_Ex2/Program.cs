
using APBD_Ex2;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            LiquidContainer fuelContainer = new LiquidContainer(1200, 300, 600, 20000, true);
            LiquidContainer milkContainer = new LiquidContainer(1000, 280, 600, 20000, false);

            fuelContainer.LoadCargo(1000);
            milkContainer.LoadCargo(7500);

       
            
            milkContainer.GetCurrentCargoWeight();
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("Błąd załadunku: " + ex.Message);
        }
    }
    }
