using Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Test
{
    public class CameraMock : ICamera
    {
        public string StartRecording()
        {
            return "<?xml version=''1.0'' encoding=''UTF-8'' ?><Function><Cmd>2001</Cmd><Status>0</Status></Function>";
        }
    }
}
