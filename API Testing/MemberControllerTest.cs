using Assembly.Domain.Interfaces;
using Assembly.Rest.Controllers;
using Moq;

namespace API_Testing
{
    public class MemberControllerTest
    {
        private readonly Mock<IMemberRepository> mockRepo;
        private readonly MemberController memberController;

        public MemberControllerTest()
        {
            mockRepo = new Mock<IMemberRepository>();
            memberController = new MemberController(mockRepo.Object);
        }

        [Fact]
        public void GET_UknownID_ReturnsNotFound()
        {

        }
    }
}