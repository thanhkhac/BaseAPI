using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Entities.Exceptions;

namespace CompanyEmployees.Extensions
{
    public static class ExceptionMiddleWareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            //Sử dụng middleware để xử lý ngoại lệ
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //Thiết lập phản hồi HTTP
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    
                    //IExceptionHandlerFeature chứa thông tin về lỗi xảy ra
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //Sử dụng switch case để xác định loại lỗi
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            //Nếu là lỗi NotFoundException, Status code sẽ là 404
                            //Nếu không thì trả về lỗi 500
                            NotFoundException => StatusCodes.Status404NotFound, 
                            _ => StatusCodes.Status500InternalServerError
                        };
                    
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}