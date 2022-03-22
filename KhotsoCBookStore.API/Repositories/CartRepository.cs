using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class CartRepository : ICartService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public CartRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task AddBookToCart(Guid customerId, Guid bookId)
        {
            var cartId = GetCartId(customerId);
            int quantity = 1;

            CartItem existingCartItem = _dbContext.CartItems
            .FirstOrDefault(x => x.ProductId == bookId && x.CartId.ToString() == cartId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                 _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                CartItem cartItems = new CartItem
                {
                    //CartId = cartId,
                    ProductId = bookId,
                    Quantity = quantity
                };
                _dbContext.CartItems.Add(cartItems);
                _dbContext.SaveChanges();
            }
        }

        public string GetCartId(Guid customerId)
        {
            try
            {
                Cart cart = _dbContext.Carts.FirstOrDefault(x => x.UserId == customerId);

                if (cart != null)
                {
                    return cart.CartId.ToString();
                }
                else
                {
                    return CreateCart(customerId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateCart(Guid customerId)
        {
            try
            {
                Cart shoppingCart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    UserId = customerId,
                    CreatedOn = DateTime.Now.Date
                };

                _dbContext.Carts.Add(shoppingCart);
                _dbContext.SaveChanges();

                return shoppingCart.CartId.ToString();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveCartItem(Guid customerId, Guid bookId)
        {
            try
            {
                string cartId = GetCartId(customerId);
                // CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == bookId && x.CartId == cartId);

                // _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneCartItem(Guid customerId, Guid bookId)
        {
            try
            {
                string cartId = GetCartId(customerId);
                CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == bookId 
                && x.CartId.ToString() == cartId);

                cartItem.Quantity -= 1;
                _dbContext.Entry(cartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int GetCartItemCount(Guid customerId)
        {
            string cartId = GetCartId(customerId);

            if (!string.IsNullOrEmpty(cartId))
            {
                int cartItemCount = _dbContext.CartItems.Where(x => x.CartId.ToString() == cartId).Sum(x => x.Quantity);

                return cartItemCount;
            }
            else
            {
                return 0;
            }
        }

        public void MergeCart(Guid tempUserId, Guid permUserId)
        {
            try
            {
                if (tempUserId != permUserId && tempUserId != null && permUserId !=null)
                {
                    string tempCartId = GetCartId(tempUserId);
                    string permCartId = GetCartId(permUserId);

                    List<CartItem> tempCartItem = _dbContext.CartItems
                    .Where(x => x.CartId.ToString() == tempCartId).ToList();

                    foreach (CartItem item in tempCartItem)
                    {
                        CartItem cartItem = _dbContext.CartItems
                        .FirstOrDefault(x => x.ProductId == item.ProductId && x.CartId.ToString() == permCartId);

                        if (cartItem != null)
                        {
                            cartItem.Quantity += item.Quantity;
                            _dbContext.Entry(cartItem).State = EntityState.Modified;
                        }
                        else
                        {
                            CartItem newCartItem = new CartItem
                            {
                                //CartId = permCartId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity
                            };
                            _dbContext.CartItems.Add(newCartItem);
                        }
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                    DeleteCart(tempCartId);
                }
            }
            catch
            {
                throw;
            }
        }

        public int ClearCart(Guid customerId)
        {
            try
            {
                string cartId = GetCartId(customerId);
                List<CartItem> cartItem = _dbContext.CartItems.Where(x => x.CartId.ToString() == cartId).ToList();

                if (!string.IsNullOrEmpty(cartId))
                {
                    foreach (CartItem item in cartItem)
                    {
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        void DeleteCart(string cartId)
        {
            Cart cart = _dbContext.Carts.Find(cartId);
           // _dbContext.CartItems.Remove(CartItem);
            _dbContext.SaveChanges();
        }

        Task ICartService.AddBookToCart(Guid customerId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        Task ICartService.RemoveCartItem(Guid customerId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        Task ICartService.DeleteOneCartItem(Guid customerId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        Task<int> ICartService.GetCartItemCount(Guid customerId)
        {
            throw new NotImplementedException();
        }

        Task ICartService.MergeCart(Guid tempCustomerId, Guid permCustomerId)
        {
            throw new NotImplementedException();
        }

        Task<int> ICartService.ClearCart(Guid customerId)
        {
            throw new NotImplementedException();
        }

        Task<string> ICartService.GetCartId(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
