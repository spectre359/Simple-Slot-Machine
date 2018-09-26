using SimpleSlotMachine.Models;
using SimpleSlotMachine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSlotMachine.Repositories
{
    public class SymbolRepository : ISymbolRepository
    {

        private List<Symbol> GetAllSymbols()
        {
            return new List<Symbol>
                {
                    new Symbol("Apple"),
                    new Symbol("Banana"),
                    new Symbol("Pineapple"),
                    new Symbol("Wildcard")
                };
        }

        public List<Row> GetResultRows()
        {
            List<Row> result = new List<Row>();
            List<Symbol> allSymbols = GetAllSymbols();

            Random s_Random = new Random();

            for (var r = 0; r <= 3; r++)
            {
                Row newRow = new Row();
                for (var sy = 0; sy < 3; sy++)
                {
                    int perCent = s_Random.Next(0, 100);

                    //The logic for a winning chance is as follows:
                    //When the user rolls the "dice", the system calculates if the result is in one of the several ranges and picks the symbol(card) accordingly 
                    //The probability percent of the symbols(cards) can be changed in the Web.config file.
                    //Below is a table with the default result ranges:
                    // ;---------------;------------;
                    // ;Wildcard (5%)  ; 0-4    roll;
                    // ;Pineapple (15%); 5-19   roll;
                    // ;Banana (35%)   ; 20-54  roll;
                    // ;Apple (45%)    ; 55-100 roll;
                    // ;---------------;------------;
                    
                    List<int> probabilities = allSymbols.Select(s => s.Probability).OrderByDescending(p => p).ToList();

                    int currentWeight = 0;
                    for (var i = 0; i < probabilities.Count; i++)
                    {
                        currentWeight += probabilities[i];
                        if ((100 - currentWeight) <= perCent)
                        {
                            Symbol newSy = new Symbol(allSymbols.FirstOrDefault(s => s.Probability == probabilities[i]).Name);
                            newRow.Symbols.Add(newSy);
                            break;
                        }                       
                    }
                    
                }
                result.Add(newRow);
            }

            return result;
        }

        public decimal CalculateTotal(List<Row> newRows)
        {
            decimal totalCoefficient = 0m;

            for (int i = 0; i < newRows.Count; i++)
            {
                if (newRows[i].Symbols.All(s => s.Name == newRows[i].Symbols[0].Name)) //if all cards are the same, sum the coefficient
                    totalCoefficient += (newRows[i].Symbols[0].Coefficient * 3);
                else if (newRows[i].Symbols.Any(s => s.Name == "Wildcard")) //if there is a wildcard, check if the other cards are the same and then sum their coefficients
                    if (newRows[i].Symbols.Where(s => !s.Name.Equals("Wildcard")).All(s => s.Name == newRows[i].Symbols.FirstOrDefault(sy => !sy.Name.Equals("Wildcard")).Name))
                        totalCoefficient += (newRows[i].Symbols.FirstOrDefault(s => !s.Name.Equals("Wildcard")).Coefficient * 2)
                            + newRows[i].Symbols.FirstOrDefault(s => s.Name.Equals("Wildcard")).Coefficient;
            }

            return totalCoefficient;
        }
    }
}
