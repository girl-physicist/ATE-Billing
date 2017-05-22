﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
   public interface IEventArgsCalling
    {
        int TelephoneNumber { get; }
        int TargetTelephoneNumber { get; }
        Guid Id { get; }
    }
}
