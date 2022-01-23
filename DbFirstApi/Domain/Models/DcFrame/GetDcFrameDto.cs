using DbFirstApi.Domain.Models.DcManager;

namespace DbFirstApi.Domain.Models.DcFrame
{
    public class GetDcFrameDto
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public GetDcManagerDto DcManager { get; set; }
    }
}
