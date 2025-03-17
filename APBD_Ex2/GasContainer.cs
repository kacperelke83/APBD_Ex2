namespace APBD_Ex2;

public class GasContainer : Container, IHazardNotifier
{

    public double Pressure { get; set; }
    
    public GasContainer(double ownWeight, double height, double depth, double maxLoad, double pressure) : base(ownWeight, height, depth,
        maxLoad, "G")
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }
    
    public override void EmptyCargo()
    {
        CargoWeight *= 0.05;
        Console.WriteLine($"Kontener {SerialNumber} został opróżniony, pozostało 5% ładunku.");
    }
    
    public override void LoadCargo(double cargoWeight)
    {
        if ( cargoWeight > MaxLoad)
        {
            NotifyHazard($"Próba załadunku {cargoWeight}kg do niebezpiecznego kontenera {SerialNumber}, co przekracza 50% pojemności.");
            throw new OverfillException("Przekroczono limit 50% dla niebezpiecznych substancji!");
            
        } 
        
        CargoWeight = cargoWeight;
    }
}