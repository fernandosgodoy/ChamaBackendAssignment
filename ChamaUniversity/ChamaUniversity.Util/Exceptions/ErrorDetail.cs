using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Util.Exceptions
{
    public class ErrorDetail
    {
        public ErrorDetail()
        {
            this.Type = ErrorType.Unhandled;
            this.Code = null;
            this.Message = null;
        }

        public ErrorType Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public static IEnumerable<ErrorDetail> FromException(Exception exception)
        {
            if (exception is BusinessException businessException)
            {
                return businessException.Errors;
            }
            else
            {
                return new List<ErrorDetail>()
                {
                    new ErrorDetail()
                    {
                        Type = ErrorType.Unhandled,
                        Code = null,
                        Message = exception.Message,
                        Description = exception.ToString()
                    }
                };
            }
        }
    }
}
