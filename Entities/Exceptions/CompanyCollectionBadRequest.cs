namespace Entities.Exceptions
{
    public class CompanyCollectionBadRequest()
        : BadRequestException("Company collection sent from a client is null");
}