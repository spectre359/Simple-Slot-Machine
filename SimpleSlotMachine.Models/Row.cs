using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSlotMachine.Models
{
    public class Row
    {
        public Row()
        {
            this.Symbols = new List<Symbol>();
        }
        public Row(bool addSymbols = false)
        {
            if (addSymbols)
            {
                this.Symbols = new List<Symbol>
                {
                    new Symbol("Apple"),
                    new Symbol("Banana"),
                    new Symbol("Pineapple")
                };
            }
        }
        public List<Symbol> Symbols { get; set; }
    }
}