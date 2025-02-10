namespace Entities.Exceptions
{
    public class CollectionByIdsBadRequestException()
        : BadRequestException("Collection count mismatch comparing to ids.");
}