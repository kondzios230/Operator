using System.Threading.Tasks;

namespace Operator.Interfaces
{
    public interface ICamera
    {
        Task<string> StartRecording();

        Task<string> GetImages();
    }
}
