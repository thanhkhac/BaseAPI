namespace Entities.Exceptions
{
    public sealed class IdParametersBadRequestException()
        : BadRequestException("Parameter ids is null");
}