using Microsoft.AspNetCore.Http;

namespace WebShop.DataAccess.Exceptions;

public class WebShopNotFoundException : WebShopException
{
    public WebShopNotFoundException(string? message = null) : base(message) { }
    
    public override int GetStatusCode()
    {
        return StatusCodes.Status404NotFound;
    }
}