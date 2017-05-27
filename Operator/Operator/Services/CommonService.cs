using Operator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Services
{
    public abstract class CommonService
    {
        protected ICamera camera = new CameraMock();
    }
}
