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
            try
            {
                await CreateCartAsync(customerId);
                var cartId = await GetCartId(customerId);
                var newCartId = new Guid(cartId);
                int quantity = 1;
    
                CartItem existingCartItem = await _dbContext.CartItems
                .FirstOrDefaultAsync(x => x.ProductId == bookId && x.CartId.ToString() == cartId);
    
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                     _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                }
                else
                {
                    CartItem cartItems = new CartItem
                    {
                        CartId = newCartId,
                        ProductId = bookId,
                        Quantity = quantity
                    };
                    await _dbContext.CartItems.AddAsync(cartItems); 
                    await _dbContext.SaveChangesAsync();              
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task CreateCartAsync(Guid customerId)
        {
            try
            {
                Cart shoppingCart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = customerId,
                    CartTotal = 00.00M
                };

                await _dbContext.Carts.AddAsync(shoppingCart);
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<string> GetCartId(Guid customerId)
        {
            try
            {
                Cart cart = await _dbContext.Carts.FirstOrDefaultAsync(x => x.CustomerId == customerId);

                if (cart != null)
                {
                    return cart.CartId.ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task RemoveCartItem(Guid customerId, Guid bookId)
        {
            try
            {
                string cartId = await GetCartId(customerId);
                CartItem cartItem = _dbContext.CartItems
                .FirstOrDefault(x => x.ProductId == bookId && x.CartId.ToString() == cartId);

                _dbContext.CartItems.Remove(cartItem);                
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task DeleteOneCartItem(Guid customerId, Guid bookId)
        {
            try
            {
                string cartId = await GetCartId(customerId);
                CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == bookId 
                && x.CartId.ToString() == cartId);

                cartItem.Quantity -= 1;
                _dbContext.Entry(cartItem).State = EntityState.Modified;
                
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<int> GetCartItemCount(Guid customerId)
        {
            try
            {
                string cartId = await  GetCartId(customerId);
    
                if (!string.IsNullOrEmpty(cartId))
                {
                    int cartItemCount = _dbContext.CartItems.Where(x => x.CartId.ToString() == cartId)
                    .Sum(x => x.Quantity);
                    return cartItemCount;
                }
                else
                {
                    return 0;
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task MergeCart(Guid tempUserId, Guid permUserId)
        {
            try
            {
                if (tempUserId != permUserId && tempUserId != null && permUserId !=null)
                {
                    string tempCartId = await GetCartId(tempUserId);
                    string permCartId = await GetCartId(permUserId);

                    var newPermCartId = new Guid(permCartId);

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
                                CartId = newPermCartId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity
                            };
                            _dbContext.CartItems.Add(newCartItem);
                        }
                        _dbContext.CartItems.Remove(item);
                       
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<int> ClearCart(Guid customerId)
        {
            try
            {
                string cartId = await GetCartId(customerId);
                List<CartItem> cartItem = _dbContext.CartItems.Where(x => x.CartId.ToString() == cartId).ToList();

                if (!string.IsNullOrEmpty(cartId))
                {
                    foreach (CartItem item in cartItem)
                    {
                        _dbContext.CartItems.Remove(item);
                        
                    }
                }
                return 0;
            }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }            
        }    

        void DeleteCart(string cartId)
        {
            try
            {
                Cart cart = _dbContext.Carts.Find(cartId);
                _dbContext.Carts.Remove(cart);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }          
        }   
    }
}
