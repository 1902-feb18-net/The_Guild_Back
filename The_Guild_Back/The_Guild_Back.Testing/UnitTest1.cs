using System;
using Xunit;
using The_Guild_Back.BLL;

namespace The_Guild_Back.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void AdventurerPartyNameCannotBeSetNull()
        {
            AdventurerParty ap = new AdventurerParty();

            Assert.Throws<ArgumentNullException>(() => ap.Nam = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void AdventurerPartyNameCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            AdventurerParty ap = new AdventurerParty();

            Assert.Throws<ArgumentException>(() => ap.Nam = arg);
        }


        [Fact]
        public void ProgressNameCannotBeSetNull()
        {
            Progress status = new Progress();

            Assert.Throws<ArgumentNullException>(() => status.Nam = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void ProgressNameCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Progress status = new Progress();

            Assert.Throws<ArgumentException>(() => status.Nam = arg);
        }

        [Fact]
        public void RankNameCannotBeSetNull()
        {
            Ranks rank = new Ranks();

            Assert.Throws<ArgumentNullException>(() => rank.Nam = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void RankNameCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Ranks rank = new Ranks();

            Assert.Throws<ArgumentException>(() => rank.Nam = arg);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void RankFeeCannotBeSetNegative(decimal arg)
        {
            Ranks rank = new Ranks();

            Assert.Throws<ArgumentOutOfRangeException>(() => rank.Fee = arg);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void RankRequirementsNumRequestsCannotBeSetNegative(int arg)
        {
            RankRequirements rank = new RankRequirements();

            Assert.Throws<ArgumentOutOfRangeException>(() => rank.NumberRequests = arg);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void RankRequirementsMinTotalStatsCannotBeSetNegative(int arg)
        {
            RankRequirements rank = new RankRequirements();

            Assert.Throws<ArgumentOutOfRangeException>(() => rank.MinTotalStats = arg);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void RequestCostCannotBeSetNegative(decimal arg)
        {
            Request rank = new Request();

            Assert.Throws<ArgumentOutOfRangeException>(() => rank.Cost = arg);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void RequestRewardCannotBeSetNegative(decimal arg)
        {
            Request rank = new Request();

            Assert.Throws<ArgumentOutOfRangeException>(() => rank.Reward = arg);
        }

        [Fact]
        public void RequestDescriptionCannotBeSetNull()
        {
            Request request = new Request();

            Assert.Throws<ArgumentNullException>(() => request.Descript = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void RequestDescriptionCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Request request = new Request();

            Assert.Throws<ArgumentException>(() => request.Descript = arg);
        }

        [Fact]
        public void RequestRequirementsCannotBeSetNull()
        {
            Request request = new Request();

            Assert.Throws<ArgumentNullException>(() => request.Requirements = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void RequestRequirementsCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Request request = new Request();

            Assert.Throws<ArgumentException>(() => request.Requirements = arg);
        }

        [Fact]
        public void UserFirstNameCannotBeSetNull()
        {
            Users user = new Users();

            Assert.Throws<ArgumentNullException>(() => user.FirstName = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void UserFirstNameCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Users user = new Users();

            Assert.Throws<ArgumentException>( () => user.FirstName = arg);
        }

        [Fact]
        public void UserLastNameCannotBeSetNull()
        {
            Users user = new Users();

            Assert.Throws<ArgumentNullException>(() => user.FirstName = null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void UserLastNameCannotBeSetEmptyOrWhiteSpace(string arg)
        {
            Users user = new Users();

            Assert.Throws<ArgumentException>(() => user.LastName = arg);
        }

    }
}
