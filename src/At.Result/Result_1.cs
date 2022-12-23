using System.Collections.Generic;

namespace At.Result
{
    public class Result<T> : Result
    {
        public T Value { get; }

        protected Result(ResultStatus status) : base(status)
        {
        }

        protected Result(T value, string? successMessage = null) : base(ResultStatus.Ok)
        {
            Value = value;
            SuccessMessage = successMessage;
        }

        public static implicit operator T(Result<T> result) => result.Value;


        public static Result<T> Success(T value, string? successMessage = null)
        {
            return new Result<T>(value, successMessage);
        }

        public static Result<T> Error(params string[] errorMessages) => new Result<T>(ResultStatus.Error)
        {
            Errors = errorMessages
        };

        public static Result<T> Invalid(IEnumerable<ValidationError> validationErrors)
        {
            return new Result<T>(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }

        public static Result<T> NotFound(IEnumerable<string> errorMessages = null) =>
            new Result<T>(ResultStatus.NotFound)
            {
                Errors = errorMessages
            };
    }
}