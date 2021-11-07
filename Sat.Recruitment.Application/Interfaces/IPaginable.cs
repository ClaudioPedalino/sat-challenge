namespace Sat.Recruitment.Application.Interfaces
{
    public interface IPaginable
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public record Paginable : IPaginable
    {
        public Paginable()
        {
            PageNumber = 1;
            PageSize = 15;
        }

        public virtual int PageNumber { get; set; }
        public virtual int PageSize { get; set; }
    }
}
