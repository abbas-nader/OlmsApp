namespace OlmsApp.Shared;

public  class OperationResult(bool isSuccess,  string message)
{
    public bool IsSuccess { get; } = isSuccess;
    public string Message { get; } = message;

    public static OperationResult Success()
    {
        return new OperationResult(true, "Success");
    }

    public static OperationResult Failed(string message)
    {
        return new OperationResult(false, message);
    }
}
public class OperationResult<T>(bool isSuccess, string message, T data) : OperationResult(isSuccess, message)
{
        public   T? Data { get;} = data;

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>(true,"Success",data);
        }

        public new static OperationResult<T?> Failed(string message)
        {
            return new OperationResult<T?>(false,message,default!);
        }
        
}