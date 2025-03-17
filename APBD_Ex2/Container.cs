namespace APBD_Ex2;

public abstract class Container
{
   private static int _counter = 1;
   
   protected double MaxLoad { get; set; }
   
   protected double OwnWeight { get; set; }
   
   protected double Depth { get; set; }

   protected double Height { get; set; }

   protected string Type { get; set; }

   
   protected double CargoWeight { get; set; }

   protected string SerialNumber { get; }


   protected Container(double ownWeight, double height, double depth, double maxLoad, string type)
   {
      OwnWeight = ownWeight;
      Height = height;
      Depth = depth;
      CargoWeight = 0;
      MaxLoad = maxLoad;
      Type = type;
      SerialNumber = $"KON-{type}-{_counter++}";
   }

   public virtual void EmptyCargo()
   {
      CargoWeight = 0;
   }

   public virtual void LoadCargo(double cargoWeight)
   {
      if (cargoWeight > MaxLoad)
      {
         throw new OverflowException($"Masa ładunku {cargoWeight}kg przekracza maksymalną ładowność {MaxLoad}kg.");
      }
      
      CargoWeight = cargoWeight;
      Console.WriteLine($"Cargo {SerialNumber} loaded with {CargoWeight}kg." );
   }

   public void GetCurrentCargoWeight()
   {
      
      Console.WriteLine($"Cargo {SerialNumber} is loaded with {CargoWeight}kg. out of {MaxLoad}kg.");
      
   }

}