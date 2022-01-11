using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Models.DcFrame
{
    public class AddDcFrameDto
    {
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public int DcManagerId { get; set; }
        public List<AddDcClassDto> Classes { get; set; }
    }
}
