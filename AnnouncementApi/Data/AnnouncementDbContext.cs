using AnnouncementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AnnouncementApi.Data
{
    public class AnnouncementDbContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        public AnnouncementDbContext(DbContextOptions<AnnouncementDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = 1,
                    Title = "Продам холодильник Samsung",
                    Description = "Холодильник в хорошому стані, 3 роки експлуатації, модель RSH7UNBP.",
                    CreatedDate = DateTime.Now.AddDays(-10),  
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Холодильники"
                },
                new Announcement
                {
                    Id = 2,
                    Title = "Продаю пральну машину LG",
                    Description = "Пральна машина з вертикальним завантаженням, модель LG F14A8RDS7.",
                    CreatedDate = DateTime.Now.AddDays(-5), 
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Пральні машини"
                },
                new Announcement
                {
                    Id = 3,
                    Title = "Бойлер Atlantic Opro Plus 80L",
                    Description = "Нова модель бойлера, обсяг 80 літрів, електричний обігрівач.",
                    CreatedDate = DateTime.Now.AddDays(-20),  
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Бойлери"
                },
                new Announcement
                {
                    Id = 4,
                    Title = "Газова піч Zelmer",
                    Description = "Піч з чавунними конфорками, компактна, швидка.",
                    CreatedDate = DateTime.Now.AddDays(-15),  
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Печі"
                },
                new Announcement
                {
                    Id = 5,
                    Title = "Витяжка Kaiser EKS 60",
                    Description = "Витяжка кухонна, нова, нержавіюча сталь.",
                    CreatedDate = DateTime.Now.AddDays(-30),  
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Витяжки"
                },
                new Announcement
                {
                    Id = 6,
                    Title = "Мікрохвильова піч Panasonic NN-SD27HS",
                    Description = "Мікрохвильова піч з грилем, потужність 800 Вт.",
                    CreatedDate = DateTime.Now.AddDays(-12),  
                    Status = true,
                    Category = "Побутова техніка",
                    SubCategory = "Мікрохвильові печі"
                },

                new Announcement
                {
                    Id = 7,
                    Title = "Продам ігровий ПК",
                    Description = "ПК з процесором i7, відеокартою GTX 1080, 16 ГБ RAM.",
                    CreatedDate = DateTime.Now.AddDays(-3),  
                    Status = true,
                    Category = "Комп'ютерна техніка",
                    SubCategory = "ПК"
                },
                new Announcement
                {
                    Id = 8,
                    Title = "Ноутбук ASUS VivoBook",
                    Description = "Ноутбук з процесором i5, 8 ГБ RAM, SSD 512 ГБ.",
                    CreatedDate = DateTime.Now.AddDays(-7),  
                    Status = true,
                    Category = "Комп'ютерна техніка",
                    SubCategory = "Ноутбуки"
                },
                new Announcement
                {
                    Id = 9,
                    Title = "Монітор LG 27MP59G",
                    Description = "Монітор 27 дюймів, роздільна здатність 1920x1080.",
                    CreatedDate = DateTime.Now.AddDays(-25), 
                    Status = true,
                    Category = "Комп'ютерна техніка",
                    SubCategory = "Монітори"
                },
                new Announcement
                {
                    Id = 10,
                    Title = "Принтер HP LaserJet Pro",
                    Description = "Чорно-білий лазерний принтер, новий, ще в упаковці.",
                    CreatedDate = DateTime.Now.AddDays(-18),  
                    Status = true,
                    Category = "Комп'ютерна техніка",
                    SubCategory = "Принтери"
                },
                new Announcement
                {
                    Id = 11,
                    Title = "Сканер Epson Perfection",
                    Description = "Плоский сканер A4, роздільна здатність 1200 x 2400 dpi.",
                    CreatedDate = DateTime.Now.AddDays(-13),  
                    Status = true,
                    Category = "Комп'ютерна техніка",
                    SubCategory = "Сканери"
                },

                new Announcement
                {
                    Id = 12,
                    Title = "Samsung Galaxy S21",
                    Description = "Смартфон з AMOLED екраном, процесор Exynos 2100, 8 ГБ RAM.",
                    CreatedDate = DateTime.Now.AddDays(-8),  
                    Status = true,
                    Category = "Смартфони",
                    SubCategory = "Android смартфони"
                },
                new Announcement
                {
                    Id = 13,
                    Title = "iPhone 13 Pro",
                    Description = "Apple iPhone 13 Pro, 128 ГБ, графітовий колір.",
                    CreatedDate = DateTime.Now.AddDays(-22),  
                    Status = true,
                    Category = "Смартфони",
                    SubCategory = "iOS/Apple смартфони"
                },

                new Announcement
                {
                    Id = 14,
                    Title = "Продам стильний жіночий костюм",
                    Description = "Новий костюм, розмір M, чорного кольору.",
                    CreatedDate = DateTime.Now.AddDays(-11),  
                    Status = true,
                    Category = "Інше",
                    SubCategory = "Одяг"
                },
                new Announcement
                {
                    Id = 15,
                    Title = "Чоловічі черевики Timberland",
                    Description = "Взуття 43 розміру, у відмінному стані, зручні та стильні.",
                    CreatedDate = DateTime.Now.AddDays(-17), 
                    Status = true,
                    Category = "Інше",
                    SubCategory = "Взуття"
                },
                new Announcement
                {
                    Id = 16,
                    Title = "Годинник Casio",
                    Description = "Чоловічий годинник, водостійкий, із нержавіючої сталі.",
                    CreatedDate = DateTime.Now.AddDays(-14),  
                    Status = true,
                    Category = "Інше",
                    SubCategory = "Аксесуари"
                },
                new Announcement
                {
                    Id = 17,
                    Title = "Гантелі 2x5 кг",
                    Description = "Комплект гантелей для домашнього тренування, нові.",
                    CreatedDate = DateTime.Now.AddDays(-2), 
                    Status = true,
                    Category = "Інше",
                    SubCategory = "Спортивне обладнання"
                },
                new Announcement
                {
                    Id = 18,
                    Title = "Конструктор LEGO Technic",
                    Description = "Іграшковий набір LEGO, для дітей від 12 років.",
                    CreatedDate = DateTime.Now.AddDays(-19),  
                    Status = true,
                    Category = "Інше",
                    SubCategory = "Іграшки"
                }
            );
        }

    }



}
