using System;
using System.Collections.Generic;
using StudentPortal.Business.Abstract;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public void InitializeCart(string userId)
        {
            _cartRepository.Add(new Cart() { UserId = userId });
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }

        public void AddToCart(string userId, int courseId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(I => I.CourseId == courseId);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        CourseId = courseId,
                        CartId = cart.Id,
                        
                    });
                }
                _cartRepository.Update(cart);
            }
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public void ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

        
    }
}
