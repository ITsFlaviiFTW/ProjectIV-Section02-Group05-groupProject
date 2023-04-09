using StormSocial_Server.Classes;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StateMachineTests
{
    [TestClass]
    public class StateMachineTests
    {
        [TestMethod]
        public void TestInitialState()
        {
            var stateMachine = new StateMachine();
            Assert.AreEqual(StateMachine.ServerState.OffState, stateMachine.CurrentState);
        }

        [TestMethod]
        public async Task TestServerState_ServerIsTurnedOn()
        {
            var stateMachine = new StateMachine();

            stateMachine.TransitionTo(StateMachine.ServerState.OnState);
            Assert.AreEqual(StateMachine.ServerState.OnState, stateMachine.CurrentState);

        }
        [TestMethod]
        public async Task TestServerState_ServerIsTransferredFromOnToChat()
        {
            var stateMachine = new StateMachine();

            // Test transition from OnState to ChatState
            stateMachine.TransitionTo(StateMachine.ServerState.ChatState);
            Assert.AreEqual(StateMachine.ServerState.ChatState, stateMachine.CurrentState);
        }
        [TestMethod]
        public async Task TestClientConnection_Disconnect()
        {
            var stateMachine = new StateMachine();
            stateMachine.TransitionTo(StateMachine.ServerState.OnState);
            Assert.AreEqual(StateMachine.ServerState.OnState, stateMachine.CurrentState);

            using (var client = new TcpClient())
            {
                await client.ConnectAsync(IPAddress.Loopback, 1234);
                var stream = client.GetStream();

                // Close the stream and the client.
                stream.Close();
                client.Close();

                // The server should still be in the OnState after 1 second.
                await Task.Delay(TimeSpan.FromSeconds(1));
                Assert.AreEqual(StateMachine.ServerState.OnState, stateMachine.CurrentState);
            }
        }
    }
}