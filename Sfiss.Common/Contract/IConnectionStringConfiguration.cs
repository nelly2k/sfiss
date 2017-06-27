namespace Sfiss.Common.Contract
{
    public interface IConnectionStringConfiguration:IService
    {
        string ConnectionString { get; }
    }
}
