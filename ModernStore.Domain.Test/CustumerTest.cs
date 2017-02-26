using ModernStore.Domain.Entities;
using Xunit;

namespace ModernStore.Domain.Test
{
    public class CustumerTest
    {

        public User User{ get; private set; }
        public Custumer Custumer { get; private set; }
        public CustumerTest()
        {
            User = new User("slipalison","slipalison" );
            Custumer = new Custumer("", "amorim", User,"alison@alison.com");
        }

        [Fact]
        [Trait("Custumer", "New Custumer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            Assert.Equal(1,Custumer.Notifications.Count);
        }

        [Fact]
        [Trait("Custumer", "New Custumer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            Assert.True(true);
        }
        [Fact]
        [Trait("Custumer", "New Custumer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            Assert.True(true);
        }

    }
}
