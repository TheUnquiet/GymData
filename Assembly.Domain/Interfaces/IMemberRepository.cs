using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<MemberDomain> GetMember(int id);

        Task<List<MemberDomain>> GetMembers();

        Task AddMember(MemberDomain member);

        void UpdateMember(MemberDomain member);

        Task DeleteMember(int id);
    }
}
