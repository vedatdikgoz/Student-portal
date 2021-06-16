using System;
using System.Collections.Generic;
using System.Text;
using StudentPortal.Core.DataAccess;
using StudentPortal.Entites.Concrete;


namespace StudentPortal.DataAccess.Abstract
{
    public interface ICartRepository:IEntityRepository<Cart>
    {
        Cart GetCartByUserId(string userId);
        void DeleteFromCart(int cartId, int courseId);
        void ClearCart(int cartId);

        

    }
}
