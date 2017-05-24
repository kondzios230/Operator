﻿using Operator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Interfaces
{
    public interface IVideoService
    {
        Task<VideoStartStatusEnum> StartRecording();
    }
}
