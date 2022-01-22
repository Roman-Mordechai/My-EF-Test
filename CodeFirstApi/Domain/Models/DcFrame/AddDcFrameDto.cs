using CodeFirstApi.Domain.Models.DcClasses;
using System.Collections.Generic;

namespace CodeFirstApi.Domain.Models.DcFrame
{
    public class AddDcFrameDto
    {
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public int DcManagerId { get; set; }
        public List<AddDcClassDto> DcClasses { get; set; }

    }
}
