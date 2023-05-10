namespace Minimal_API;

public  class  CustomEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        //before logic here
        var result = await next(context);
        //after logic here
        
        return result;
    }
}