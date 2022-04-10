using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common.Enums
{
    public enum DirectionStatus
    {
        [Description("North")]
        N = 1,
        [Description("East")]
        E = 2,
        [Description("South")]
        S = 3,
        [Description("West")]
        W = 4
    }
}
