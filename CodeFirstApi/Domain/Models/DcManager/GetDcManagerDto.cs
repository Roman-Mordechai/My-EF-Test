using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Models.DcManager
{
    public class GetDcManagerDto
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
