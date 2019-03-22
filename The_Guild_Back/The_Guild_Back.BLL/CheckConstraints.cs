using System;
using System.Collections.Generic;
using System.Text;

namespace The_Guild_Back.BLL
{
    static class CheckConstraints
    {
        static public bool NonNegativeInt(int? value) 
        {
            if(value == null)
            {
                return true;
            }
            else if(value >= 0)
            {
                return true;
            }

            //else if value < 0
            return false;
        }

        static public bool NonNegativeDecimal(decimal? value)
        {
            if (value == null)
            {
                return true;
            }
            else if (value >= 0)
            {
                return true;
            }

            //else if value < 0
            return false;
        }


    }
}
