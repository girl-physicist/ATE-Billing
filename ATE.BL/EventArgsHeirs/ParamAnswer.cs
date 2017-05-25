﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;

namespace ATE.BL.EventArgsHeirs
{
  public  class ParamAnswer:EventArgsAnswer
  {
        private string _param;
        public string Param { get => _param; set => _param = value; }
        public ParamAnswer(int number, int target, CallState state, DateTime startCall)
            : base(number, target, state, startCall)
        {
            if ()
            _param = "Answer";
            else if ()
            {
                _param = "Reject";
            }
        }

      public ParamAnswer(char option)
      {
          if (option==)
              _param = "Answer";
          else if (option==)
          {
              _param = "Reject";
          }
        }
       
    }
}
