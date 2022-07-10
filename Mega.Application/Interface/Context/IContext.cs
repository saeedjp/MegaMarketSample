using Mega.Domain.Entities.Finances;
using Mega.Domain.Entities.Orders;
using Mega.Domain.Entity.Carts;
using Mega.Domain.Entity.HomePage;
using Mega.Domain.Entity.Products;
using Mega.Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mega.Application.Interface.Context
{
    public interface IContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Category> categories { get; set; }
         DbSet<Pproduct> pproducts { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductFeature> ProductFeatures { get; set; }
        DbSet<Slider> sliders { get; set; }
        DbSet<HomePageImsges> homePageImsges { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<RequestPay> requestPays { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()); 
    }
}
