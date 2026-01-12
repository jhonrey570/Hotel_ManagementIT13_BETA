namespace Hotel_ManagementIT13.Services
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ServiceResult()
        {
            Success = false;
            Message = string.Empty;
            Data = default(T);
        }

        public ServiceResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}