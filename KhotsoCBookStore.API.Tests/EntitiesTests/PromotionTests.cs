using System;
using KhotsoCBookStore.API.Entities;
using Xunit;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class PromotionTests: IDisposable
    {
        Promotion promotion;
        public PromotionTests()
        {
            promotion = new Promotion
            {
                PromotionId = new Guid("F6F0FB84-3ABB-45AE-BFCD-C30014A40AF3"),
                MinimumRetail =25.22M,
                MaximumRetail =99.55M
            };
        }

        public void Dispose()
        {
           promotion  = null;
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            promotion.PromotionId = new Guid();

            //Assert
            Assert.Equal(expected, promotion.PromotionId);
        }

        [Fact]
        public void CanChangeMinimumRetail()
        {
            //Arrange
            //Act
            promotion.MinimumRetail = 33.22M;

            //Assert
            Assert.Equal(33.22M, promotion.MinimumRetail);
        }

            [Fact]
        public void CanChangeMaximumRetail()
        {
            //Arrange
            //Act
            promotion.MaximumRetail = 33.22M;

            //Assert
            Assert.Equal(33.22M, promotion.MaximumRetail);
        }

        
        [Fact]
        public void CanChangeUpdatedBy()
        {
            //Arrange
            //Act
            promotion.UpdatedBy = "MKBay";

            //Assert
            Assert.Equal("MKBay", promotion.UpdatedBy);
        }

        
        [Fact]
        public void CanChangeUpdatedOn()
        {
             //Arrange
            var expected = new DateTime(2021,05,05);
            
            //Act
            promotion.UpdatedOn =new DateTime(2021,05,05);

            //Assert
            Assert.Equal(expected, promotion.UpdatedOn);
        }
    }
}
    