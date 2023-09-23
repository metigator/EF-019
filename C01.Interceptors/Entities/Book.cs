using C01.Interceptors.Entities.Contract;

namespace C01.Interceptors.Entities
{
    public class Book : ISoftDeleteable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
