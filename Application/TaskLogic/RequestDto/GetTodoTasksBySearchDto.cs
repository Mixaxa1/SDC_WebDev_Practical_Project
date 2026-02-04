using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLogic.RequestDto
{
    public class GetTodoTasksBySearchDto
    {
        public string? Title { get; set; }
        public Guid? TagId { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? DueAfter { get; set; }
        public DateTime? DueBefore { get; set; }
    }
}
