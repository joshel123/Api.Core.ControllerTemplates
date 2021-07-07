namespace Api.Core.ControllerTemplates.DataAccessInterfaces
{
    public interface IReadWriteExecuteDataAccessService<T> : IReadDataAccessService<T>, IWriteDataAccessService<T>, IExecuteDataAccessService<T>
    {



    }
}
