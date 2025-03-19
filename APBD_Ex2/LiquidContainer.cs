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
        
        var maxAllowedWeight = IsDangerous ? MaxCargoLoadWeight * 0.5 : MaxCargoLoadWeight * 0.9;
        
        
        if (cargoWeight > maxAllowedWeight)
        {
            NotifyHazard($"Attempted to load {cargoWeight}kg into {(IsDangerous ? "hazardous" : "regular")} container {SerialNumber}, exceeding allowed capacity ({maxAllowedWeight}kg).");
            throw new OverfillException($"Exceeded {(IsDangerous ? "50%" : "90%")} limit for {(IsDangerous ? "hazardous" : "regular")} liquids!");
        }
        
        base.LoadContainerWithCargo(cargoWeight);
       
    }

    public override void PrintContainerInfo()
    {
        base.PrintContainerInfo();
        Console.WriteLine($", Hazardous: {(IsDangerous ? "Yes" : "No")}");
    }
}