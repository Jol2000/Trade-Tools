using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment;
using CAB301_TradeTools.ViewModels;
using static CAB301_TradeTools.ViewModels.Tool;
using static CAB301_TradeTools.ViewModels.ToolLibrarySystem;


namespace CAB301_TradeTools.Views
{
    public class Menus 
    {
        readonly MemberCollection memberCollection = new MemberCollection();

        //LOGIN FUNCTIONS AND MENUS
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Login==========\n");
                Console.WriteLine("1. Staff Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("0. Exit\n");
                Console.WriteLine("=========================\r");
                Console.Write("\r\nSelect an option (1-2 or 0 to Main Menu): ");

                string myoptions = Console.ReadLine();
                bool acceptedoption = int.TryParse(myoptions, out int options);

                if (acceptedoption)
                {
                    switch (options)
                    {
                        case 1:
                            StaffLogin();
                            break;
                        case 2:
                            MemberLogin();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Error("Please ENTER a valid option");
                            break;

                    }
                }
            }

        }

        //STAFF FUNCTIONS AND MENUS 
        public void StaffLogin()
        {
            string username, password;

            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Staff Login==========\n");
            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.WriteLine("===============================\r\n");

            if (username == "staff" && password == "today123")
            {
                Member aMember = null;
                Tool aTool = null;
                int quantity = 0;
                StaffMenu(aMember, aTool, quantity);
            }
            else
            {
                Error("Login Failed. Please Try Again.");
            }


        }

        public void StaffMenu(Member aMember, Tool aTool, int quantity)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Staff Menu==========\n");
            Console.WriteLine("1. Add New Tool");
            Console.WriteLine("2. Add New Pieces to Existing Tool");
            Console.WriteLine("3. Remove Some Pieces of a Tool");
            Console.WriteLine("4. Register New Member");
            Console.WriteLine("5. Remove Member");
            Console.WriteLine("6. Find Contact Number of Member");
            Console.WriteLine("0. Return to Main Menu\n");
            Console.WriteLine("===============================\r");
            Console.Write("\r\nSelect an option (1-6 or 0 to Main Menu): ");

            string mystaffoptions = Console.ReadLine();

            try
            {
                int input = Int32.Parse(mystaffoptions);
                switch (input)
                {
                    case 1:
                        ToolLibrarySystem toollibbrary = new ToolLibrarySystem();
                        toollibbrary.add(aTool);
                        break;
                    case 2:
                        ToolLibrarySystem toollibbrary1 = new ToolLibrarySystem();
                        toollibbrary1.add(aTool, quantity);
                        break;
                    case 3:
                        ToolLibrarySystem toollibbrary2 = new ToolLibrarySystem();
                        toollibbrary2.delete(aTool, quantity);
                        break;
                    case 4:
                        ToolLibrarySystem toollibbrary3 = new ToolLibrarySystem();
                        toollibbrary3.add(aMember);
                        break;
                    case 5:
                        ToolLibrarySystem toollibbrary4 = new ToolLibrarySystem();
                        toollibbrary4.delete(aMember);
                        break;
                    case 6:
                        findmember();
                        break;
                    case 0:
                        Console.Clear();
                        MainMenu();
                        break;
                    default:
                        Menus.Error("Please Enter a Valid Option");
                        break;
                }
            }
            catch (Exception e)
            {
                if (e is FormatException)
                {
                    Menus.Error("Please ENTER a Valid Option");
                }
                else
                {
                    Menus.Error(e.Message);
                }
            }
            StaffMenu(aMember, aTool, quantity);
        }


        public void findmember()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Find Member==========\n");
            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter Lat Name: ");
            string lastname = Console.ReadLine();
            try
            {
                Member member = memberCollection.SearchMember(firstname, lastname);
                Console.WriteLine("==========Member==========\r");
                Console.WriteLine("Contact Number for " + firstname + " " + lastname + "is" + member.ContactNumber + "\n");
                Console.WriteLine("==========================\r" + "\n");
                Console.Write("Press Any Key to Continue");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Error(e);
            }

        }





        //MEMBER FUNCTIONS AND MENUS
        public void MemberLogin()
        {
            string Username, PIN;

            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\r");
            Console.WriteLine("==========Member Login==========\n");
            Console.Write("Enter Username (First Name + Last Name): ");
            Username = Console.ReadLine();
            Console.Write("Enter Password (4 Digit Number): ");
            PIN = Console.ReadLine();
            Console.WriteLine("===============================\r");

            if (Username == "JohnSmith" && PIN == "1234")
            {
                Member aMember = null;
                Tool aTool = null;
                string aToolType = null;
                MemberMenu(aMember, aToolType, aTool);
            }
            else
            {
                Error("Login Failed. Please Try Again.");
            }

            /*try
            {
                Member aMember = null;
                Tool aTool = null;
                string aToolType = null; 
                Member member = memberCollection.LoginMember(Username, PIN);
                MemberMenu(aMember,aToolType, aTool);
            }
            catch (Exception e)
            {
                Error(e);
            }*/


        }
    
        public void MemberMenu(Member aMember, string aToolType, Tool aTool)
        {
          
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\r");
                Console.WriteLine("==========Member Menu==========\n");
                Console.WriteLine("1. Display all Tools of a Tool Type");
                Console.WriteLine("2. Borrow Tool");
                Console.WriteLine("3. Return Tool");
                Console.WriteLine("4. Currently Rented Tools");
                Console.WriteLine("5. Top Three Most Frequentely Rented Tools");
                Console.WriteLine("0. Return to Main Menu\n");
                Console.WriteLine("===============================\r");
                Console.Write("\r\nSelect an option (1-5 or 0 to Main Menu): ");

                string mymemberoptions = Console.ReadLine();
                try
                {
                    int input = Int32.Parse(mymemberoptions);
                    switch (input)
                    {
                        case 1:
                            ToolLibrarySystem toollibbrary = new ToolLibrarySystem();
                            toollibbrary.displayTools(aToolType);
                            break;
                        case 2:
                            ToolLibrarySystem toollibbrary1 = new ToolLibrarySystem();
                            toollibbrary1.borrowTool(aMember, aTool);
                            break;
                        case 3:
                            ToolLibrarySystem toollibbrary2 = new ToolLibrarySystem();
                            toollibbrary2.returnTool(aMember, aTool);
                            break;
                        case 4:
                            ToolLibrarySystem toollibbrary3 = new ToolLibrarySystem();
                            toollibbrary3.displayBorrowingTools(aMember);
                            break;
                        case 5:
                            ToolLibrarySystem toollibbrary4 = new ToolLibrarySystem();
                            toollibbrary4.displayTopTHree();
                            break;
                        case 0:
                            Console.Clear();
                            MainMenu();
                            break;
                        default:
                            Menus.Error("Please Enter a Valid Option");
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Menus.Error("Please ENTER a Valid Option");
                    }
                    else
                    {
                        Menus.Error(e.Message);
                    }
                }
                MemberMenu(aMember, aToolType, aTool);
        }
       
        public static void Error(Exception e)
        {
            Error(e.Message);
        }

        public static void Error(string MSG)
        {
            Console.Clear();
            Console.WriteLine("*************ERROR*************\n");
            Console.WriteLine("Error has occurred. \r" + MSG +"\n");
            Console.WriteLine("*******************************\n");
            Console.Write("Press Any Key to Continue\n"); 
            Console.ReadKey();

        }

        


    }
}
