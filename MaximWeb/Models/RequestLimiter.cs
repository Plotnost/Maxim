namespace MaximWeb.Models;

public class RequestLimiter
    {
        private int _currentRequests;
        private readonly int _parallelLimit;
        private readonly object _lockObject = new();

        public RequestLimiter(int parallelLimit)
        {
            _parallelLimit = parallelLimit;
        }

        public bool TryStartRequest()
        {
            lock (_lockObject)
            {
                if (_currentRequests < _parallelLimit)
                {
                    _currentRequests++;
                    return true;
                }

                return false;
            }
        }

        public void EndRequest()
        {
            lock (_lockObject)
            {
                _currentRequests--;
            }
        }
    }
