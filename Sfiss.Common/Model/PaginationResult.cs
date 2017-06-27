using System.Collections.Generic;

namespace Sfiss.Common.Model
{
    public class PaginationResult<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
