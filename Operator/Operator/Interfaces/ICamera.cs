using System.Threading.Tasks;

namespace Operator
{
    public interface ICamera
    {
        Task<string> StartRecording();
    }
}
