using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
using System.Threading;

namespace PP2
{
    class AIPlayer
    {
        List<Node> completedNodes = new List<Node>();
        int depth;

        List<Node> peedingNodes = new List<Node>();
        int inProgress = 0;

        Node root;

        public void ProbeForWorkersAndResponse(List<PointState>[] board)
        {
            do
            {
                if (peedingNodes.Count > 0)
                {
                   // Console.WriteLine("Looking for worker with count " + peedingNodes.Count);
                    var status = Communicator.world.ImmediateProbe(Communicator.anySource, 0);

                    if (status != null)
                    {
                     //   Console.WriteLine("Found worker with count " + peedingNodes.Count);
                        var message = Communicator.world.Receive<int>(status.Source, 0);

                        switch (message)
                        {
                            case (int)WorkerMessage.Ready:
                             //   Console.WriteLine("Initing worker job with count " + peedingNodes.Count);
                                var node = peedingNodes.ElementAt(0);
                                completedNodes.Add(node);
                                peedingNodes.RemoveAt(0);

                                SendRequest(status.Source, node, board);
                                
                                break;
                            default:
                                throw new Exception("Wrong status in find worker");
                        }
                    }
                }

                if (inProgress > 0)
                {
                    var status = Communicator.world.ImmediateProbe(Communicator.anySource, 2);

                    if (status != null)
                    {
                        var response = Communicator.world.Receive<WorkerResponse>(status.Source, 2);
                        HandleResponse(response);
                        Communicator.world.Send(0, status.Source, 2);
                    }
                }

               // Thread.Sleep(1);
            } while (peedingNodes.Count > 0 || inProgress > 0);
        }
    

        public int NextMove(List<PointState>[] board, int depth)
        {
            this.depth = depth;

            root = new Node()
            {
                id = Guid.NewGuid(),
                moves = new List<int>()
            };

            peedingNodes.Add(root);

            List<PointState>[] newBoard = new List<PointState>[7];
            for (int i = 0; i < 7; i++)
            {
                newBoard[i] = new List<PointState>();

                foreach (PointState state in board[i])
                {
                    newBoard[i].Add(state);
                }
            }

            ProbeForWorkersAndResponse(newBoard);

            CalculateNodes(root);


            var maxVal = -2.0;
            int index = 0;

            Console.WriteLine("Values");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(root.children.ElementAt(i).result.value);
                if(root.children.ElementAt(i).result.value > maxVal)
                {
                    maxVal = root.children.ElementAt(i).result.value;
                    index = i;
                }  
                
                if(root.children.ElementAt(i).result.value == 1)
                {
                    Console.WriteLine("Won with placment at row " + (i + 1));
                } 
            }

            if(maxVal == -1)
            {
                Console.WriteLine("Lost");
            }

            Console.WriteLine();
            Console.WriteLine("Selected row " + (index + 1));
            Console.WriteLine();

            return index;
        }

        public void SendRequest(int worker, Node node, List<PointState>[] board)
        {
           // Console.WriteLine("Sending request job with count " + peedingNodes.Count);

            for (int i = 0; i < node.moves.Count; i++)
            {
                board[node.moves[i]].Add((i % 2) == 0 ? PointState.White : PointState.Black);
            }

            WorkerRequest request = new WorkerRequest()
            {
                board = board,
                potezRacunala = (node.moves.Count % 2) == 0,
                parentId = node.id
            };
           
           // Console.WriteLine("Trying to send progres with count " + inProgress);


            inProgress++;

            Communicator.world.Send(request, worker, 1);

        //    Console.WriteLine("Sent request job in progres with count " + inProgress);

            for (int i = 0; i < node.moves.Count; i++)
            {
                board[node.moves[i]].RemoveAt(board[node.moves[i]].Count - 1);
            }
        }

        public void HandleResponse(WorkerResponse response)
        {

            inProgress--;

            Node node = completedNodes.Where(s => s.id == response.parentId).First();
            completedNodes.Remove(node);

            node.result = new Result()
            {
                state = response.parentState
            };

            List<Node> children = new List<Node>();

            for(int j = 0; j < response.children.Count(); j++)
            {
                var newNode = new Node()
                {
                    id = Guid.NewGuid(),
                    moves = new List<int>(),
                    result = new Result()
                    {
                        state = response.children[j]
                    }
                };

                children.Add(newNode);

                for (int i = 0; i < node.moves.Count; i++)
                {
                    newNode.moves.Add(node.moves[i]);
                }

                newNode.moves.Add(j);

                if (newNode.result.state == (int)State.Unresolved && node.moves.Count() < (depth -1) )
                {
                    peedingNodes.Add(newNode);
                }                
            }

            node.children = children;
        }

        public double CalculateNodes(Node node)
        {
            if (node.children != null)
            {
                double newValue = 0;

                foreach (Node children in node.children)
                {
                    newValue += CalculateNodes(children);
                }

                node.result.value = newValue/7.0;
            }

            if (node.result.state == (int)State.Victory)
            {
                node.result.value = 1;
            }else if (node.result.state == (int)State.Defeat)
            {
                node.result.value = -1;
            }

            return node.result.value;
        }

    }
}
