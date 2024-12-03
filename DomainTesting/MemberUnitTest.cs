using Assembly.Domain.Enums;
using Assembly.Domain.Exceptions;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTesting
{
    public class MemberUnitTest
    {
        MemberDomain member = new("Nene", "Leaks", "nene@gmail.com", "Atlanta", new DateOnly(2005, 07, 21), "Acting", MemberTypeDomain.Gold);

        #region Id
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestIdInValid(int id)
        {
            Assert.Throws<MemberDomainException>(() => member.SetId(id));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        public void TestIdValid(int id)
        {
            member.SetId(id);
            Assert.Equal(id, member.Id);
        }

        #endregion

        #region Name
        
        [Theory]
        [InlineData("Cynthia")]
        [InlineData("Pheadra")]
        public void TestFirstNameValid(string firstName)
        {
            member.SetFirstName(firstName);
            Assert.Equal(firstName, member.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData(null)]
        public void TestFirstNameInValid(string firstName)
        {
            Assert.Throws<MemberDomainException>(() => member.SetFirstName(firstName));
        }

        [Theory]
        [InlineData("Bailey")]
        [InlineData("Parks")]
        public void TestLastNameValid(string lastName)
        {
            member.SetLastName(lastName);
            Assert.Equal(lastName, member.LastName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData(null)]
        public void TestLastNameInValid(string lastName)
        {
            Assert.Throws<MemberDomainException>(() => member.SetLastName(lastName));
        }

        #endregion

        #region Email

        [Theory]
        [InlineData("nleaks@gmail.com")]
        [InlineData("nleaks@gmail.info")]
        public void TestEmailValid(string email)
        {
            member.SetEmail(email);
            Assert.Equal(email, member.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("nleaks@gmailcom")]
        [InlineData("nleaksgmailcom")]
        [InlineData("nleaksgmail.com")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData(null)]
        public void TestEmailInValid(string email)
        {
            Assert.Throws<MemberDomainException>(() => member.SetEmail(email));
        }

        #endregion

        #region Adress

        [Fact]
        public void TestAddressValid()
        {
            string address = "Bijlokevest 31";
            member.SetAddress(address);
            Assert.Equal(address, member.Address);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData(null)]
        public void TestAddressInValid(string address)
        {
            Assert.Throws<MemberDomainException>(() => member.SetAddress(address));
        }

        #endregion

        #region Birthday

        [Fact]
        public void TestBirthdayValid()
        {
            DateOnly date = new DateOnly(2000, 11, 26);
            member.SetBirthday(date);
            Assert.Equal(date, member.Birthday);
        }

        #endregion

        #region Intrest

        [Theory]
        [InlineData("Acting")]
        [InlineData("Singing")]
        public void TestIntrestValid(string intrest)
        {
            member.SetIntrest(intrest);
            Assert.Equal(intrest, member.Intressest);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData(null)]
        public void TestIntrestInValid(string intrest)
        {
            Assert.Throws<MemberDomainException>(() => member.SetIntrest(intrest));
        }

        #endregion

        #region CyclingSessions

        [Fact]
        public void TestAddCyclingssesionValid()
        {
            var cs = new CyclingssesionDomain();

            member.AddCyclingssesion(cs);
            Assert.Contains(cs, member.Cyclingssesions);
            Assert.Equal(cs, member.Cyclingssesions.ToList()[0]);
            Assert.Single(member.Cyclingssesions);

            // New session
            var cs1 = new CyclingssesionDomain();

            member.AddCyclingssesion(cs1);
            Assert.Contains(cs1, member.Cyclingssesions);
            Assert.Equal(cs1, member.Cyclingssesions.ToList()[1]);
            Assert.Equal(2, member.Cyclingssesions.Count);
        }

        #endregion
    }
}
