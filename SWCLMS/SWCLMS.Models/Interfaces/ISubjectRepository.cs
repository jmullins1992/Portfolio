using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAllSubjects();
    }
}
