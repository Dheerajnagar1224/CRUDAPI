using kycapi.Model;

namespace kycapi.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.code = "1";
            response.ResponseData = ex.Message;
            return response;
        }

        public static ApiResponse GetAppResponse(ResponseType type, Object? Contract)
        {

            ApiResponse response;
            response = new ApiResponse { ResponseData = Contract };
            switch (type)
            {
                case ResponseType.Success:
                    response.code = "0";
                    response.message = "Success";

                    break;
                case ResponseType.Notfound:
                    response.code = "2";
                    response.message = "No  record Available";
                    break;

                case ResponseType.Failure:
                    response.code = "3";
                    response.message = "Some Error Occured";
                    break;

            }
            return response;

        }

    }
}

