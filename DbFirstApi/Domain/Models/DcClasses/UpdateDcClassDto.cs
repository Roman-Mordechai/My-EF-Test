namespace DbFirstApi.Domain.Models.DcClasses
{
    public class UpdateDcClassDto
    {
        public int Id { get; set; }
        public int DcFrameId { get; set; }
        public string Name { get; set; }
        public int Occupation { get; set; }
    }
}
