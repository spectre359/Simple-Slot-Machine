using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SimpleSlotMachine.Models
{
    public class Symbol
    {
        
        public Symbol(string name)
        {
            this.Name = name;
            string coefficient = ConfigurationManager.AppSettings[name + "_coefficient"];
            string probability = ConfigurationManager.AppSettings[name + "_probability"];
            if (!String.IsNullOrEmpty(coefficient))
                this.Coefficient = decimal.Parse(coefficient);
            if (!String.IsNullOrEmpty(probability))
                this.Probability = int.Parse(probability);

        }
        public string Name { get; }
        public decimal Coefficient { get; }
        public int Probability { get;  }
    }
}