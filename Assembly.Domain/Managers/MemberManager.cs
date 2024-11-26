using Assembly.Domain.Exceptions.Managers;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Managers
{
    public class MemberManager
    {
        private IMemberRepository repo;

        public MemberManager(IMemberRepository repository)
        {
            repo = repository;
        }

        public async Task<MemberDomain> GetMember(int id)
        {
            try
            {
                return await repo.GetMember(id);
            }
            catch (Exception ex)
            {
                throw new MemberManagerException("GetMember", ex);
            }
        }

        public async Task<List<MemberDomain>> GetMembers()
        {
            try
            {
                return await repo.GetMembers();
            }
            catch (Exception ex)
            {
                throw new MemberManagerException("GetMembers", ex);
            }
        }
    }
}
