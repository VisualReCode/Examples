using System;
using System.Collections.Generic;
using System.Threading;

namespace CalculatorCore.Client
{
    /// <summary>
    /// A Dictionary with a time limit on entries.
    /// </summary>
    internal class TimedDictionary
    {
        private readonly object _sync = new object();
        private readonly int _timeoutMilliseconds;
        private Dictionary<long, object> _current = new Dictionary<long, object>();
        private Dictionary<long, object> _previous = new Dictionary<long, object>();
        private int _lastSwap = Environment.TickCount & int.MaxValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimedDictionary" /> class.
        /// </summary>
        /// <param name="timeout">The timeout after which to purge old data.</param>
        /// <remarks>
        /// Due to the implementation, objects may live in the dictionary for up to twice as long as the timeout.
        /// </remarks>
        public TimedDictionary(TimeSpan timeout)
        {
            if (timeout.TotalMilliseconds > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be less than 24.9 days");
            }
            _timeoutMilliseconds = (int)timeout.TotalMilliseconds;
        }

        /// <summary>
        /// Adds an object to the dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(long key, object value)
        {
            lock (_sync)
            {
                CheckTimeOut();
                _current[key] = value;
            }
        }

        /// <summary>
        /// Tries to remove an object and return the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value, or <c>null</c> if the key was not present.</param>
        /// <returns><c>true</c> if the key was found; otherwise, <c>false</c>.</returns>
        public bool TryRemove(long key, out object value)
        {
            lock (_sync)
            {
                if (_current.TryGetValue(key, out value))
                {
                    _current.Remove(key);
                }
                else if (_previous.TryGetValue(key, out value))
                {
                    _previous.Remove(key);
                }
                CheckTimeOut();
            }

            return !(value is null);
        }

        private void CheckTimeOut()
        {
            // IMPORTANT: this should only be called from within locks
            // Force ticks to a positive number
            int ticks = Environment.TickCount & int.MaxValue;
            int delta = ticks - _lastSwap;

            if (delta > _timeoutMilliseconds)
            {
                _lastSwap = ticks;
                _previous.Clear();
                _previous = Interlocked.Exchange(ref _current, _previous);
            }
        }
    }
}
