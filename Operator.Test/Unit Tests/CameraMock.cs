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
        public int status=0;

        public Task<string> StartRecording()
        {
            return Task.Run(()=>string.Format(@"<?xml version=""1.0""?><Function><Cmd>2001</Cmd><Status>{0}</Status></Function>",status.ToString()));
        }
    }
}
