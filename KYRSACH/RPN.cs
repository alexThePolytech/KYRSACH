using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace KYRSACH
//{
//    public class RPN
//    {
//        public static double evalrpn(Stack<string> tks)
//        {
//            string tk = tks.Pop();
//            double x, y;
//            if (!Double.TryParse(tk, out x))
//            {
//                y = evalrpn(tks); x = evalrpn(tks);
//                if (tk == "+") x += y;
//                else if (tk == "-") x -= y;
//                else if (tk == "*") x *= y;
//                else if (tk == "/") x /= y;
//                else throw new Exception();
//            }
//            return x;
//        }
//    }
//}
