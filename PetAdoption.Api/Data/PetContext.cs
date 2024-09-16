using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data.Entities;

namespace PetAdoption.Api.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }
        public DbSet<UserAdoption> UserAdoptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                        .HasKey(uf => new { uf.UserId, uf.PetId });

            modelBuilder.Entity<Pet>()
                        .HasData(InitialPetsData());
        }
        private static List<Pet> InitialPetsData()
        {
            var pets = new List<Pet>
            {
               new Pet
                {
                    Id = 1,
                    Name = "Buddy",
                    Breed = "Dog - Golden Retriever",
                    Price = 300,
                    Description = "Buddy is a friendly and playful Golden Retriever, known for being great with kids.",
                    Image = "wwwroot/images/pets/img_1.jpg"
                },
                new Pet
                {
                    Id = 2,
                    Name = "Mittens",
                    Breed = "Cat - Persian",
                    Price = 200,
                    Description = "Mittens is a calm and affectionate Persian cat.",
                    Image = "wwwroot/images/pets/img_2.jpg"
                },
                new Pet
                {
                    Id = 3,
                    Name = "Charlie",
                    Breed = "Dog - Beagle",
                    Price = 250,
                    Description = "Charlie is an energetic Beagle who loves to explore.",
                    Image = "wwwroot/images/pets/img_3.jpg"
                },
                new Pet
                {
                    Id = 4,
                    Name = "Whiskers",
                    Breed = "Cat - Siamese",
                    Price = 180,
                    Description = "Whiskers is a vocal and curious Siamese cat.",
                    Image = "wwwroot/images/pets/img_4.jpg"
                },
                new Pet
                {
                    Id = 5,
                    Name = "Max",
                    Breed = "Dog - Labrador Retriever",
                    Price = 350,
                    Description = "Max is a loyal Labrador Retriever who loves to fetch.",
                    Image = "wwwroot/images/pets/img_5.jpg"
                },
                new Pet
                {
                    Id = 6,
                    Name = "Bella",
                    Breed = "Dog - Poodle",
                    Price = 300,
                    Description = "Bella is an elegant Poodle who enjoys attention.",
                    Image = "wwwroot/images/pets/img_6.jpg"
                },
                new Pet
                {
                    Id = 7,
                    Name = "Luna",
                    Breed = "Cat - Ragdoll",
                    Price = 250,
                    Description = "Luna is a gentle Ragdoll cat who loves to cuddle.",
                    Image = "wwwroot/images/pets/img_7.jpg"
                },
                new Pet
                {
                    Id = 8,
                    Name = "Rocky",
                    Breed = "Dog - Boxer",
                    Price = 320,
                    Description = "Rocky is a strong Boxer who loves to play.",
                    Image = "wwwroot/images/pets/img_8.jpg"
                },
                new Pet
                {
                    Id = 9,
                    Name = "Shadow",
                    Breed = "Cat - British Shorthair",
                    Price = 220,
                    Description = "Shadow is a quiet British Shorthair who enjoys solitude.",
                    Image = "wwwroot/images/pets/img_9.jpg"
                },
                new Pet
                {
                    Id = 10,
                    Name = "Oscar",
                    Breed = "Dog - Dachshund",
                    Price = 200,
                    Description = "Oscar is a curious Dachshund who loves to dig.",
                    Image = "wwwroot/images/pets/img_10.jpg"
                },
                new Pet
                {
                    Id = 11,
                    Name = "Cleo",
                    Breed = "Cat - Bengal",
                    Price = 300,
                    Description = "Cleo is an active Bengal cat who loves to climb.",
                    Image = "wwwroot/images/pets/img_11.jpg"
                },
                new Pet
                {
                    Id = 12,
                    Name = "Daisy",
                    Breed = "Dog - Shih Tzu",
                    Price = 220,
                    Description = "Daisy is a sweet Shih Tzu who enjoys being pampered.",
                    Image = "wwwroot/images/pets/img_12.jpg"
                },
                new Pet
                {
                    Id = 13,
                    Name = "Simba",
                    Breed = "Cat - Maine Coon",
                    Price = 350,
                    Description = "Simba is a large Maine Coon with a gentle disposition.",
                    Image = "wwwroot/images/pets/img_13.jpg"
                },
                new Pet
                {
                    Id = 14,
                    Name = "Jack",
                    Breed = "Dog - Border Collie",
                    Price = 320,
                    Description = "Jack is an intelligent Border Collie who loves to work.",
                    Image = "wwwroot/images/pets/img_14.jpg"
                },
                new Pet
                {
                    Id = 15,
                    Name = "Nala",
                    Breed = "Cat - Scottish Fold",
                    Price = 280,
                    Description = "Nala is a playful Scottish Fold with a unique look.",
                    Image = "wwwroot/images/pets/img_15.jpg"
                },
                new Pet
                {
                    Id = 16,
                    Name = "Zeus",
                    Breed = "Dog - German Shepherd",
                    Price = 400,
                    Description = "Zeus is a protective German Shepherd who is very loyal.",
                    Image = "wwwroot/images/pets/img_16.jpg"
                },
                new Pet
                {
                    Id = 17,
                    Name = "Milo",
                    Breed = "Dog - Cocker Spaniel",
                    Price = 280,
                    Description = "Milo is a friendly Cocker Spaniel with a lot of energy.",
                    Image = "wwwroot/images/pets/img_17.jpg"
                },
                new Pet
                {
                    Id = 18,
                    Name = "Mochi",
                    Breed = "Cat - Exotic Shorthair",
                    Price = 250,
                    Description = "Mochi is a calm Exotic Shorthair who enjoys lounging.",
                    Image = "wwwroot/images/pets/img_18.jpg"
                },
                new Pet
                {
                    Id = 19,
                    Name = "Bailey",
                    Breed = "Dog - Pomeranian",
                    Price = 300,
                    Description = "Bailey is a lively Pomeranian who loves to be the center of attention.",
                    Image = "wwwroot/images/pets/img_19.jpg"
                },
                new Pet
                {
                    Id = 20,
                    Name = "Oliver",
                    Breed = "Cat - Abyssinian",
                    Price = 240,
                    Description = "Oliver is a curious Abyssinian who loves to explore.",
                    Image = "wwwroot/images/pets/img_20.jpg"
                },
                new Pet
                {
                    Id = 21,
                    Name = "Rusty",
                    Breed = "Dog - Redbone Coonhound",
                    Price = 270,
                    Description = "Rusty is an active Redbone Coonhound who loves to run.",
                    Image = "wwwroot/images/pets/img_21.jpg"
                },
                new Pet
                {
                    Id = 22,
                    Name = "Zoe",
                    Breed = "Cat - Sphynx",
                    Price = 320,
                    Description = "Zoe is a hairless Sphynx with a very affectionate personality.",
                    Image = "wwwroot/images/pets/img_22.jpg"
                },
                new Pet
                {
                    Id = 23,
                    Name = "Finn",
                    Breed = "Dog - Australian Shepherd",
                    Price = 350,
                    Description = "Finn is an energetic Australian Shepherd who loves to herd.",
                    Image = "wwwroot/images/pets/img_23.jpg"
                },
                new Pet
                {
                    Id = 24,
                    Name = "Lily",
                    Breed = "Cat - Burmese",
                    Price = 280,
                    Description = "Lily is a vocal Burmese cat who enjoys human company.",
                    Image = "wwwroot/images/pets/img_24.jpg"
                },
                new Pet
                {
                    Id = 25,
                    Name = "Rex",
                    Breed = "Dog - Rottweiler",
                    Price = 380,
                    Description = "Rex is a strong Rottweiler who is very protective.",
                    Image = "wwwroot/images/pets/img_25.jpg"
                },
                new Pet
                {
                    Id = 26,
                    Name = "Chloe",
                    Breed = "Cat - Norwegian Forest",
                    Price = 320,
                    Description = "Chloe is a fluffy Norwegian Forest cat who loves the outdoors.",
                    Image = "wwwroot/images/pets/img_26.jpg"
                },
                new Pet
                {
                    Id = 27,
                    Name = "Ginger",
                    Breed = "Dog - Cavalier King Charles Spaniel",
                    Price = 330,
                    Description = "Ginger is a gentle Cavalier King Charles Spaniel who loves to cuddle.",
                    Image = "wwwroot/images/pets/img_27.jpg"
                },
                new Pet
                {
                    Id = 28,
                    Name = "Toby",
                    Breed = "Dog - Shiba Inu",
                    Price = 340,
                    Description = "Toby is an independent Shiba Inu with a lot of personality.",
                    Image = "wwwroot/images/pets/img_28.jpg"
                },
                new Pet
                {
                    Id = 29,
                    Name = "Sasha",
                    Breed = "Cat - Russian Blue",
                    Price = 300,
                    Description = "Sasha is a reserved Russian Blue who enjoys quiet environments.",
                    Image = "wwwroot/images/pets/img_29.jpg"
                },
                new Pet
                {
                    Id = 30,
                    Name = "Bruno",
                    Breed = "Dog - Bulldog",
                    Price = 350,
                    Description = "Bruno is a strong Bulldog with a gentle heart",
                    Image = "wwwroot/images/pets/img_30.jpg"

                }
            };

            return pets;
        }
    }
}
