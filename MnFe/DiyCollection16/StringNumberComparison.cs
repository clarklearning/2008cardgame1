using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace DiyCollection16{
    /// <summary>
    /// 按照文字长度比string的大小
    /// </summary>
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

    class StringNumberEquality : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if(object.ReferenceEquals(x, y)){
                return true;
            }
            if(x == null || y == null){
                return false;
            }
            return x.Length == y.Length;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.Length;
        }
    }
}