using BusinessLayer.Entities;
using Xunit;
using System;

namespace EntitiesTest
{
    public class EntityTests
    {
        [Fact]
        public void CustomerTest()
        {
            //Arrange
            Customer c = new("Y", "V", "email.org");
            c.AddWallet("w", 100, Currency.USD, "");
            Wallet w = new Wallet(c, "w2", 200, Currency.USD, "");

            //Act

            //Assert
            
        }
    }
}
