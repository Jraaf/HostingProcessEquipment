namespace BLL.Exceptions;

public class ContractException : Exception
{
    public ContractException()
    : base()
    {

    }
    public ContractException(string message)
        : base(message)
    {

    }
    public ContractException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}
