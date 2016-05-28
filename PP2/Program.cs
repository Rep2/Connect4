using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
using System.Globalization;

namespace PP2
{

    public enum PointState : int
    {
        White = 0, Black, Empty
    }

    public enum State : int
    {
        Victory = 0, Defeat, Unresolved
    }

    struct Result
    {
        public int state;
        public double value;
    }

    class Node
    {
        public Guid id;

        public Result result;
        public List<int> moves;

        public List<Node> children;
    }

    [Serializable]
    public struct WorkerRequest
    {
        public List<PointState>[] board;
        public bool potezRacunala;

        public Guid parentId;
    }

    [Serializable]
    public struct WorkerResponse
    {
        public int parentState;
        public int[] children;

        public Guid parentId;
    }

    class Program
    {


        static void Main(string[] args)
        {

            using (new MPI.Environment(ref args))
            {
                if (Communicator.world.Rank == 0)
                {

                    var ai = new AIPlayer();
                    var handler = new BoardHandler();

                    while (true)
                    {
                        handler.DrawBoard();

                        bool success = false;
                        do
                        {
                            Console.WriteLine("Enter row number and press enter");
                            var input = Console.Read();
                            Console.WriteLine();


                            var rowNumber = Convert.ToChar(input) - '0';

                            var flush = Console.ReadLine();

                            if (rowNumber < 1 || rowNumber > 7)
                            {
                                throw new Exception();
                            }
                            else
                            {
                                var board = handler.AddState(PointState.Black, rowNumber);
                                success = true;

                                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture));

                                var move = ai.NextMove(board, 6) + 1;
                                handler.AddState(PointState.White, move);

                                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture));
                            }


                        } while (!success);
                    }

                }
                else
                {
                    var worker = new Worker();

                    worker.WaitForRequest();
                }

            }

        }



    }
}
