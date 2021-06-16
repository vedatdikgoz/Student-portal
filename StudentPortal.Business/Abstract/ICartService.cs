using System;
using System.Collections.Generic;
using System.Text;
using StudentPortal.Entites.Concrete;


namespace StudentPortal.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);

        void AddToCart(string userId, int courseId);
        void DeleteFromCart(string userId, int courseId);
        void ClearCart(int cartId);

        

    }
}
