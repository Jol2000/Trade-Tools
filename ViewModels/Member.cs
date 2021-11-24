using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Assignment;
using CAB301_TradeTools;

namespace CAB301_TradeTools.ViewModels
{
    public class Member : iMember, IComparable<Member>
    {
        

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        public string UserName { get; set; }
        public List<Tool> BorrowedTools { get; set; }

        public List<string> CollectMembers = new List<string>();
        public string[] Tools { get; set; }

        public Member(string lastName, string firstName, string PIN, string contactNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = contactNumber;
            this.PIN = PIN;
            this.UserName = firstName + lastName;
            this.BorrowedTools = new List<Tool>();
        }

        public Member()
        {
        }

        //adds a borrowed tool from the list of tools that this member is currently holding
        public void addTool(Tool aTool)
        {
            CollectMembers.Add(aTool.Name + aTool.GetBorrowers + aTool.Quantity);
        }

        //CREDIT FROM WORKSHOP 5 
        //Compares Firstname and Lastname of a member
        public int CompareTo(Member other)
        {
          if(LastName.CompareTo(other.LastName)<0)
            {
                return -1;
            }
            else
            
                if(LastName.CompareTo(other.LastName)==0)
                {
                    return FirstName.CompareTo(other.FirstName);
                }
            
          else
            
                return 1;
            
           
        }

        //removes a borrowed tool from the list of tools that this member is currently holding
        public void deleteTool(Tool aTool)
        {
            CollectMembers.Remove(aTool.Name + aTool.Quantity + aTool.GetBorrowers);
        }

       

        public override string ToString()
        {
            return (FirstName + " " + LastName + " " + ContactNumber+""+ PIN+""+ UserName.ToString() + "\n");
        }
    }
}
