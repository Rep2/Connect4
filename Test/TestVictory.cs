using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PP2;

namespace Test
{
    [TestClass]
    public class TestVictory
    {
        [TestMethod]
        public void Test1()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test2()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test3()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test4()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test5()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 3) == 0);
        }

        [TestMethod]
        public void Test6()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test7()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 0);
        }
        
        [TestMethod]
        public void Test8()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 1);
        }

        [TestMethod]
        public void Test9()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(){ PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 6) == 0);
        }

        [TestMethod]
        public void Test10()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 0);
        }

        [TestMethod]
        public void Test11()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test12()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test13()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.White, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.White, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test14()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test15()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 1);
        }

        [TestMethod]
        public void Test16()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 1) == 1);
        }

        [TestMethod]
        public void Test17()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test18()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 1) == 1);
        }

        [TestMethod]
        public void Test19()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.White }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test20()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White  }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 1);
        }

        [TestMethod]
        public void Test21()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White  }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 1);
        }

        [TestMethod]
        public void Test22()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White  }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 0) == 0);
        }

        [TestMethod]
        public void Test23()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test24()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 0);
        }

        [TestMethod]
        public void Test25()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 2) == 1);
        }

        [TestMethod]
        public void Test26()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 1) == 1);
        }

        [TestMethod]
        public void Test27()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 3) == 1);
        }

        [TestMethod]
        public void Test28()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 3) == 1);
        }

        [TestMethod]
        public void Test29()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 3) == 0);
        }

        [TestMethod]
        public void Test30()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.White   },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White, PointState.White, PointState.White   },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 3) == 1);
        }

        [TestMethod]
        public void Test31()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.Black, PointState.White, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.Black  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.Black, PointState.White  },
                new List<PointState>() { PointState.White, PointState.White, PointState.White, PointState.White, PointState.White, PointState.White   },
                new List<PointState>() { PointState.White, PointState.Black, PointState.White, PointState.White, PointState.White, PointState.White, PointState.White   },
                new List<PointState>() { PointState.Black, PointState.Black }
            };

            var worker = new Worker();

            Assert.IsTrue(worker.CalculateVictory(boardState, 5) == 1);
        }
    }
}
