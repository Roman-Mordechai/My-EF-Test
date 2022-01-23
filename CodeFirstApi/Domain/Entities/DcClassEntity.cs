namespace CodeFirstApi.Domain.Entities
{
    public class DcClassEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupation { get; set; }
        public DcFrameEntity DcFrame { get; set; }
    }
}
