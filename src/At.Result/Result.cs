using System.Collections.Generic;

namespace At.Result
{
    public class Result
    {
        public string SuccessMessage { get; protected set; }
        public ResultStatus Status { get; }

        public bool IsSuccess => Status == ResultStatus.Ok;
        public IEnumerable<string> Errors { get; protected set; }
        public IEnumerable<ValidationError> ValidationErrors { get; protected set; }

        protected Result(ResultStatus status)
        {
            Status = status;
        }

        public static Result Success(string successMessage = null)
        {
            return new Result(ResultStatus.Ok)
            {
                SuccessMessage = successMessage
            };
        }

        public static Result Error(params string[] errorMessages) => new Result(ResultStatus.Error)
        {
            Errors = errorMessages
        };

        public static Result Invalid(IEnumerable<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }

        public static Result NotFound(IEnumerable<string> errorMessages = null) => new Result(ResultStatus.NotFound)
        {
            Errors = errorMessages
        };
    }
}