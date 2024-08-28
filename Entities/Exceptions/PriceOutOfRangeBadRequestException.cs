namespace Entities.Exceptions
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() 
            : base("Price should be greater than 10 and less than 1000.") 
        {
        
        }
    }
}
