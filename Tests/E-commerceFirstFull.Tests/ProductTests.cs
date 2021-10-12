using E_commerceFirstFull.Controllers;
using E_commerceFirstFull.Models;

using Moq;
using Xunit;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceFirstFull.Tests
{
    public class ProductTests
    {
        [Fact]
        public void RepositoryReturnsValues()
        {
            var mockRep = new Mock<IProductRepository<Product>>();
            mockRep.Setup(rep => rep.Products).Returns(FormProduct());

            HomeController controller = new(mockRep.Object);


            var result = controller.Index() as ViewResult;

            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(result.Model);

            Assert.Equal(mockRep.Object.Products.Count(), model.Count());
        }

        [Fact]
        public void RepositoryReturnsNull()
        {
            var mockRep = new Mock<IProductRepository<Product>>();
            mockRep.Setup(rep => rep.Products).Returns(null as IEnumerable<Product>);

            HomeController controller = new(mockRep.Object);


            var result = controller.Index() as ViewResult;            

            Assert.Null(result.Model);
        }

        public List<Product> FormProduct()
        {
            return new List<Product> {
            new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Gothic",
                        Author = "Piranha Bytes",
                        Description = "War has been waged across the kingdom of Myrtana. Orcish hordes invaded human territory and the king of the land needed a lot of ore to forge enough weapons, should his army stand against this threat. Whoever breaks the law in these darkest of times is sentenced to serve in the giant penal colony of Khorinis, mining the so much needed ore." +
                        "The whole area, dubbed \"the Colony\", is surrounded by a magical barrier, a sphere two kilometers diameter, sealing off the penal colony from the outside world. The barrier can be passed from the outside in – but once inside, nobody can escape. The barrier was a double-edged sword - soon the prisoners took the opportunity and started a revolt. The Colony became divided into three rivaling factions and the king was forced to negotiate for his ore, not just demand it." +
                        "You are thrown through the barrier into this prison. With your back against the wall, you have to survive and form volatile alliances until you can finally escape.",
                        Price = 10.50m,
                        Features = "RPG, Single Player, Windows",
                        ImgPath = "",
                        CardPath = "card_gothic_1.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Gothic II",
                        Author = "Piranha Bytes",
                        Description = "You have torn down the magical barrier and released the prisoners of the Mine Valley. Now the former criminals of the forests and mountains are causing trouble around the capital of Khorinis. The town militia is powerless due to their low amount of force – outside of the town, everyone is helpless against the attacks of the bandits." +
                        "In the meanwhile, however, Xardas the Magician is preparing you to face a much larger threat: The dragons have been summoned to destroy humanity with their armies. And only the “Eye of Innos”, an ancient divine artifact, can help you stop them...",
                        Price = 12.99m,
                        Features = "RPG, Single Player, Windows",
                        ImgPath = "",
                        CardPath = "card_gothic_2.jpg"
                    }
            };

        }
    }
}
