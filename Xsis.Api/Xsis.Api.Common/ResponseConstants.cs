using Xsis.Api.Model;

namespace Xsis.Api.Common
{
    public static class ResponseConstants
    {
        public static BaseResponse OK => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "success",
            code = 200,
            message = "OK",
            data = null,
            errors = null
        };

        public static BaseResponse NO_RESULT => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "success",
            code = 200,
            message = "No result",
            data = null,
            errors = null
        };

        public static BaseResponse ERROR => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 400,
            message = "Error",
            data = null,
            errors = null
        };

        public static BaseResponse DUPLICATE_ENTRY => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 400,
            message = "DUPLICATE ENTRY",
            data = null,
            errors = null
        };

        public static BaseResponse NOT_FOUND => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 404,
            message = "Not found",
            data = null,
            errors = null
        };

    }
}