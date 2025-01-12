using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Managers
{
    public class ProgramManager
    {
        private readonly IProgramRepository _programRepository;

        public ProgramManager(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task AddProgram(ProgramDomain program)
        {
            try
            {
                await _programRepository.AddProgram(program);
            }
            catch (Exception ex)
            {
                throw new ProgramManagerException($"AddProgram {ex}");
            }
        }

        public async Task<List<ProgramDomain>> GetAllPrograms()
        {
            try
            {
                return await _programRepository.GetAllPrograms();
            }
            catch (Exception ex)
            {
                throw new ProgramManagerException($"GetAllProgram {ex}");
            }
        }

        public async Task<ProgramDomain> GetProgram(string programCode)
        {
            try
            {
                return await _programRepository.GetProgram(programCode);
            }
            catch (Exception ex)
            {
                throw new ProgramManagerException($"GetProgram {ex}");
            }
        }

        public async Task UpdateProgram(ProgramDomain program)
        {
            try
            {
                await _programRepository.UpdateProgram(program);
            }
            catch (Exception ex)
            {
                throw new ProgramManagerException($"UpdateProgram {ex}");
            }
        }
    }
}
