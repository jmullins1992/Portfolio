using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace FlooringMastery.Data.Test
{
    public class TestStateTaxInfoRepository : IStateTaxInfoRepository
    {
        public List<StateTaxInfo> ListAll()
        {
            return new List<StateTaxInfo>
            {
                new StateTaxInfo() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 0.0625M},
                new StateTaxInfo() {StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 0.075M},
                new StateTaxInfo() {StateAbbreviation = "NY", StateName = "New York", TaxRate = 0.1M}
            };
        }
    }
}
