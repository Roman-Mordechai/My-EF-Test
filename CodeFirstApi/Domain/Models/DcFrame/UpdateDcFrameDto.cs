﻿using CodeFirstApi.Models.DcFrame;
using System.Collections.Generic;

namespace CodeFirstApi.Domain.Models.DcFrame
{
    public class UpdateDcFrameDto
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public int DcManagerId { get; set; }
        public List<AddDcClassDto> Classes { get; set; }
    }
}
