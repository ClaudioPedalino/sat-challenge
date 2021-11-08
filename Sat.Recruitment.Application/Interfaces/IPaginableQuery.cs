namespace Sat.Recruitment.Application.Interfaces
{
    /// <summary>
    /// This interfaces is to implement pagination into query-objects
    /// </summary>
    public interface IPaginableQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }


}
