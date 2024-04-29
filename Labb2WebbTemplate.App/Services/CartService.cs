using Labb2WebbTemplate.App.Models;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Labb2WebbTemplate.App.Services;

public class CartService(ProtectedLocalStorage localStorage)
{
    private const string CartKey = "cart";
    
    public async Task AddToCart(ProductResponse product)
    {

        var cart = await GetCartAsync();

        var prod = cart.SingleOrDefault(p => p.Id == product.Id);
        if (prod is null)
        {
            cart?.Add(new CartProductModel()
            {
                Amount = 1, 
                Name = product.Name, 
                Price = product.Price, 
                Id = product.Id
            });
        }
        else
        {
            prod.Amount++;
        }
        

        await localStorage.SetAsync(CartKey, cart);
    }
    
    public async Task RemoveFromCart(int obj, List<CartProductModel> cart)
    {
        var prod =  cart.SingleOrDefault(p => p.Id == obj);

        if (prod != null) cart.Remove(prod);

        await localStorage.SetAsync(CartKey, cart);
    }

    public async Task ChangeAmountInProduct(int id, int amount)
    {

        var cart = await GetCartAsync();
        
        var prod = cart.SingleOrDefault(p => p.Id == id);

        if (prod is null)
        {
            throw new NullReferenceException();
        }

        prod.Amount = amount;
        await localStorage.SetAsync(CartKey, cart);
    }

    public async Task<List<CartProductModel>> GetCartAsync()
    {
        var list = 
            await localStorage.GetAsync<List<CartProductModel>>(CartKey);

        var cart = list.Success 
            ? list.Value!
            : [];

        return cart;
    }

    public async Task ClearCart()
    {
        await localStorage.DeleteAsync(CartKey);
    }
}