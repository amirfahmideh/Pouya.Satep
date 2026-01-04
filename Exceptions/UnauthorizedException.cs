namespace Pouya.Satep;

public class UnauthorizedException : Exception
{
    public UnauthorizedException()
    {

    }
    public UnauthorizedException(string implementTypeTitle)
    : base(implementTypeTitle)
    {

    }
    public UnauthorizedException(string implementTypeTitle, Exception innerException)
    : base(implementTypeTitle, innerException)
    {

    }
}