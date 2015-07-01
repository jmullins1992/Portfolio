using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using System.IO;

namespace FlooringMastery.Data
{
    public class StateTaxInfoRepository : IStateTaxInfoRepository
    {
        private const string FilePath = @"DataFiles\States.txt";
        private List<StateTaxInfo> _stateTaxes;

        public List<StateTaxInfo> ListAll()
        {
            _stateTaxes = new List<StateTaxInfo>();
            string[] reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var stateTax = new StateTaxInfo()
                {
                    StateAbbreviation = columns[0],
                    TaxRate = decimal.Parse(columns[1]),                    
                };

                _stateTaxes.Add(stateTax);
            }

            return _stateTaxes;
        }
    }
}
