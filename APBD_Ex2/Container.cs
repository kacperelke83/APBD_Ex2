namespace APBD_Ex2;

public abstract class Container
{
   private static int _counter = 1;

   protected double MaxCargoLoadWeight { get; private set; }
   public double ContainerOwnWeight { get; private set; }
   private double Depth { get; set; }
   private double Height { get; set; }
   private string Type { get; set; }
   public double CargoLoadWeight { get; protected set; }
   public string SerialNumber { get; }

   public double TotalWeight => ContainerOwnWeight + CargoLoadWeight;
   
   
   protected Container(double containerOwnWeight, double height, double depth, double maxCargoLoadWeight, string type)
   {
      ContainerOwnWeight = containerOwnWeight > 0 ? containerOwnWeight 
         : throw new ArgumentOutOfRangeException(nameof(containerOwnWeight), "Container weight must be greater than zero.");
      
      Height = height > 0 ? height 
         : throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero.");
      
      Depth = depth > 0 ? depth 
         : throw new ArgumentOutOfRangeException(nameof(depth), "Depth must be greater than zero.");
      
      CargoLoadWeight = 0;
      
      MaxCargoLoadWeight = maxCargoLoadWeight > 0 ? maxCargoLoadWeight 
         : throw new ArgumentOutOfRangeException(nameof(maxCargoLoadWeight), "Max cargo load must be greater than zero.");

      Type = type;
      
      SerialNumber = $"KON-{type}-{_counter++}";
   }
   
   public virtual void EmptyContainer()
   {
      CargoLoadWeight = 0;
   }

   public virtual void LoadContainerWithCargo(double loadWeight)
   {
      if (loadWeight < 0)
      {
         throw new ArgumentException("Cargo weight cannot be negative");
      }

      if (loadWeight > MaxCargoLoadWeight)
      {
         throw new OverfillException(
            $"Cargo weight {loadWeight}kg exceeds maximum capacity of {MaxCargoLoadWeight}kg.");
      }

      CargoLoadWeight = loadWeight;
      Console.WriteLine($"Cargo {SerialNumber} loaded with {CargoLoadWeight}kg out of {MaxCargoLoadWeight}kg.");
   }

   public virtual string PrintContainerInfo()
   {
      return $"Container {SerialNumber} - Type: {Type}, " +
             $"Load: {CargoLoadWeight}/{MaxCargoLoadWeight}kg, " +
             $"Height: {Height}cm, Depth: {Depth}cm, Own Container Weight: {ContainerOwnWeight}kg";
   }
   
   }
   
   
