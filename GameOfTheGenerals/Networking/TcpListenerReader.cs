using System;

namespace GameOfTheGenerals
{
    public class TcpListenerSender
    {
        
        public static void Listen(ICallback callback, ISocket socket)
        {
            StateObject state = new StateObject();
            state.workSocket = socket;
            socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(callback.Callback), state);
        }

        public static void Send(ICallback callback, ISocket socket, byte[] data)
        {
            socket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(callback.Callback), socket);
        }

    }
}