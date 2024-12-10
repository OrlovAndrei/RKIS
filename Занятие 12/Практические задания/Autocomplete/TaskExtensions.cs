using System;
using System.Threading;
using System.Threading.Tasks;

namespace Autocomplete;

public static class TaskExtensions
{
	public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
	{
		var timeoutCancellationTokenSource = new CancellationTokenSource();

		var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
		if (completedTask == task)
		{
			timeoutCancellationTokenSource.Cancel();
			return await task;
		}

		throw new TimeoutException("The operation has timed out.");
	}
}