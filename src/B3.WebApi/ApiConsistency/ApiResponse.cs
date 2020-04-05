using System.Runtime.Serialization;

namespace B3.WebApi.ApiConsistency
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = ("version"))]
        public string Version => "1.0";

        [DataMember(Name = "statusCode")]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "errorMessage")]
        public string ErrorMessage { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "result")]
        public object Result { get; set; }

        public ApiResponse(int statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}