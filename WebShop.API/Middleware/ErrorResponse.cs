using Newtonsoft.Json;

namespace WebShopAPI_MediatrTraining.Middleware;

public class ErrorResponse
{
    public int StatusCode { get; init; }
    public string? ErrorMessage { get; init; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}