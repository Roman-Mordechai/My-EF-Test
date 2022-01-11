using CodeFirstApi.Entities;
using CodeFirstApi.Models.DcClasses;
using CodeFirstApi.Models.DcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Models.DcFrame
{
    public class GetDcFrameDto
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public GetDcManagerDto DcManager { get; set; }
        public List<GetDcClassDto> Classes { get; set; }
    }
}
