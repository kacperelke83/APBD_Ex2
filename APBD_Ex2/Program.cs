
namespace APBD_Ex2;

internal static class Program
{
    public static void Main(string[] args)
    {
          Console.WriteLine("=== Ship and Container System Test ===\n");
          
           
           // Create Containers (Different Types)
            var danLiqContainer = new LiquidContainer(1000, 500, 300, 6000, true);  // Hazardous
            var liqContainer = new LiquidContainer(1000, 500, 300, 3000, false);   // Non-hazardous
            var gasContainer = new GasContainer(900, 250, 400, 2500, 10);
            var refBananaContainer = new RefrigeratedContainer(420, 150, 700, 2500, ProductType.Bananas, 14);

            Console.WriteLine("[SUCCESS] Created all containers.\n");

            // Print container details before loading cargo
            Console.WriteLine("=== Initial Container States ===");
            danLiqContainer.PrintContainerInfo();
            liqContainer.PrintContainerInfo();
            gasContainer.PrintContainerInfo();
            refBananaContainer.PrintContainerInfo();
            Console.WriteLine();

            // Load Cargo into Containers
            danLiqContainer.LoadContainerWithCargo(2900); // Hazardous
            liqContainer.LoadContainerWithCargo(2700);   // Non-hazardous
            gasContainer.LoadContainerWithCargo(1200);   // Gas
            refBananaContainer.LoadContainerWithCargo(1200, ProductType.Bananas); // Correct product

            Console.WriteLine("[SUCCESS] Loaded cargo into containers.\n");

            // Print container details after loading cargo
            
            danLiqContainer.PrintContainerInfo();
            liqContainer.PrintContainerInfo();
            gasContainer.PrintContainerInfo();
            refBananaContainer.PrintContainerInfo();
            Console.WriteLine();

            // Create Ships
            var ship1 = new Ship("Poseidon", 5, 50, 30);
            var ship2 = new Ship("Neptune", 5, 60, 25);

            // Load Individual Containers onto Ship
            ship1.AddContainer(danLiqContainer);
            ship1.AddContainer(gasContainer);
            

            // Print ship state after loading individual containers
            ship1.PrintShipInfo();
            Console.WriteLine();

            // Load Multiple Containers at Once
            var containerBatch = new List<Container> { liqContainer, refBananaContainer };
            foreach (var container in containerBatch)
            {
                ship1.AddContainer(container);
            }
        

            // Print ship state after batch loading
            ship1.PrintShipInfo();
            Console.WriteLine();

            // Remove a Container
            ship1.RemoveContainer(gasContainer);
           

            // Print ship state after removal
            ship1.PrintShipInfo();
            Console.WriteLine();

            // Replace a Container
            var newGasContainer = new GasContainer(850, 240, 390, 2400, 8);
            ship1.ReplaceContainer(danLiqContainer.SerialNumber, newGasContainer);
            

            // Print ship state after replacement
            ship1.PrintShipInfo();
            Console.WriteLine();

            // Transfer a Container Between Ships
            ship1.TransferContainer(ship2, refBananaContainer.SerialNumber);
            

            //  Print Ship States After Transfer
            ship1.PrintShipInfo();
            ship2.PrintShipInfo();

            // Print Final Container States
            Console.WriteLine("\n=== Final Container States ===");
            refBananaContainer.PrintContainerInfo();
            newGasContainer.PrintContainerInfo();
            refBananaContainer.PrintContainerInfo();
            Console.WriteLine();

           

            
            
            
        
            danLiqContainer.LoadContainerWithCargo(5000);
            
            //
            // liqContainer.LoadContainerWithCargo(2800);
            //
            //
            // refBananaContainer.LoadContainerWithCargo(800, ProductType.Meat);
            //
            //
            //
            // ship1.AddContainer(newGasContainer);
            //
            //
            // var heavyContainer = new GasContainer(30000, 500, 300, 60000, 20);
            // ship1.AddContainer(heavyContainer);
            //
            //
            // ship1.TransferContainer(ship2, "KON-NIEISTNIEJĄCY-123");
            

    }
}