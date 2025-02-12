namespace Entities.Exceptions
{
    public sealed class MaxAgeRangeBadRequestException()
        : BadRequestException("Max age can't be less than min age");
}