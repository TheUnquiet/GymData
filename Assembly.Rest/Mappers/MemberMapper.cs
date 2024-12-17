using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class MemberMapper
    {
        public static MemberOutputDto MapToOutputDto(MemberDomain member)
        {
            return new MemberOutputDto()
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Address = member.Address,
                Birthday = member.Birthday,
                Intrest = member.Intressest,
                MemberType = member.MemberType,
            };
        }

        public static MemberDomain MapFromInputDto(MemberInputDto dto)
        {
            return new MemberDomain(dto.FirstName, dto.LastName, dto.Email, dto.Address, dto.Birthday, dto.Intrest, "Bronze");
        }
    }
}
