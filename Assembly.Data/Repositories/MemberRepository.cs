using Assembly.Data.Data;
using Assembly.Data.Exceptions;
using Assembly.Data.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Repositories;

public class MemberRepository : IMemberRepository
{
    private GymContext _context;

    public MemberRepository(GymContext ctx)
    {
        _context = ctx;
    }

    public async Task<List<MemberDomain>> GetMembers()
    {
        try
        {
            return await _context.Members.Select(x => MemberMapper.MapToDomain(x)).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("GetMembers", ex);
        }
    }

    public async Task<MemberDomain> GetMemberById(int id)
    {
        try
        {
            var member = await _context.Members.Where(m => m.MemberId == id).AsNoTracking().FirstOrDefaultAsync();

            if (member != null) return MemberMapper.MapToDomain(member);

            else throw new MemberRepositoryException("Member not found");
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("GetMember", ex);
        }
    }

    public async Task AddMember(MemberDomain member)
    {
        if (member == null) throw new MemberRepositoryException("Member is empty");
        try
        {
            await _context.Members.AddAsync(MemberMapper.MapFromDomain(member));
            SaveAndClear();
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("AddMember",  ex);
        }
    }

    public void UpdateMember(MemberDomain member)
    {
        try
        {
            Member m = MemberMapper.MapFromDomain(member);
            _context.Members.Update(m);
            SaveAndClear();
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("UpdateMember", ex);
        }
    }

    public void DeleteMember(MemberDomain member)
    {
        try
        {
            if (member != null)
            {
                _context.Members.Remove(MemberMapper.MapFromDomain(member));
                SaveAndClear();
            }
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("DeleteMember", ex);
        }
    }

    private void SaveAndClear()
    {
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
