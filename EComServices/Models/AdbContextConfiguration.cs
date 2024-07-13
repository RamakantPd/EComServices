using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class AdbContextConfiguration:DbContext
    {
        public AdbContextConfiguration(DbContextOptions<AdbContextConfiguration> options) : base(options)
        {

        }
        public DbSet<UserRegistrationModel> UserRegistration { get; set; }
        public DbSet<CountryListModel> CountryList { get; set; }
        public DbSet<StateListModel> StateList { get; set; }
        public DbSet<UserLogin> LoginUser { get; }
        public DbSet<UploadFilesAndImagesModel> Documents { get; set; }
        public DbSet<FileCompressionModel> FileCompressInfo { get; set; }
        public DbSet<EComServices.Models.LoginSuccessModel> LoginSuccessModel { get; set; }
        public DbSet<ProductCategoryModel> M_ProductCategory { get; set; }
        public DbSet<ProductModel> M_ProductType { get; set; }
        public DbSet<ProductSubCategoryWiseListModel> D_CategoryWiseProductDetail { get; set; }
        public DbSet<AddedItemsIntoCartForLoggedUser> D_CartItems { get; set; }
        public DbSet<MailRequest> MailRequest { get; set; }
    }
}
