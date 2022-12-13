using System.Threading;
using System.Threading.Tasks;

namespace Oip.Core.Runtime;

public interface IStartupRunner
{
    Task StartupAsync(CancellationToken cancellationToken = default);
}