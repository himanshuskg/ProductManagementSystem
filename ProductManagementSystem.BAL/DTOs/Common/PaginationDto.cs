namespace ProductManagementSystem.BAL.DTOs.Common
{
    public class PaginationDto
    {
        private const int MaxPageSize = 100;

        private int _page = DefaultConstants.DefaultPage;
        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        private int _pageSize = DefaultConstants.DefaultPageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        public int Skip => (Page - 1) * PageSize;
    }


}
