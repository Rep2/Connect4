using Microsoft.VisualStudio.TestTools.UnitTesting;
using PP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TestWorkerResponse
    {
        [TestMethod]
        public void Test1()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Unresolved);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Unresolved);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Unresolved);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test2()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Unresolved);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Unresolved);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Unresolved);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test3()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Victory);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Unresolved);
            Assert.IsTrue(response.children[2] == (int)State.Victory);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Unresolved);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test4()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>(),
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Unresolved);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Unresolved);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Unresolved);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test5()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>(),
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Victory);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Victory);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Unresolved);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test6()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.Black },
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = false
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Defeat);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Defeat);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Defeat);
            Assert.IsTrue(response.children[5] == (int)State.Defeat);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }

        [TestMethod]
        public void Test7()
        {
            var boardState = new List<PointState>[7] {
                new List<PointState>() { PointState.White, PointState.Black },
                new List<PointState>() { PointState.Black },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.Black, PointState.White },
                new List<PointState>() { PointState.White, PointState.White, PointState.White  },
                new List<PointState>() { PointState.Black, PointState.Black, PointState.Black },
                new List<PointState>()
            };

            var request = new WorkerRequest()
            {
                board = boardState,
                potezRacunala = true
            };

            var worker = new Worker();

            var response = worker.HandleRequest(request);

            Assert.IsTrue(response.parentState == (int)State.Victory);

            Assert.IsTrue(response.children[0] == (int)State.Unresolved);
            Assert.IsTrue(response.children[1] == (int)State.Victory);
            Assert.IsTrue(response.children[2] == (int)State.Unresolved);
            Assert.IsTrue(response.children[3] == (int)State.Unresolved);
            Assert.IsTrue(response.children[4] == (int)State.Victory);
            Assert.IsTrue(response.children[5] == (int)State.Unresolved);
            Assert.IsTrue(response.children[6] == (int)State.Unresolved);
        }
    }
}
