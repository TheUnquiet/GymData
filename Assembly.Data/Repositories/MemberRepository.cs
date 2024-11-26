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

    public async Task DeleteMember(int id)
    {
        try
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                SaveAndClear();
            }
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("DeleteMember", ex);
        }
    }

    public async Task<MemberDomain> GetMember(int id)
    {
        try
        {
            var member = await _context.Members.FindAsync(id);

            if (member != null) return MemberMapper.MapToDomain(member);

            else return null;
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("GetMember", ex);
        }
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

    public void UpdateMember(MemberDomain member)
    {
        try
        {
            Member m = MemberMapper.MapFromDomain(member);
            _context.Members.Update(m);
        }
        catch (Exception ex)
        {
            throw new MemberRepositoryException("UpdateMember", ex);
        }
    }

    private void SaveAndClear()
    {
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
