using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChamaUniversity.Util.Exceptions
{
    public class BusinessException 
        : ApplicationException
    {
        public BusinessException()
            : base()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
            this.AddError(message);
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.AddError(message);
        }

        public BusinessException(string code, string message)
            : base(message)
        {
            this.AddError(code, message);
        }

        public BusinessException(string code, string message, Exception innerException)
            : base(message, innerException)
        {
            this.AddError(code, message);
        }

        private List<ErrorDetail> errors = new List<ErrorDetail>();
        public IEnumerable<ErrorDetail> Errors
        {
            get { return errors; }
        }

        public BusinessException AddError(string message)
        {
            return this.AddError(null, message);
        }

        public BusinessException AddError(string code, string message)
        {
            errors.Add(new ErrorDetail()
            {
                Type = ErrorType.Business,
                Code = code,
                Message = message,
            });

            return this;
        }

        public void ThrowIfHasErrors()
        {
            if (this.Errors.Any())
                throw this;
        }
    }
}
