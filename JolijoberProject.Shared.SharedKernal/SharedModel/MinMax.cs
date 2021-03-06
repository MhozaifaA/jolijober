﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Shared.SharedKernal.SharedModel
{
    public class MinMax
    {

        public MinMax(double min = 0, double max = 0)
        {
            Min = min;
            Max = max;
        }

        public double Min  {get; private set; }
        public double Max { get; private set; }


        public override string ToString()
        {
            return $"{Min}-{Max}";
        }

    }
}
