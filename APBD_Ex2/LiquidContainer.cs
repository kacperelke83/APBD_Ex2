namespace APBD_Ex2;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsDangerous { get; set; }

    public LiquidContainer(double ownWeight, double height, double depth, double maxLoad, bool isDangerous) : base(ownWeight, height, depth, maxLoad, "L")
    {
        IsDangerous = isDangerous;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }

    public override void LoadCargo(double cargoWeight)
    {
        if (IsDangerous && cargoWeight > MaxLoad * 0.5)
        {
            NotifyHazard($"Próba załadunku {cargoWeight}kg do niebezpiecznego kontenera {SerialNumber}, co przekracza 50% pojemności.");
            throw new OverfillException("Przekroczono limit 50% dla niebezpiecznych substancji!");
            
        } else if (!IsDangerous && cargoWeight > MaxLoad * 0.9)
        {
            NotifyHazard($"Próba załadunku {cargoWeight}kg do zwykłego kontenera {SerialNumber}, co przekracza 90% pojemności.");
            throw new OverfillException("Przekroczono limit 90% dla zwykłych cieczy!");
        }
        
        CargoWeight = cargoWeight;
        Console.WriteLine($"Załadowano {cargoWeight}kg do kontenera {SerialNumber}.");
    }
}