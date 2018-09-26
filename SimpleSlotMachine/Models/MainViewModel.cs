using SimpleSlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSlotMachine.UI.Models
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.CurrentWin = 0;
            this.StakeAmount = 0;
            this.TotalCredits = 0;
            this.GameStarted = false;
            this.Rows = new List<Row>() { new Row(true), new Row(true), new Row(true), new Row(true) };
        }
        public decimal TotalCredits { get; set; }
        public decimal StakeAmount { get; set; }
        public decimal CurrentWin { get; set; }
        public bool GameStarted { get; set; }
        public List<Row> Rows { get; set; }
    }
}