namespace APBD_Ex2;

public class Ship(string name, int maxContainers, double maxWeight, double speed)
{
    private string Name { get; } = name;
    private int MaxContainers { get; } = maxContainers;
    private double MaxWeight { get; } = maxWeight; // in tones
    private double Speed { get; } = speed;


    private List<Container> Containers { get; set; } = [];

    public void AddContainer(Container container)
    {
      
        if (Containers.Count >= MaxContainers)
            throw new InvalidOperationException("Exceeded maximum container capacity on the ship.");
        
        var currentWeight = GetCurrentContainersWeight() + container.TotalWeight;
        
        
        if (currentWeight > MaxWeight * 1000) //tons
            throw new InvalidOperationException("Exceeded maximum weight capacity on the ship.");
        
        
        Containers.Add(container);
        Console.WriteLine($"Loaded container {container.SerialNumber} onto ship {Name}.");
    }

    public void RemoveContainer(Container container)
    {
        Console.WriteLine(Containers.Remove(container)
            ? $"Removed container {container.SerialNumber} from ship {Name}."
            : $"Container {container.SerialNumber} not found on ship {Name}.");
    }

    private double GetCurrentContainersWeight()
    {
        return Containers.Sum(c => c.CargoLoadWeight + c.ContainerOwnWeight);
    }
    
    

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var existingContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (existingContainer == null)
            throw new InvalidOperationException($"Container {serialNumber} is not on ship {Name}.");

        var newWeight = GetCurrentContainersWeight() - existingContainer.TotalWeight
                           + newContainer.TotalWeight;

        if (newWeight > MaxWeight * 1000)
            throw new InvalidOperationException("Replacing containers would exceed the ship's weight capacity.");

        Containers.Remove(existingContainer);
        Containers.Add(newContainer);

        Console.WriteLine($"Replaced container {serialNumber} with {newContainer.SerialNumber} on ship {Name}.");
    }
    
    public void TransferContainer(Ship targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException($"Container {serialNumber} is not on ship {Name}.");

        
        try
        {
            targetShip.AddContainer(container);
            Containers.Remove(container);
            Console.WriteLine($"Transferred container {serialNumber} from {Name} to {targetShip.Name}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to transfer container {serialNumber}: {ex.Message}");
        }
    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine($"\nShip: {Name}");
        Console.WriteLine($"- Max speed: {Speed} knots");
        Console.WriteLine($"- Max container capacity: {MaxContainers}");
        Console.WriteLine($"- Max weight capacity: {MaxWeight} tons");
        Console.WriteLine($"- Current containers: {Containers.Count}/{MaxContainers}");
        Console.WriteLine($"- Current total weight: {GetCurrentContainersWeight()} kg ({GetCurrentContainersWeight() / 1000} tons)");
        PrintContainerList();
    }
    
    private void PrintContainerList()
    {
        Console.WriteLine("Containers on board:");
        if (Containers.Count == 0)
        {
            Console.WriteLine("  No containers loaded.");
        }
        else
        {
            foreach (var c in Containers)
            {
                Console.WriteLine($"  - {c.SerialNumber}: {c.GetType().Name}, Weight: {c.CargoLoadWeight} kg");
            }
        }
    }
}