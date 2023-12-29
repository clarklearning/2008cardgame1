using System;
using System.Collections.Generic;

namespace DiyCollection16{
    class StringNumberComparison : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if(x == y){
                return 0;
            }
            if(x == null){
                return -1;
            }
            if(y == null){
                return 1;
            }
            return x.Length - y.Length;
        }
    }
}