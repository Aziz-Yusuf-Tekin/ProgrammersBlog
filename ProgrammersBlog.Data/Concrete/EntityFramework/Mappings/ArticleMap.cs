using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(c => c.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");

            //builder.HasData(
            //    new Article
            //    {
            //        Id = 1,
            //        CategoryId = 1,
            //        UserId = 1,
            //        Title = "C# 9.0 ve .NET 5 Yenilikleri",
            //        Content = "Lorem Ipsum, basım ve dizgi endüstrisinin basit bir şekilde sahte metnidir. Lorem Ipsum, bilinmeyen bir yazıcının bir yazı tipi kadırgasını alıp onu bir tip numune kitabı yapmak için karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüz yıl hayatta kalmakla kalmadı, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset yapraklarının yayınlanmasıyla ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımlarıyla popüler oldu.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
            //        SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
            //        SeoAuthor = "Aziz Yusuf Tekin",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C# 9.0 ve .NET 5 Yenilikleri",
            //        ViewsCount = 100,
            //        CommentCount = 1
            //    },
            //    new Article
            //    {
            //        Id = 2,
            //        CategoryId = 2,
            //        UserId = 1,
            //        Title = "C++ 11 ve 19 Yenilikleri",
            //        Content = "Bir sayfanın düzenine bakıldığında okunabilir içeriğin okuyucunun dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum'u kullanmanın amacı, 'İçerik burada, içerik burada' seçeneğinin aksine, aşağı yukarı normal bir harf dağılımına sahip olması ve okunabilir bir İngilizce gibi görünmesidir. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' için yapılan bir arama, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen kazara, bazen kasıtlı olarak (mizah zerresi vb.) çeşitli versiyonlar geliştirilmiştir.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "C++ 11 ve 19 Yenilikleri",
            //        SeoTags = "C++ 11 ve 19 Yenilikleri",
            //        SeoAuthor = "Aziz Yusuf Tekin",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C++ 11 ve 19 Yenilikleri",
            //        ViewsCount = 295,
            //        CommentCount = 1
            //    },
            //    new Article
            //    {
            //        Id = 3,
            //        CategoryId = 3,
            //        UserId = 1,
            //        Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        Content = "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. Kökleri MÖ 45 yılına ait bir klasik Latin edebiyatına dayanmaktadır ve bu da onu 2000 yıldan daha eski yapmaktadır. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajında ​​geçen ve anlaşılması en güç Latince sözcüklerden biri olan consectetur'a baktı ve kelimenin klasik edebiyattaki örneklerini incelerken kesin kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45'te yazdığı \"de Finibus Bonorum et Malorum\" (İyinin ve Kötünün Aşırılıkları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı, \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelir.\r\n\r\n1500'lerden beri kullanılan standart Lorem Ipsum yığını, ilgilenenler için aşağıda yeniden üretilmiştir. Cicero'nun \"de Finibus Bonorum et Malorum\" adlı eserinin 1.10.32 ve 1.10.33 bölümleri de, H. Rackham'ın 1914 çevirisinden İngilizce sürümleriyle birlikte, tam orijinal halleriyle yeniden üretilmiştir.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        SeoAuthor = "Aziz Yusuf Tekin",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        ViewsCount = 12,
            //        CommentCount = 1
            //    }
            //    );
        }
    }
}
