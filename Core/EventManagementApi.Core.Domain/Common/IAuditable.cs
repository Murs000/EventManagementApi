using System.Threading.Tasks.Dataflow;

namespace EventManagementApi.Core.Domain.Common;

public interface IAuditable<T> : ICreatable<T>, IEditable<T>
{
    public T SetCredentials(int userId);
}