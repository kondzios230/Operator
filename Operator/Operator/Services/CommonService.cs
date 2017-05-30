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
        public static bool Mock = true;
        protected ICamera camera = Mock ? (ICamera) new CameraMock() : (ICamera) new Camera();
    }
}
