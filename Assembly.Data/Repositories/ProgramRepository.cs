using Assembly.Data.Data;
using Assembly.Data.Exceptions;
using Assembly.Data.Mappers;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly GymContext _context;

        public ProgramRepository(GymContext context)
        {
            _context = context;
        }

        public async Task AddProgram(ProgramDomain program)
        {
            try
            {
                await _context.Programs.AddAsync(ProgramCodesMapper.MapFromDomain(program));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ProgramRepositoryException($"AddProgram {ex}");
            }
        }

        public async Task<List<ProgramDomain>> GetAllPrograms()
        {
            try
            {
                return await _context.Programs
                    .Include(p => p.Members)
                    .Select(p => ProgramCodesMapper.MapToDomain(p))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ProgramRepositoryException($"GetAllProgram {ex}");
            }
        }

        public async Task<ProgramDomain> GetProgram(string programCode)
        {
            try
            {
                return ProgramCodesMapper.MapToDomain(await _context.Programs.Where((p) => p.ProgramCode == programCode).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new ProgramRepositoryException($"GetProgram {ex}");
            }
        }

        public async Task UpdateProgram(ProgramDomain program)
        {
            try
            {
                _context.Programs.Update(ProgramCodesMapper.MapFromDomain(program));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ProgramRepositoryException($"UpdateProgram {ex}");
            }
        }
    }
}
