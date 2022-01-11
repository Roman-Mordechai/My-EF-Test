using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Entities
{
    public class DcFrameEntity
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public DcManagerEntity DcManager { get; set; }
        public List<DcClassEntity> Classes { get; set; }
    }
}
