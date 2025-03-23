using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
    private readonly ILogger<ApiExceptionFilterAttribute> _logger;

    public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(
            string.Format(
                "TimeTracking Request: Unhandled Exception for Request {0} with Exception {1} and Message {2} and StackTrace {3}",
                context.ActionDescriptor.DisplayName,
                context.Exception.ToString(),
                context.Exception.Message,
                context.Exception.StackTrace
            )
        );

        base.OnException(context);
    }

}
