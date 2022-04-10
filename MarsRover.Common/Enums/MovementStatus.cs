using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common.Enums
{
    public enum  MovementStatus
    {
        [Description("Rigth")]
        R = 'R', 
        [Description("Left")]
        L = 'L', 
        [Description("Move")]
        M = 'M'  
    }
}
