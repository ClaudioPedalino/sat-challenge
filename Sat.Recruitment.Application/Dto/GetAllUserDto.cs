namespace Sat.Recruitment.Application.Dto
{
    public class GetAllUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal? MoneyFrom { get; set; }
        public decimal? MoneyTo { get; set; }
        public bool BypassCache { get; set; }
        public virtual int PageNumber { get; set; }
        public virtual int PageSize { get; set; }
    }
}
