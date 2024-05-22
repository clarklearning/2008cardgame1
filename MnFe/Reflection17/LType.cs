using System;
using System.Security.Cryptography.X509Certificates;

namespace Reflection17
{
    class LType
    {
        public LType(){
            Type type= typeof(string);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.IsPublic);
            Console.WriteLine(type.BaseType);
            foreach (Type t in type.GetInterfaces()){
                Console.WriteLine(t.Name);
            }
            Console.WriteLine(type.GetMethods().Length);
            foreach( var v in type.GetMethods()){
                Console.WriteLine(v.Name);
            }
            Console.WriteLine(type.Assembly);
        }
    }
}