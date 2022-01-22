using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Domain.Models.DcManager;
using System.Collections.Generic;

namespace CodeFirstApi.Domain.Models.DcFrame
{
    public class GetDcFrameDto
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public GetDcManagerDto DcManager { get; set; }
        public List<GetDcClassDto> DcClasses { get; set; }
    }
}
