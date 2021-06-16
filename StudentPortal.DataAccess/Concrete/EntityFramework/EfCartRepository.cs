using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Core.DataAccess.EntityFramework;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.Context;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.EntityFramework
{
    public class EfCartRepository :EfEntityRepositoryBase<Cart,DataContext>, ICartRepository
    {
        public Cart GetCartByUserId(string userId)
        {
            using var context = new DataContext();
            return context.Carts.Include(I => I.CartItems)
                .ThenInclude(I => I.Course).FirstOrDefault(I => I.UserId == userId);
        }

        public void DeleteFromCart(int cartId, int courseId)
        {
            using var context = new DataContext();
            var cmd = @"delete from CartItems where CartId=@p0 and CourseId=@p1";
            context.Database.ExecuteSqlRaw(cmd,cartId, courseId);
        }

        public void ClearCart(int cartId)
        {
            using var context = new DataContext();
            var cmd = @"delete from CartItems where CartId=@p0";
            context.Database.ExecuteSqlRaw(cmd, cartId);

        }

       


        public override void Update(Cart entity)
        {
            using var context = new DataContext();
            context.Carts.Update(entity);
            context.SaveChanges();
        }

    }
}
