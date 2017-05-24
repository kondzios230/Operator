using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Utils
{
    public static class EnumResponseCodesMapper
    {
        public static readonly Dictionary<string, VideoStartStatusEnum> VideoStatusMapper = new Dictionary<string, VideoStartStatusEnum>() { { "0", VideoStartStatusEnum.Success }, { "-11", VideoStartStatusEnum.FailNotEnoughSpace }, { "-13", VideoStartStatusEnum.FailWrongMode }, { "-22", VideoStartStatusEnum.FailNoCard } };
    }
}
