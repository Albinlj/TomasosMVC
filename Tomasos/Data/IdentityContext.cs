using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomasos.Models;

namespace Tomasos.Data
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDish> OrderDishes { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishIngredient> DishIngredients { get; set; }
        public virtual DbSet<DishType> DishTypes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
    }
}
