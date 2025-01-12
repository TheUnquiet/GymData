using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public interface IProgramRepository
    {
        Task<List<ProgramDomain>> GetAllPrograms();

        Task<ProgramDomain> GetProgram(string programCode);

        Task AddProgram(ProgramDomain program);

        Task UpdateProgram(ProgramDomain program);
    }
}
