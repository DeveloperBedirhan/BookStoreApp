namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int MaxPageSize = 50;
        
        //Auto-implemented property
        public int PageNumber { get; set; }

        //Full-property
        private int _pageSize;
        public int PageSize 
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public string? OrderBy { get; set; }
        public string? Fields { get; set; }
    }
}
