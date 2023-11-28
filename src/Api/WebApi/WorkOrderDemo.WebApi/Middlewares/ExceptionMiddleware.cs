using System.Net;
using WorkOrderDemo.Api.Domain.Exceptions;

namespace WorkOrderDemo.WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception.GetType() == typeof(WorkOrderException)) return CreateWorkOrderException(context, exception);
        if (exception.GetType() == typeof(VisitException)) return CreateVisitException(context, exception);
        
        return CreateInternalException(context, exception);
    }

    private Task CreateWorkOrderException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        return context.Response.WriteAsync(new WorkOrderProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "workOrder",
            Title = "Work order exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateVisitException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        return context.Response.WriteAsync(new WorkOrderProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "visit",
            Title = "Visit exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(new InternalProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }
}