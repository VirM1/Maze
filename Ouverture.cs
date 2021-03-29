using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Ouverture
    {
        private int type;

        public Ouverture(int from_where)
        {
            this.type = from_where;
        }


        public int getType()
        {
            return this.type;
        }
    }
}
