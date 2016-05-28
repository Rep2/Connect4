using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2
{
    class ScreenDrawer
    {

        public void DrawBoard(List<PointState>[] boardState)
        {
            int i = 0;
            bool hasPoint = false;

            Console.WriteLine("1 2 3 4 5 6 7");

            do
            {
                hasPoint = false;

                foreach (List<PointState> list in boardState)
                {
                    if (i < list.Count)
                    {
                        switch (list.ElementAt(i))
                        {
                            case PointState.Black:
                                Console.Write("+ ");
                                hasPoint = true;
                                break;
                            case PointState.White:
                                Console.Write("- ");
                                hasPoint = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                i++;

                Console.WriteLine();

            } while (hasPoint);
        }

    }
}
