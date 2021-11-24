using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment;

namespace CAB301_TradeTools.ViewModels
{
    public class Tool : iTool, IComparable<Tool>
    {
        
        private string name;

       
        public List<string> Borrowerlist = new List<string>();
        private string v;

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }
        /*public Category category { get; set; }
        public GardeningTools gardeningTools { get; set; }
        public FlooringTools flooringTools { get; set; }
        public FencingTools fencingTools { get; set; }
        public MeasuringTools measuringTools { get; set; }
        public CleaningTools cleaningTools { get; set; }
        public PaintingTools paintingTools { get; set; }
        public ElectronicTools electronicTools { get; set; }
        public ElectricityTools electricityTools { get; set; }
        public AutomotiveTools automotiveTools { get; set; }*/

        public MemberCollection GetBorrowers
        {
            get { return GetBorrowers; }
            set { GetBorrowers = value; }
        }

        public int CompareTo(Tool other)
        {
            if (Name.CompareTo(other.Name) < 0)
            {
                return -1;
            }
            else

                if (Name.CompareTo(other.Name) == 0)
            {
                return AvailableQuantity.CompareTo(other.AvailableQuantity);
            }

            else

                return 1;
        }

        public override string ToString()
        {
            return (Name + " " + Quantity + " " + AvailableQuantity + "" + NoBorrowings.ToString() + "\n");
        }

        public void addBorrower(Member aMember)
        {
            Borrowerlist.Add(aMember.FirstName + aMember.LastName);
        }

        public void deleteBorrower(Member aMember)
        {
            Borrowerlist.Remove(aMember.FirstName + aMember.LastName);
        }

        

        public Tool (string Name, int Quantity, int AvailableQuantity, int NoBorrow)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.AvailableQuantity = AvailableQuantity;
            this.NoBorrowings = NoBorrow;

            
            /*
            this.category = category;            
            this.gardeningTools = gardeningTools;
            this.flooringTools = flooringTools;
            this.fencingTools = fencingTools;
            this.measuringTools = measuringTools;
            this.cleaningTools = cleaningTools;
            this.paintingTools = paintingTools;
            this.electronicTools = electronicTools;
            this.electricityTools = electricityTools;
            this.automotiveTools = automotiveTools;
            */
        }

        public Tool()
        {

        }

        public Tool(string v)
        {
            this.v = v;
        }





        /*
        public enum Category
        {
            GardeningTools,
            FlooringTools,
            FencingTools,
            MeasuringTools,
            CleaningTools,
            PaintingTools,
            ElectronicTools,
            ElectricityTools,
            AutomotiveTools,
        }

        public enum GardeningTools 
        {
            LineTrimmers,
            LawnMowers,
            HandTools,
            Wheelbarrows,
            GardenPowerTools, 
        }
        public enum FlooringTools
        {
            Scrapers,
            FloorLasers,
            FloorLevellingTools,
            FloorLevellingMaterials,
            FloorHandTools,
            TilingTools
        }

        public enum FencingTools
        {
            HandTools,
            ElectricFencing,
            SteelFencingTools,
            PowerTools,
            FencingAccessories
        }

        public enum MeasuringTools
        {
            DistanceTools,
            LaserMeasurer,
            MeasuringJugs,
            TemperatureHumidityTools,
            LevellingTools,
            Markers
        }

        public enum CleaningTools
        {
            Draining,
            CarCleaning,
            Vacuum,
            PressureCleaners,
            PoolCleaning,
            FloorCleaning
        }

        public enum PaintingTools
        {
            SandingTools,
            Brushes,
            Rollers,
            PaintRemovalTools,
            PaintScrapers,
            Sprayers
        }

        public enum ElectronicTools
        {
            VoltageTester,
            Oscilloscopes,
            ThermalImaging,
            DataTestTool,
            InsulationTesters
        }

        public enum ElectricityTools
        {
            TestEquipment,
            SafetyEquipment,
            BasicHandtools,
            CircuitProtection,
            CableTools
        }

        public enum AutomotiveTools
        {
            Jacks,
            AirCompressors,
            BatteryChargers,
            SocketTools,
            Braking,
            Drivetrain
        }*/
    }
}
