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
        private readonly IMemberRepository repo;

        public MemberManager(IMemberRepository repository)
        {
            repo = repository;
        }

        public async Task<MemberDomain> GetMemberById(int id)
        {
            try
            {
                return await repo.GetMemberById(id);
            }
            catch (Exception ex)
            {
                throw new MemberManagerException($"GetMember {ex}");
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

        public async Task AddMember(MemberDomain member)
        {
            try
            {
                await repo.AddMember(member);
            }
            catch (Exception ex)
            {
                throw new MemberManagerException($"AddMember {ex}");
            }
        }

        public async void DeleteMember(int id)
        {
            try
            {
                var member = await repo.GetMemberById(id);
                if (member != null)
                {
                    repo.DeleteMember(member);
                }
            }
            catch (Exception ex)
            {
                throw new MemberManagerException("DeleteMember", ex);
            }
        }

        public void UpdateMember(MemberDomain member)
        {
            try
            {

                repo.UpdateMember(member);
            }
            catch (Exception ex)
            {
                throw new MemberManagerException("UpdateMember", ex);
            }
        }
    }
}
