using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    public interface IVideoService
    {
        VideoStartStatusEnum StartRecording();
    }
}
