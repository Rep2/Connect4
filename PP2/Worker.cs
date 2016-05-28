using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MPI;

public enum WorkerMessage : int
{
    Ready = 0
}

namespace PP2
{
    public class Worker
    {

        public void WaitForRequest()
        { 
            do
            {
                Communicator.world.Send<int>((int)WorkerMessage.Ready, 0, 0);

                WorkerRequest request = Communicator.world.Receive<WorkerRequest>(0, 1);

                var response = HandleRequest(request);

                Communicator.world.Send(response, 0, 2);
                Communicator.world.Receive<int>(0, 2);
                
            } while (true);

        }

        public WorkerResponse HandleRequest(WorkerRequest request)
        {
            int[] result = new int[7];

            for (int i = 0; i < 7; i++)
            {
                request.board[i].Add(request.potezRacunala ? PointState.White : PointState.Black);

                result[i] = CalculateVictory(request.board, i);

                request.board[i].RemoveAt(request.board[i].Count - 1);
            }

            WorkerResponse response = new WorkerResponse();
            response.parentId = request.parentId;

            if (request.potezRacunala)
            {     
                if (result.Contains(1))
                {
                    response.parentState = (int)State.Victory;
                }else
                {
                    response.parentState = (int)State.Unresolved;
                }

                response.children = new int[7];
                
                for (int i = 0; i < 7; i++)
                {
                    response.children[i] = result[i] == 1 ? (int)State.Victory : (int)State.Unresolved;
                }
            }
            else
            {
                if (result.Contains(1))
                {
                    response.parentState = (int)State.Defeat;
                }
                else
                {
                    response.parentState = (int)State.Unresolved;
                }

                response.children = new int[7];

                for (int i = 0; i < 7; i++)
                {
                    response.children[i] = result[i] == 1 ? (int)State.Defeat : (int)State.Unresolved;
                }
            }

            return response;
        }

        public int CalculateVictory(List<PointState>[] board, int lastMove)
        {
            var height = board[lastMove].Count - 1;
            var state = board[lastMove].Last();

            // Horisontal

            PointState l3 = (lastMove > 2 && board[lastMove - 3].Count > height) ? board[lastMove - 3].ElementAt(height) : PointState.Empty;
            PointState l2 = (lastMove > 1 && board[lastMove - 2].Count > height) ? board[lastMove - 2].ElementAt(height) : PointState.Empty;
            PointState l1 = (lastMove > 0 && board[lastMove - 1].Count > height) ? board[lastMove - 1].ElementAt(height) : PointState.Empty;

            PointState r3 = (lastMove < 4 && board[lastMove + 3].Count > height) ? board[lastMove + 3].ElementAt(height) : PointState.Empty;
            PointState r2 = (lastMove < 5 && board[lastMove + 2].Count > height) ? board[lastMove + 2].ElementAt(height) : PointState.Empty;
            PointState r1 = (lastMove < 6 && board[lastMove + 1].Count > height) ? board[lastMove + 1].ElementAt(height) : PointState.Empty;

            if(l3 == state && l2 == state && l1 == state)
            {
                return 1;
            }

            if (l2 == state && l1 == state && r1 == state)
            {
                return 1;
            }

            if (l1 == state && r1 == state && r2 == state)
            {
                return 1;
            }

            if (r1 == state && r2 == state && r3 == state)
            {
                return 1;
            }

            // Vertical

            if (height > 2) {
                PointState d3 = board[lastMove].ElementAt(height - 3);
                PointState d2 = board[lastMove].ElementAt(height - 2);
                PointState d1 = board[lastMove].ElementAt(height - 1);

                if (d3 == state && d2 == state && d1 == state)
                {
                    return 1;
                }
            }

            // Left diagonal

            PointState ld3 = (lastMove > 2 && height > 2 && board[lastMove - 3].Count > (height - 3)) ? board[lastMove - 3].ElementAt(height - 3) : PointState.Empty;
            PointState ld2 = (lastMove > 1 && height > 1 && board[lastMove - 2].Count > (height - 2)) ? board[lastMove - 2].ElementAt(height - 2) : PointState.Empty;
            PointState ld1 = (lastMove > 0 && height > 0 && board[lastMove - 1].Count > (height - 1)) ? board[lastMove - 1].ElementAt(height - 1) : PointState.Empty;

            PointState rd3 = (lastMove < 4 && board[lastMove + 3].Count > (height + 3)) ? board[lastMove + 3].ElementAt(height + 3) : PointState.Empty;
            PointState rd2 = (lastMove < 5 && board[lastMove + 2].Count > (height + 2)) ? board[lastMove + 2].ElementAt(height + 2) : PointState.Empty;
            PointState rd1 = (lastMove < 6 && board[lastMove + 1].Count > (height + 1)) ? board[lastMove + 1].ElementAt(height + 1) : PointState.Empty;

            if (ld3 == state && ld2 == state && ld1 == state)
            {
                return 1;
            }

            if (ld2 == state && ld1 == state && rd1 == state)
            {
                return 1;
            }

            if (ld1 == state && rd1 == state && rd2 == state)
            {
                return 1;
            }

            if (rd1 == state && rd2 == state && rd3 == state)
            {
                return 1;
            }

            // Right diagonal

            PointState dl3 = (lastMove > 2 && (board[lastMove - 3].Count > (height + 3))) ? board[lastMove - 3].ElementAt(height + 3) : PointState.Empty;
            PointState dl2 = (lastMove > 1 && (board[lastMove - 2].Count > (height + 2))) ? board[lastMove - 2].ElementAt(height + 2) : PointState.Empty;
            PointState dl1 = (lastMove > 0 && (board[lastMove - 1].Count > (height + 1))) ? board[lastMove - 1].ElementAt(height + 1) : PointState.Empty;

            PointState dr3 = (lastMove < 4 && height > 2 && (board[lastMove + 3].Count > (height - 3))) ? board[lastMove + 3].ElementAt(height - 3) : PointState.Empty;
            PointState dr2 = (lastMove < 5 && height > 1 && (board[lastMove + 2].Count > (height - 2))) ? board[lastMove + 2].ElementAt(height - 2) : PointState.Empty;
            PointState dr1 = (lastMove < 6 && height > 0 && (board[lastMove + 1].Count > (height - 1))) ? board[lastMove + 1].ElementAt(height - 1) : PointState.Empty;

            if (dl3 == state && dl2 == state && dl1 == state)
            {
                return 1;
            }

            if (dl2 == state && dl1 == state && dr1 == state)
            {
                return 1;
            }

            if (dl1 == state && dr1 == state && dr2 == state)
            {
                return 1;
            }

            if (dr1 == state && dr2 == state && dr3 == state)
            {
                return 1;
            }

            return 0;
        }

    }
}
