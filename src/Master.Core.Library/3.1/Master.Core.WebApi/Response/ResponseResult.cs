using System.Collections.Generic;

namespace Master.Core.WebApi.Response
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages ErrorsMessage { get; set; }

        //Used only test return from my own web api, before to analysis from matera's web api
        public ICollection<Error> Errors { get; set; }
    }

    public class Error
    {
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
