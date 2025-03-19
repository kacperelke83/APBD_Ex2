namespace APBD_Ex2;

public class GasContainer(
    double containerOwnWeight,
    double height,
    double depth,
    double maxCargoLoadWeight,
    double pressure)
    : Container(containerOwnWeight, height, depth,
        maxCargoLoadWeight, "G"), IHazardNotifier
{
    private double Pressure { get; set; } = pressure;

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }
    
    public override void EmptyContainer()
    {
        CargoLoadWeight *= 0.05;
        Console.WriteLine($"Container {SerialNumber} has been emptied, 5% of the cargo remains.");
    }

    public override void LoadContainerWithCargo(double cargoWeight)
    {
        
        if (cargoWeight > MaxCargoLoadWeight * 0.5)
        {
            NotifyHazard($"Attempted to load {cargoWeight}kg into hazardous container {SerialNumber}, exceeding 50% capacity.");
        }

       base.LoadContainerWithCargo(cargoWeight);
       
    }

    public override void PrintContainerInfo()
    {
       
        base.PrintContainerInfo();
        Console.WriteLine($", Pressure : {Pressure} bar");
       
    }
    
}