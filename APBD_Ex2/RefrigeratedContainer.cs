namespace APBD_Ex2;

public class RefrigeratedContainer : Container
{
    private ProductType Product { get; set; }
    private double Temperature { get; set; }

    public RefrigeratedContainer(double containerOwnWeight, double height, double depth, double maxCargoLoadWeight, ProductType product, double temperature) : base(containerOwnWeight,
        height, depth, maxCargoLoadWeight, "C")
    {

        var minTemperature = ProductTemperature.GetTemperature(product);

        if (temperature < minTemperature)
            throw new ArgumentException($"Temperature {temperature}°C is too low for {product}. Minimum allowed is {minTemperature}°C.");
        
        Product = product;
        Temperature = temperature;

    }

    public void LoadContainerWithCargo(double weight, ProductType product)
    {
        if (weight <= 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "Cargo weight must be greater than zero.");
        
        if (product != Product)
            throw new InvalidOperationException($"Container {SerialNumber} can only store {Product}, not {product}!");

        if (weight > MaxCargoLoadWeight)
            throw new InvalidOperationException($"Overload! Container {SerialNumber} cannot exceed {MaxCargoLoadWeight} kg.");

        CargoLoadWeight += weight;
        Console.WriteLine($"Loaded {weight} kg of {Product} into container {SerialNumber}.");
    }

    public override string PrintContainerInfo()
    {
        return base.PrintContainerInfo() + $", Product: {Product}, Temperature: {Temperature}°C";
    }
}