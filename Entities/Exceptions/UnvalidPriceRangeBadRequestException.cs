namespace Entities.Exceptions
{
    public class UnvalidPriceRangeBadRequestException : BadRequestException
    {
        public UnvalidPriceRangeBadRequestException() 
            : base("Max price should be greater than min price.") 
        {
            
        }
    }
}
