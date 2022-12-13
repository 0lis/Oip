using System.Threading;
using System.Threading.Tasks;

namespace Oip.Core.HostedServices;

public interface IScopedBackgroundService
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}