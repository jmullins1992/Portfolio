using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using Models.Interfaces;

namespace FlooringMastery.Data.XMLRepos
{
    public class XMLStateTaxInfoRepository : IStateTaxInfoRepository
    {
        private const string FilePath = @"DataFiles\States.xml";
        private List<StateTaxInfo> _states; 

        public List<StateTaxInfo> ListAll()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<StateTaxInfo>));
            using (var textReader = new StreamReader(FilePath))
            {
                _states = (List<StateTaxInfo>)deserializer.Deserialize(textReader);
            }

            return _states;
        }
    }
}
