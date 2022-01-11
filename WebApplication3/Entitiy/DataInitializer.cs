using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Entitiy
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera", Description="Kamere Ürünleri"},
                new Category(){Name="Bilgisayar", Description="Bilgisayar Ürünleri"},
                new Category(){Name="Elektronik", Description="Elektronik Ürünleri"},
                new Category(){Name="Telefon", Description="Telefon Ürünleri"},
                new Category(){Name="Beyaz Eşya", Description="Beyaz Eşya Ürünleri"},
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name = "1050TI bilgisayar çok kullanışlı 8 gb ram", Description="csgo açarsın",Price=5600, Stock=1200,IsApproved=true,CategoryId=1,IsHome=true},
                new Product(){Name = "2050TI bilgisayar çok kullanışlı 8 gb ram i5 işlemci", Description="csgo açarsın",Price=5600, Stock=1200,IsApproved=true,CategoryId=1,IsHome=true},

                new Product(){Name = "oppo", Description="csgo açamazsın",Price=5600, Stock=1200,IsApproved=true,CategoryId=3,IsHome=true},
                new Product(){Name = "vestel", Description="csgo açaman",Price=5600, Stock=1200,IsApproved=true,CategoryId=3,IsHome=true},

                new Product(){Name = "dolap", Description="herkesin var",Price=5600, Stock=1200,IsApproved=true,CategoryId=3,IsHome=true},
                new Product(){Name = "fırın", Description="yeemk pişir",Price=5600, Stock=1200,IsApproved=true,CategoryId=3,IsHome=true},
            };

            base.Seed(context);
        }

    }
}