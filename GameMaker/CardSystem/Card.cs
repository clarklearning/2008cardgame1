using System;

namespace CardSystem
{
    class Card
    {
        private static int idCount = 0;
        public int Id {get{return Id;}}
        public Card(){
            idCount++;
            Id = idCount;
        }
    }
}