using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        public RequestDelegate Next { get; }
        private readonly ILogger<ExceptionMiddleware> Logger;
        public IHostEnvironment Env { get; }
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.Env = env;
            this.Logger = logger;
            this.Next = next;
        }
        public async Task InvokeAsync(HttpContext context){
            try
            {
                await this.Next(context);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = this.Env.IsDevelopment()
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message,ex.StackTrace.ToString()) : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions{
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}