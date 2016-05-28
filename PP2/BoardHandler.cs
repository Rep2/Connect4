using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2
{
    public class BoardHandler
    {
        List<PointState>[] boardState;

        ScreenDrawer drawer;

        public BoardHandler()
        {
            boardState = new List<PointState>[7] {
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            drawer = new ScreenDrawer();
        }

        public void DrawBoard()
        {
            drawer.DrawBoard(boardState);
        }

        public List<PointState>[] AddState(PointState state, int row)
        {
            boardState[row - 1].Add(state);

            return boardState;
        }

    }
}
