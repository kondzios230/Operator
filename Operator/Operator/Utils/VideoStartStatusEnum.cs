using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Utils
{
    public enum VideoStartStatusEnum
    {
        Success = 0,
        FailNotEnoughSpace = -11,
        FailWrongMode = -13,
        FailNoCard = -22
    }     
}
