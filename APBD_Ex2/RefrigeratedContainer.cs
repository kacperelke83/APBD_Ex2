namespace APBD_Ex2;

public class RefrigeratedContainer : Container
{
    public ProductType Product { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double ownWeight, double height, double depth, double maxLoad, ProductType product, double temperature) : base(ownWeight,
        height, depth, maxLoad, "C")
    {

        var minTemperature = ProductTemperature.GetTemperature(product);

        if (temperature < minTemperature)
        {
            throw new ArgumentException($"Temperatura {temperature}°C jest za niska dla {product}. Minimalna to {minTemperature}°C.");
        }
        
        Product = product;
        Temperature = temperature;

    }

}