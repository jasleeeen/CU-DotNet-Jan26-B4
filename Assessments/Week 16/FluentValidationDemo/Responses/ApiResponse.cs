namespace FluentValidationDemo.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static ApiResponse<T> Ok(T data, string message = "Success") =>
            new ApiResponse<T> { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message, List<string>? errors = null) =>
            new ApiResponse<T> { Success = false, Message = message, Errors = errors ?? new List<string>() };
    }

    public static class ApiResponse
    {
        public static ApiResponse<object> Ok(string message = "Success") =>
            new ApiResponse<object> { Success = true, Message = message };

        public static ApiResponse<object> Fail(string message, List<string>? errors = null) =>
            new ApiResponse<object> { Success = false, Message = message, Errors = errors ?? new List<string>() };
    }
}
