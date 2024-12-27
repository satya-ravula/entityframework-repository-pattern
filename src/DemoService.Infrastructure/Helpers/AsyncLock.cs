namespace DemoService.Infrastructure.Helpers
{
    /// <summary>
    /// Provides a mechanism for asynchronous locking.
    /// </summary>
    public sealed class AsyncLock
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly Task<IDisposable> _releaser;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncLock"/> class.
        /// </summary>
        public AsyncLock()
        {
            _releaser = Task.FromResult((IDisposable)new Releaser(this));
        }

        /// <summary>
        /// Asynchronously acquires the lock.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. 
        /// The task result is a <see cref="IDisposable"/> instance that releases the lock when disposed.
        /// </returns>
        public Task<IDisposable> LockAsync()
        {
            var wait = _semaphore.WaitAsync();
            return wait.IsCompleted ? _releaser : wait.ContinueWith((_, state) => (IDisposable)state, _releaser.Result, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        /// <summary>
        /// Represents a disposable object that releases the associated <see cref="AsyncLock"/> when disposed.
        /// </summary>
        private sealed class Releaser : IDisposable
        {
            private readonly AsyncLock _toRelease;

            /// <summary>
            /// Initializes a new instance of the <see cref="Releaser"/> class with the specified <see cref="AsyncLock"/>.
            /// </summary>
            /// <param name="toRelease">The <see cref="AsyncLock"/> to release when disposed.</param>
            internal Releaser(AsyncLock toRelease) { _toRelease = toRelease; }

            /// <summary>
            /// Releases the associated <see cref="AsyncLock"/>.
            /// </summary>
            public void Dispose() { _toRelease._semaphore.Release(); }
        }
    }
}
