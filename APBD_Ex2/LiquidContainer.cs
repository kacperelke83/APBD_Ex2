namespace APBD_Ex2;

public class LiquidContainer(
    double containerOwnWeight,
    double height,
    double depth,
    double maxCargoLoadWeight,
    bool isDangerous)
    : Container(containerOwnWeight, height, depth, maxCargoLoadWeight, "L"), IHazardNotifier
{
    private bool IsDangerous { get; set; } = isDangerous;

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }

    public override void LoadContainerWithCargo(double cargoWeight)
    {
        
        if (cargoWeight <= 0)
            throw new ArgumentOutOfRangeException(nameof(cargoWeight), "Cargo weight must be greater than zero.");
        
        var maxAllowedWeight = IsDangerous ? MaxCargoLoadWeight * 0.5 : MaxCargoLoadWeight * 0.9;
        
        
        if (cargoWeight > maxAllowedWeight)
        {
            NotifyHazard($"Attempted to load {cargoWeight}kg into {(IsDangerous ? "hazardous" : "regular")} container {SerialNumber}, exceeding allowed capacity ({maxAllowedWeight}kg).");
            throw new OverfillException($"Exceeded {(IsDangerous ? "50%" : "90%")} limit for {(IsDangerous ? "hazardous" : "regular")} liquids!");
        }
        
        
        CargoLoadWeight = cargoWeight;
        Console.WriteLine($"Successfully loaded {cargoWeight}kg into container {SerialNumber}.");
    }

    public override string PrintContainerInfo()
    {
        return base.PrintContainerInfo() + $", Hazardous: {(IsDangerous ? "Yes" : "No")}";
    }
}