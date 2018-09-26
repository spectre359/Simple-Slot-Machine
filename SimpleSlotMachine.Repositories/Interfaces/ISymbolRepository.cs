using SimpleSlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSlotMachine.Repositories.Interfaces
{
    public interface ISymbolRepository
    {
        List<Row> GetResultRows();

        decimal CalculateTotal(List<Row> newRows);
    }
}
