using System.Collections.Generic;

namespace CodeFirstApi.Domain.Entities
{
    public class DcFrameEntity
    {
        public int Id { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public DcManagerEntity DcManager { get; set; }
        public List<DcClassEntity> DcClasses { get; set; }
    }
}
