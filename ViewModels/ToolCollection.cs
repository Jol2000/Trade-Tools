using System;
using System.Collections.Generic;
using System.Text;
using Assignment;
using Interfaces;

namespace CAB301_TradeTools.ViewModels
{
    public class ToolCollection : iToolCollection

    {
        private Tool[] getTools;
        private ToolLibrarySystem ToolLibrary;
        public List<string> CollectTool = new List<string>();

        public int Number
        {
            get => throw new NotImplementedException();
        }

        public void add(Tool aTool)
        {
            CollectTool.Add(aTool.Name + aTool.Quantity + aTool.NoBorrowings);
        }

        public void delete(Tool aTool)
        {
            CollectTool.Remove(aTool.Name + aTool.Quantity + aTool.NoBorrowings);
        }

        public bool search(Tool aTool)
        {
            if (CollectTool.Contains(aTool.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tool[] toArray()
        {
            getTools.SetValue(CollectTool, 0);
            return getTools;
        }
    }
}
