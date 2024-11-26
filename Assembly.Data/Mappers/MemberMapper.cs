using Assembly.Data.Exceptions;
using Assembly.Data.Models;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers;

public static class MemberMapper
{
    public static MemberDomain MapToDomain(Member member)
    {
        try
        {
            return new MemberDomain(member.MemberId, member.FirstName, member.LastName, member.Email, member.Address, member.Birthday, member.Interests, (MemberTypeDomain)Enum.Parse(typeof(MemberTypeDomain), member.Membertype));
        }
        catch (Exception ex)
        {
            throw new MapException("MemberMapper - MapToDomain", ex);
        }
    }

    public static Member MapFromDomain(MemberDomain member)
    {
        try
        {
            return new Member() { MemberId = member.Id, FirstName = member.FirstName, LastName = member.LastName, Email = member.Email, Address = member.Address, Birthday = member.Birthday, Interests = member.Intressest, Membertype = member.MemberType.ToString(), Cyclingsessions = (ICollection<Cyclingsession>)member.Cyclingssesions, ProgramCodes = (ICollection<Models.Program>)member.ProgramCodes, Reservations = (ICollection<Models.Reservation>)member.Reservations, RunningsessionMains = (ICollection<Models.RunningsessionMain>)member.RunningsessionMains};
        }
        catch (Exception ex)
        {
            throw new MapException("MemberMapper - MapFromDomain", ex);
        }
    }
}
