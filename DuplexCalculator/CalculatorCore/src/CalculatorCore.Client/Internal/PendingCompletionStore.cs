using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorCore.Client
{
    /// <summary>
    /// Stores <see cref="TaskCompletionSource{TResult}"/> objects used for request/response calls over streams.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public sealed class PendingCompletionStore
    {
        private readonly TimedDictionary _completionSources;
        private long _nextId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingCompletionStore"/> class.
        /// </summary>
        /// <param name="maxAge">The maximum time to hold completions.</param>
        public PendingCompletionStore(TimeSpan maxAge)
        {
            _completionSources = new TimedDictionary(maxAge);
        }

        /// <summary>
        /// Creates a <see cref="TaskCompletionSource{TResult}"/> with a unique ID.
        /// </summary>
        /// <typeparam name="T">The type of the completion.</typeparam>
        /// <returns>A unique ID and the completion source.</returns>
        public (long id, TaskCompletionSource<T> completionSource) Create<T>()
        {
            var id = Interlocked.Increment(ref _nextId);
            var completionSource = new TaskCompletionSource<T>();
            _completionSources.Add(id, completionSource);
            return (id, completionSource);
        }

        /// <summary>
        /// Completes the task with the specified ID.
        /// </summary>
        /// <typeparam name="T">The type of the completion</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="InvalidOperationException">Completion is wrong type.</exception>
        public void Complete<T>(long id, T value)
        {
            if (_completionSources.TryRemove(id, out var obj) && obj is TaskCompletionSource<T> completionSource)
            {
                completionSource.SetResult(value);
            }
        }
    }
}
