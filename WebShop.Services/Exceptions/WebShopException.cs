using Microsoft.AspNetCore.Http;

namespace WebShop.DataAccess.Exceptions;

public class WebShopException : Exception
{
    public WebShopException(string? message = null) : base(message) { }
    
    public virtual int GetStatusCode()
    {
        return StatusCodes.Status500InternalServerError;
    }
}