using System;

namespace web.api.App.Common
{
    public class EntityCreatedResult
    {
        public int Id { get; set; }
        public Exception Error { get; set; }
    }
}