using System.Threading;
using System.Threading.Tasks;

namespace Oip.Core.Startup;

public interface IStartupTask
{
    int Order { get; }
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}