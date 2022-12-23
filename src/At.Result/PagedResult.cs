namespace At.Result
{
    public class PagedResult<T> : Result<T>
    {
        public int TotalCount { get; set; }
        
        protected PagedResult(ResultStatus status) : base(status)
        {
        }
    }
}