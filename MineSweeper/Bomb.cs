using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Bomb
    {
        private bool isBomb;
        private int count;
        private char hidden = 'X';
        private bool isSelected = false;

       
        
        public Bomb(bool isBomb)
        {
               this.isBomb = isBomb;
        }
      public Bomb(int count)
        {
            this.count = count;
            this.isBomb = false;
        }
        public bool IsSelected { get { return isSelected; } set { isSelected = value; } }
        public bool IsBomb { get { return isBomb; } set { isBomb = value; } }
        public int Count { get { return count; } set { count = value; } }

       public char Hidden { get { return hidden; } }
    }
}
