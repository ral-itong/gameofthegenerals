using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameOfTheGeneralsUnitTests
{
    public class MockAsyncResult : IAsyncResult
    {
        private object _fakeAsyncState;

        public object AsyncState
        {
            get
            {
                return _fakeAsyncState;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return true;
            }
        }

        public object FakeAsyncState
        {
            get
            {
                return _fakeAsyncState;
            }

            set
            {
                _fakeAsyncState = value;
            }
        }

        public bool IsCompleted
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
