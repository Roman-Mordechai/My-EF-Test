using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Entities
{
    public class DcClassEntity
    {
        public int Id { get; set; }
        public DcFrameEntity DcFrame { get; set; }
        public string Name { get; set; }
        public int Occupation { get; set; }
    }
}
