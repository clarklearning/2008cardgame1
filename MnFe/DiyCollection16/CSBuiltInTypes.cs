
using System.Collections;

namespace DiyCollection16{
    class CSBuiltInTypes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "object";
            yield return "btye";
            yield return "uint";
            yield return "ulong";
            yield return "float";
            yield return "char";
            yield return "bool";
            yield return "ushort";
            yield return "decimal";
            yield return "int";
            yield return "sbyte";
            yield return "short";
            yield return "long";
            yield return "void";
            yield return "double";
            yield return "string";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}