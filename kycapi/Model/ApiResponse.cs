namespace kycapi.Model
{
    public class ApiResponse
    {
        
            public string code { get; set; }
            public string message { get; set; }
            public Object? ResponseData { get; set; }
        

      
    }
    public enum ResponseType
    {
        Success,
        Notfound,
        Failure
    }
}
