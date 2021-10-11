using System;
using Microsoft.EntityFrameworkCore;
using E_commerceFirstFull.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerceFirstFull.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            for (int i = 0; i < 5; i++)
            {
                builder.HasData(
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
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Gothic III",
                        Author = "Piranha Bytes",
                        Description = "Myrtana, a world in upheaval: overrun by orcs from the dark lands in the north, King Rhobar is defending Vengard, the former stronghold of the humans, with his last troop of followers. Chaos reigns without: rebels are offering resistance, and the Hashishin of the south are openly collaborating with the orcs." +
                        "Rumours that the nameless hero of Khorinis is on his way to the mainland spawn both hope and worry. Whose side will he take? Who will feel his wrath, who enjoy his favor? Only one thing is sure: his deeds are going to change Myrtana forever..." +
                        "Liberation or annihilitaion – the fate of the world of Gothic lies in your hands! Create your own individual gaming experience through different solution paths.",
                        Price = 17.80m,
                        Features = "RPG, Single Player, Windows",
                        ImgPath = "",
                        CardPath = "card_gothic_3.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Elder Scrolls V: Skyrim",
                        Author = "Bethesda Game Studios",
                        Description = "EPIC FANTASY REBORN The next chapter in the highly anticipated Elder Scrolls saga arrives from the makers of the 2006 and 2008 Games of the Year, Bethesda Game Studios. Skyrim reimagines and revolutionizes the open-world fantasy epic, bringing to life a complete virtual world open for you to explore any way you choose. LIVE ANOTHER LIFE, IN ANOTHER WORLD Play any type of character you can imagine, and do whatever you want; the legendary freedom of choice, storytelling, and adventure of The Elder Scrolls is realized like never before. ALL NEW GRAPHICS AND GAMEPLAY ENGINE Skyrim’s new game engine brings to life a complete virtual world with rolling clouds, rugged mountains, bustling cities, lush fields, and ancient dungeons. " +
                        "YOU ARE WHAT YOU PLAY Choose from hundreds of weapons, spells, and abilities. The new character system allows you to play any way you want and define yourself through your actions. " +
                        "DRAGON RETURN Battle ancient dragons like you’ve never seen. As Dragonborn, learn their secrets and harness their power for yourself.",
                        Price = 10.50m,
                        Features = "RPG, Single Player, VR, Windows",
                        ImgPath = "",
                        CardPath = "card_skyrim.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Homeplanet",
                        Author = "Revolt Games",
                        Description = "In the third century of the space era, humanity has found a way to explore deep space and colonize outer worlds. The game makes you a member of one of the military clans living somewhere far away from the Earth. Your clan, Troydens, is currently under siege from other more powerful and more populated ones. And just as you finish your pilot education, the war breaks out and casts you as a defender of your people." +
                        "This sci-fi game focuses on space combat in deep space and around planets, and it includes more than 60 types of spacecraft.",
                        Price = 13.99m,
                        Features = "Simulation, Single Player, Multiplayer, Controller Support, Windows",
                        ImgPath = "",
                        CardPath = "card_homeplanet.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Total War: MEDIEVAL II",
                        Author = "CREATIVE ASSEMBLY",
                        Description = "Take command of your army and expand your reign in Total War: MEDIEVAL II - the fourth instalment of the award-winning Total War series of strategy games. Direct massive battles featuring up to 10,000 bloodthirsty troops on epic 3D battlefields, while presiding over some of the greatest Medieval nations of the Western and Middle Eastern world.",
                        Price = 15.99m,
                        Features = "Strategy, Single Player, Multiplayer, Windows",
                        ImgPath = "",
                        CardPath = "card_medieval_2.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "A Total War Saga: TROY",
                        Author = "CREATIVE ASSEMBLY",
                        Description = "In this legendary age, heroes walk the earth. In an act that shocks the world, audacious Paris, prince of Troy, elopes with the beautiful queen of Sparta. As they sail away, King Menelaus curses her name. He vows to bring his wife home – whatever the cost!" +
                        "Inspired by The Iliad – Homer’s sweeping tale of romance and bloodshed – A Total War Saga: TROY focuses on the historical flashpoint of the Trojan War, bringing the conflict to life as never before.",
                        Price = 19.99m,
                        Features = "Strategy, Single Player, Multiplayer, Windows, MacOS",
                        ImgPath = "",
                        CardPath = "card_troy.jpg"
                    }
                );
            }
        }
    }
}
