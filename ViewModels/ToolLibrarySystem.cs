using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment;
using Interfaces;
using static CAB301_TradeTools.ViewModels.Tool;
using CAB301_TradeTools;
using CAB301_TradeTools.Views;

namespace CAB301_TradeTools.ViewModels
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private int ID = 0;
        Member m = new Member();
        readonly ToolCollection toolCollection = new ToolCollection();
        readonly MemberCollection memberCollection = new MemberCollection();
       

        private Member[] ListMembers = new Member[0];
        private Tool[] ListTools = new Tool[0];

        public void add(Tool aTool)
        {

            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Add New Tool==========\n");
                Console.Write("Enter New Tool Name: ");
                string ToolName = Console.ReadLine();
                Console.WriteLine("\n=================================\n");
                // Select a Category
                Console.WriteLine("\n========Select A Category=======\n");
                string[][] ToolType = new string[9][];
                int counter = 0;

                ToolType[0] = new string[] { "Gardening Tools", "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheel Barrows", "Garden Power Tools" };
                ToolType[1] = new string[] { "Flooring Tools", "Scrapers", "Floor Lasers", "Floor Leveling Tools", "Floor Leveling Materials", "Floor Hand Tools", "Tiling Tools" };
                ToolType[2] = new string[] { "Fencing Tools", "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
                ToolType[3] = new string[] { "Measuring Tools", "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature and Humidity Tools", "Levelling Tools", "Markers" };
                ToolType[4] = new string[] { "Cleaning Tools", "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
                ToolType[5] = new string[] { "Painting Tools", "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
                ToolType[6] = new string[] { "Electronic Tools", "VoltageTester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
                ToolType[7] = new string[] { "Electricity Tools", "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" };
                ToolType[8] = new string[] { "Automotive Tools", "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

                for (int j = 0; j < ToolType.Length; j++)
                {
                    Console.Write(" " + counter + ". " + ToolType[j][0] + "\n");
                    counter++;
                }
                Console.WriteLine("\n=================================\n");
                Console.Write("Select a Tool type (Enter A Number) || Enter 9 to Return to Main Menu: ");

                int selectedtooltype = Convert.ToInt32(Console.ReadLine());
                switch (selectedtooltype)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;                       
                        int quantity = 0;
                        menu.StaffMenu(aMember, aTool, quantity);
                        break; 
                }

                Console.WriteLine("\n========Select A Tool Type=======\n");
                int counter2 = 0;
                //Select A Tool Type
                if (selectedtooltype == 1 || selectedtooltype == 3 || selectedtooltype == 4 || selectedtooltype == 5 || selectedtooltype == 8)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                Console.WriteLine("==================================\n");
                Console.Write("Select a Tool type (Enter Number) || Enter R to Return to Category || Enter C to Return to Main Menu : ");
                int reviewaddtool = Convert.ToInt32(Console.ReadLine());

                switch (reviewaddtool)
                {
                    case 'c':
                        Menus menu = new Menus();
                        Member aMember = null;
                        string aToolType = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                    case 'r':
                        add(aTool);
                        break;
                }


                Console.Clear();
                Console.WriteLine("==========Review Added Tool==========\n");
                Console.WriteLine("Tool Name: " + ToolName);
                Console.WriteLine("Tool Category: " + ToolType[selectedtooltype][0]);
                Console.WriteLine("Tool Type: " +  ToolType[selectedtooltype][reviewaddtool]);
                Console.WriteLine("\n====================================\n");
                Console.Write("Enter Y to Add New Tool || Enter N to Start Over: ");
                string confirm = Console.ReadLine();
                string ignorelower = confirm.ToUpper(); 
                if (ignorelower == "Y")
                { 
                    ToolType[selectedtooltype][reviewaddtool].ToArray();
                    int quantity = 0;
                    Tool newTool = new Tool(ToolName, quantity, 0, 0);
                    Array.Resize(ref ListTools, ListTools.Length + 1);
                    ListTools[^1] = newTool;
                    Console.Write("Successfully Added!");
                    string success = Console.ReadLine();
                    Console.ReadKey();
                    
                }
                else
                {
                    add(aTool);
                }
               

            }
            catch
            {
                Menus.Error("");
            }
        }

        public void add(Tool aTool, int quantity)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Add Some Pieces to a Tool==========\n");
            string[][] ToolType = new string[9][];
            int counter = 0;

            ToolType[0] = new string[] { "Gardening Tools", "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheel Barrows", "Garden Power Tools" };
            ToolType[1] = new string[] { "Flooring Tools", "Scrapers", "Floor Lasers", "Floor Leveling Tools", "Floor Leveling Materials", "Floor Hand Tools", "Tiling Tools" };
            ToolType[2] = new string[] { "Fencing Tools", "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
            ToolType[3] = new string[] { "Measuring Tools", "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature and Humidity Tools", "Levelling Tools", "Markers" };
            ToolType[4] = new string[] { "Cleaning Tools", "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
            ToolType[5] = new string[] { "Painting Tools", "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
            ToolType[6] = new string[] { "Electronic Tools", "VoltageTester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
            ToolType[7] = new string[] { "Electricity Tools", "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" };
            ToolType[8] = new string[] { "Automotive Tools", "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

            for (int j = 0; j < ToolType.Length; j++)
            {
                Console.Write(" " + counter + ". " + ToolType[j][0] + "\n");
                counter++;
            }
            Console.WriteLine("\n=================================\n");
            Console.Write("Select a Tool type (Enter A Number) || Enter 9 to Return to Main Menu: ");

            int selectedtooltype = Convert.ToInt32(Console.ReadLine());
            switch (selectedtooltype)
            {
                case 9:
                    Menus menu = new Menus();
                    Member aMember = null;
                    menu.StaffMenu(aMember, aTool, quantity);
                    break;
            }

            Console.WriteLine("\n========Select A Tool Type=======\n");
            int counter2 = 0;
            //Select A Tool Type
            if (selectedtooltype == 1 || selectedtooltype == 3 || selectedtooltype == 4 || selectedtooltype == 5 || selectedtooltype == 8)
            {
                for (int i = 1; i < 7; i++)
                {
                    Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                    counter2++;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                    counter2++;
                }
            }
            Console.WriteLine("==================================\n");
            Console.Write("Select a Tool type (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
            int selectedtool = Convert.ToInt32(Console.ReadLine());

            switch (selectedtool)
            {
                case 9:
                    Menus menu = new Menus();
                    Member aMember = null;
                    string aToolType = null;
                    menu.MemberMenu(aMember, aToolType, aTool);
                    break;
                case 8:
                    add(aTool, quantity);
                    break;
            }


            Console.WriteLine("\n==========Select Tool Name==========\n");
            Console.WriteLine("============================================================================\r");
            Console.WriteLine("Tool Name                                     Available              Total");
            Console.WriteLine("============================================================================\r");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            /*int counter3 = 0;
            if (selectedtool == 1 || selectedtool == 2 || selectedtool == 3 || selectedtool == 4 || selectedtool == 5 || selectedtool == 6)
            {
                for (int i = 1; i < 7; i++)
                {
                    Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                    counter3++;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                    counter3++;
                }
            }*/
            Console.WriteLine("\n\n============================================================================");
            Console.Write("Select a Tool to Add Quantity (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
            int selectedtoolname = Convert.ToInt32(Console.ReadLine());

            switch (selectedtoolname)
            {
                case 9:
                    Menus menu = new Menus();
                    Member aMember = null;
                    string aToolType = null;
                    menu.MemberMenu(aMember, aToolType, aTool);
                    break;
                case 8:
                    delete(aTool, quantity);
                    break;
            }

            
            


        }

        //Specifications doesn't ask for a tool to be deleted only piece of a tool.
        public void delete(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool aTool, int quantity)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Remove Some Pieces of a Tool==========\n");
                string[][] ToolType = new string[9][];
                int counter = 0;

                ToolType[0] = new string[] { "Gardening Tools", "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheel Barrows", "Garden Power Tools" };
                ToolType[1] = new string[] { "Flooring Tools", "Scrapers", "Floor Lasers", "Floor Leveling Tools", "Floor Leveling Materials", "Floor Hand Tools", "Tiling Tools" };
                ToolType[2] = new string[] { "Fencing Tools", "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
                ToolType[3] = new string[] { "Measuring Tools", "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature and Humidity Tools", "Levelling Tools", "Markers" };
                ToolType[4] = new string[] { "Cleaning Tools", "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
                ToolType[5] = new string[] { "Painting Tools", "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
                ToolType[6] = new string[] { "Electronic Tools", "VoltageTester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
                ToolType[7] = new string[] { "Electricity Tools", "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" };
                ToolType[8] = new string[] { "Automotive Tools", "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

                for (int j = 0; j < ToolType.Length; j++)
                {
                    Console.Write(" " + counter + ". " + ToolType[j][0] + "\n");
                    counter++;
                }
                Console.WriteLine("\n=================================\n");
                Console.Write("Select a Tool type (Enter A Number) || Enter 9 to Return to Main Menu: ");

                int selectedtooltype = Convert.ToInt32(Console.ReadLine());
                switch (selectedtooltype)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;
                        menu.StaffMenu(aMember, aTool, quantity);
                        break;
                }

                Console.WriteLine("\n========Select A Tool Type=======\n");
                int counter2 = 0;
                //Select A Tool Type
                if (selectedtooltype == 1 || selectedtooltype == 3 || selectedtooltype == 4 || selectedtooltype == 5 || selectedtooltype == 8)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                Console.WriteLine("==================================\n");
                Console.Write("Select a Tool type (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
                int selectedtool = Convert.ToInt32(Console.ReadLine());

                switch (selectedtool)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;
                        string aToolType = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                    case 8:
                        delete(aTool, quantity);
                        break;
                }

                Console.WriteLine("\n==========Select Tool Name==========\n");
                Console.WriteLine("============================================================================\r");
                Console.WriteLine("Tool Name                                     Available              Total");
                Console.WriteLine("============================================================================\r");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                /*int counter3 = 0;
                if (selectedtool == 1 || selectedtool == 2 || selectedtool == 3 || selectedtool == 4 || selectedtool == 5 || selectedtool == 6)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                        counter3++;
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                        counter3++;
                    }
                }*/
                Console.WriteLine("\n\n============================================================================");
                Console.Write("Select a Tool to Remove Quantity (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
                int selectedtoolname = Convert.ToInt32(Console.ReadLine());

                switch (selectedtoolname)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;
                        string aToolType = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                    case 8:
                        delete(aTool, quantity);
                        break;
                }


                //Deletes/Decreases Quantity of Selected Tool
                if (selectedtoolname == 0)
                {
                    aTool.Quantity = aTool.Quantity - quantity;
                }
                

            }
            catch (Exception e)
            {
                Menus.Error(e);
            }
                 
    }


        public void add(Member aMember)
        {
            try
            {


                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Add New Member==========\n");
                Console.Write("\nFirst Name: ");
                string fistname = Console.ReadLine();
                Console.Write("\nLast Name: ");
                string lastname = Console.ReadLine();
                Console.Write("\nContact Number: ");
                string contactnumber = Console.ReadLine();
                string pin;

                bool validpin = false;
                int PIN = 0000;

                while (!validpin)
                {
                    Console.Write("\n\nPIN (4 digit number): ");
                    pin = Console.ReadLine();
                    bool validPINparse = Int32.TryParse(pin, out PIN);
                    if (validPINparse && PIN >= 0 && PIN <= 9999)
                    {
                        validpin = true;
                    }
                }


                Console.Clear();
                Console.WriteLine("==========Review New Member==========\n");
                Console.WriteLine("First Name: " + fistname);
                Console.WriteLine("Last Name: " + lastname);
                Console.WriteLine("Contact Number: " + contactnumber);
                Console.WriteLine("PIN: " + PIN);
                Console.WriteLine("=====================================\n");
                Console.Write("Enter Y to Add New Member || Enter N to Start Over: ");
                string confirm = Console.ReadLine();
                string ignorelower = confirm.ToUpper();

                if (ignorelower == "Y")
                {
                    Member newMember = new Member(fistname, lastname, contactnumber, Convert.ToString(PIN));
                    Array.Resize(ref ListMembers, ListMembers.Length + 1);
                    ListMembers[^1] = newMember;
                    Console.Write("Successfully Added!");                   
                    Console.ReadKey();
                                                                    
                }
                else
                {
                    add(aMember);
                }
                
            }
            catch
            {
                Menus.Error("");
            }

        }

        public void delete(Member aMember)
        {


            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Remove Member==========\n");
            Console.Write("Enter Name: ");
            string amember = Console.ReadLine();

            try
            {
                Console.WriteLine("\nPlease Wait...");
                Member result = memberCollection.search(amember);

                bool ReviewDeletedMember = false;
                while(!ReviewDeletedMember)
                {
                    Console.Clear();
                    Console.WriteLine("==========Review Deleted Member==========");
                    Console.WriteLine("Fist Name: " + result.FirstName);
                    Console.WriteLine("Last Name: " + result.LastName );
                    Console.WriteLine("Contact Numebr: "+ result.ContactNumber);
                    Console.WriteLine("PIN: " + result.PIN);
                    Console.Write("Enter Y to Add New Member || Enter N to Start Over: ");
                    string confirm = Console.ReadLine();

                    switch (confirm.ToLower())
                    {
                        case "y":
                            Console.WriteLine("\nPlease Wait...");
                            memberCollection.delete(result);
                            Console.WriteLine("\nSuccessfully Removed!");
                            return;
                        case "n":
                            return;
                    }

                }

            }
            catch (Exception e)
            {
                Menus.Error(e);
            }



        }

        public void displayBorrowingTools(Member aMember)
        {
            if (aMember.BorrowedTools.Count == 0)
                throw new Exception("No Tools Are Currently Borrowed.");

            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Currently Borrowed Tools==========\n");

            for (int i = 0; i < aMember.BorrowedTools.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + aMember.BorrowedTools[i].Name);
            }

            Console.WriteLine("\n========================================\n");
            Console.Write("\nPress any key to return to the main menu.");
            Console.ReadKey();       
        }

        public void displayTools(string aToolType)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Display all Tools of a Tool Type==========\n");
                string[][] ToolType = new string[9][];
                int counter = 0;

                ToolType[0] = new string[] { "Gardening Tools", "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheel Barrows", "Garden Power Tools" };
                ToolType[1] = new string[] { "Flooring Tools", "Scrapers", "Floor Lasers", "Floor Leveling Tools", "Floor Leveling Materials", "Floor Hand Tools", "Tiling Tools" };
                ToolType[2] = new string[] { "Fencing Tools", "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
                ToolType[3] = new string[] { "Measuring Tools", "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature and Humidity Tools", "Levelling Tools", "Markers" };
                ToolType[4] = new string[] { "Cleaning Tools", "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
                ToolType[5] = new string[] { "Painting Tools", "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
                ToolType[6] = new string[] { "Electronic Tools", "VoltageTester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
                ToolType[7] = new string[] { "Electricity Tools", "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" };
                ToolType[8] = new string[] { "Automotive Tools", "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

                for (int j = 0; j < ToolType.Length; j++)
                {
                    Console.Write(" " + counter + ". " + ToolType[j][0] + "\n");
                    counter++;
                }
                Console.WriteLine("\n=================================\n");
                Console.Write("Select a Category (Enter Number) || Enter 9 to Retun to Main Menu: ");

                int selectedtooltype = Convert.ToInt32(Console.ReadLine());
                switch (selectedtooltype)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;
                        Tool aTool = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                }

                Console.WriteLine("\n========Select A Tool Type=======\n");
                int counter2 = 0;
                if (selectedtooltype == 1 || selectedtooltype == 3 || selectedtooltype == 4 || selectedtooltype == 5 || selectedtooltype == 8)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                        counter2++;
                    }
                }
                Console.WriteLine("\n=================================\n");
                Console.Write("Select a Tool type (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
                int selectedtool = Convert.ToInt32(Console.ReadLine());

                switch (selectedtool)
                {
                    case 9:
                        Menus menu = new Menus();
                        Member aMember = null;
                        Tool aTool = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                    case 8:
                        displayTools(aToolType);
                        break;
                    default:
                        Menus.Error("");
                        return;
                }

                Console.WriteLine("\n==========Select Tool Name==========\n");
                Console.WriteLine("============================================================================\r");
                Console.WriteLine("Tool Name                                     Available              Total");
                Console.WriteLine("============================================================================\r");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                /*int counter3 = 0;
                if (selectedtool == 1 || selectedtool == 2 || selectedtool == 3 || selectedtool == 4 || selectedtool == 5 || selectedtool == 6)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                        counter3++;
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                        counter3++;
                    }
                }*/
                Console.WriteLine("\n\n============================================================================");
                Console.Write("Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
                int selectedtoolname = Convert.ToInt32(Console.ReadLine());
                switch (selectedtoolname)
                {
                    case 8:
                        Menus menu = new Menus();
                        Member aMember = null;
                        Tool aTool = null;
                        menu.MemberMenu(aMember, aToolType, aTool);
                        break;
                    case 9:
                        displayTools(aToolType);
                        break;
                }

            }
            catch (Exception e)
            {
                Menus.Error("");

            }
        }

        

        public void borrowTool(Member aMember, Tool aTool)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Borrow Tool==========\n");
            

            string[][] ToolType = new string[9][];
            int counter = 0;

            ToolType[0] = new string[] { "Gardening Tools", "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheel Barrows", "Garden Power Tools","Some Trimmers", "A Lawn Mower", "A HandTool", "A Wheel Barrow", "A Garden Power Tool"};
            ToolType[1] = new string[] { "Flooring Tools", "Scrapers", "Floor Lasers", "Floor Leveling Tools", "Floor Leveling Materials", "Floor Hand Tools", "Tiling Tools" };
            ToolType[2] = new string[] { "Fencing Tools", "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
            ToolType[3] = new string[] { "Measuring Tools", "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature and Humidity Tools", "Levelling Tools", "Markers" };
            ToolType[4] = new string[] { "Cleaning Tools", "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
            ToolType[5] = new string[] { "Painting Tools", "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
            ToolType[6] = new string[] { "Electronic Tools", "VoltageTester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
            ToolType[7] = new string[] { "Electricity Tools", "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" };
            ToolType[8] = new string[] { "Automotive Tools", "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

            for (int j = 0; j < ToolType.Length; j++)
            {
                Console.Write(" " + counter + ". " + ToolType[j][0] + "\n");
                counter++;
            }
            Console.WriteLine("\n=================================\n");
            Console.Write("Select a Category (Enter Number) || Enter 9 to Retun to Main Menu: ");

            int selectedtooltype = Convert.ToInt32(Console.ReadLine());
            switch (selectedtooltype)
            {
                case 9:
                    Menus menu = new Menus();
                    int quantity = 0;
                    menu.StaffMenu(aMember, aTool, quantity);
                    break;
            }


            Console.WriteLine("\n========Select A Tool Type=======\n");
            int counter2 = 0;
            if (selectedtooltype == 1 || selectedtooltype == 3 || selectedtooltype == 4 || selectedtooltype == 5 || selectedtooltype == 8)
            {
                for (int i = 1; i < 7; i++)
                {
                    Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                    counter2++;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.Write(("" + counter2 + "." + ToolType[selectedtooltype][i] + "\n"));
                    counter2++;
                }
            }
            Console.WriteLine("\n=================================\n");
            Console.Write("Select a Tool type (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
            int selectedtool = Convert.ToInt32(Console.ReadLine());

            switch (selectedtool)
            {
                case 9:
                    Menus menu = new Menus();
                    string aToolType = null;
                    menu.MemberMenu(aMember, aToolType, aTool);
                    break;
                case 8:
                    borrowTool(aMember, aTool);
                    break;
            }

            Console.WriteLine("\n==========Select Tool Name==========\n");
            Console.WriteLine("============================================================================\r");
            Console.WriteLine("Tool Name                                     Available              Total");
            Console.WriteLine("============================================================================\r");
            /*int counter3 = 0;
            if (selectedtool == 1 || selectedtool == 2 || selectedtool == 3 || selectedtool == 4 || selectedtool == 5 || selectedtool == 6)
            {
                for (int i = 1; i < 7; i++)
                {
                    Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                    counter3++;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.Write(("" + counter3 + "." + ToolType[selectedtool][i] + "\n"));
                    counter3++;
                }
            }*/
            Console.WriteLine("\n\n============================================================================");
            Console.Write("Select a Tool to Borrow (Enter Number) || Enter 8 to Return to Category || Enter 9 to Return to Main Menu : ");
            int selectedtoolname = Convert.ToInt32(Console.ReadLine());

            switch (selectedtoolname)
            {
                case 9:
                    Menus menu = new Menus();
                    string aToolType = null;
                    menu.MemberMenu(aMember, aToolType, aTool);
                    break;
                case 8:
                    borrowTool(aMember, aTool);
                    break;
            }

            
            Console.Clear();
            Console.WriteLine("==========Review Borrowed Tool==========\n");
            Console.WriteLine("Tool Name: " + ToolType[selectedtoolname]);
            Console.WriteLine("Tool Category: " + ToolType[selectedtooltype][0].ToString());
            Console.WriteLine("Tool Type: " + ToolType[selectedtooltype][selectedtool].ToString());
            Console.WriteLine("\n====================================\n");
            Console.Write("Enter Y to Borrow Tool || Enter N to Start Over: ");
            string confirm = Console.ReadLine();

            switch (confirm)
            {
                case "y":
                Console.WriteLine("\nPlease Wait...");
                    if (aMember.BorrowedTools.Count >= 3)
                        throw new Exception("You have reached you quota. Only a Maximum of 3 Tools can be borrowed."+
                            "Please retrun a tool to borrow another.");
                    int quantity = 0;
                    aTool.Quantity = aTool.Quantity - quantity;
                    return;
                case "n":
                    return;
            }
            


        }

        public void returnTool(Member aMember, Tool aTool)
        {
            if (aMember.BorrowedTools.Count == 0)
            {
                Menus.Error("No Tools Exist.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Return Tool==========\n");

                for (int i = 0; i < aMember.BorrowedTools.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + aMember.BorrowedTools[i].Name);

                }

                Tool returtoolnoption = null;
                int tooloption = 0;
                bool returnvalidtooloption = false;

                while (!returnvalidtooloption)
                {
                    string ToolOption = Console.ReadLine();
                    bool ValidToolOption = Int32.TryParse(ToolOption, out tooloption);

                    if (ValidToolOption)
                    {
                        returnvalidtooloption = true;
                        if (tooloption == 0)
                        {
                            return;
                        }
                        if (tooloption <= aMember.BorrowedTools.Count)
                        {
                            returtoolnoption = aMember.BorrowedTools[tooloption - 1];
                        }
                    }
                }

                try
                {
                    Console.Write("\nPlease wait...");
                    //returnTool(returnoption);                   
                    aMember.BorrowedTools.RemoveAt(tooloption - 1);
                }
                catch (Exception e)
                {
                    Menus.Error(e);
                }
            }

           
        }

        public string[] listTools(Member aMember)
        {
            throw new NotImplementedException();
        }

        public void displayTopTHree()
        {
            List<Tool> toollist = new List<Tool>();
            toollist = toollist.OrderByDescending(tool => tool.GetBorrowers).Take(3).ToList();

            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Top Three Most Frequentely Rented Tools==========\n");

            Console.WriteLine("Some Tools");
            Console.WriteLine("Another Tool");
            Console.WriteLine("Hashing Tool");

            // convert a complete binary tree into a heap
            // and sort the elements in an array 
            Tool[] HeapBottomUp(Tool[] heap, int idx)
            {
                int n = (heap.Length - idx - 1);

                for (int i = n / 2; i >= 0; i--)
                {
                    int k = i;
                    Tool value = heap[idx + k];
                    bool isHeap = false;
                    while (!isHeap && 2 * k <= n)
                    {
                        int j = 2 * k; //the left child of k
                        if (j < n) //two children
                        {

                            if (heap[idx + j].NoBorrowings < heap[idx + j + 1].NoBorrowings)
                            {
                                j = j + 1;//j is the larger child of k
                            }
                        }
                        if (value.NoBorrowings >= heap[idx + j].NoBorrowings)
                        {
                            isHeap = true;
                        }
                        else
                        {
                            heap[idx + k] = heap[idx + j];
                            k = j;
                        }
                    }

                    heap[idx + k] = value;
                }

                //repeatly remove the maximum key from the heap and then rebuild the heap
                for (int i = 0; i < 3 && i < heap.Length - 2; i++)
                {
                    heap = HeapBottomUp(heap, i);
                }
                return heap;

            }

            Console.WriteLine("\n=============================================================\n");
            Console.Write("Press Any Key to Return to Main Menu");
            Console.ReadKey();
        }      
    }
}

