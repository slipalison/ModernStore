using ModernStore.Domain.Entities;
using ModernStore.Shared.ValueObjects;
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
            Custumer = new Custumer(new Name("Alison", "Amorim"), User,new Email("alison@alison.com"), new Document("37207835884"));
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
