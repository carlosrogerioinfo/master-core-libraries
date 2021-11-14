using System.Collections.Generic;

namespace Master.Core.WebApi.Response
{
    public class ResponseError
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public ICollection<Error> Errors { get; set; }
    }

    public class Error
    {
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
