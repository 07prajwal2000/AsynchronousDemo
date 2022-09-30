using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousDemo;

internal class SyncToAsync
{
    public async Task RunInAsync()
    {
        await Task.Run(() =>
        {
            var i = 0;
            while (i++ < 10_000_000) // 10M Executions might block main thread.
            {
                // Write Synchronous code here.
            }
        });
    }

    public async Task RunMultipleTasksAsync()
    {
        await Task.Run(() =>
        {
            var i = 0;
            while (i++ < 1_000_000) 
            {
                // Write Synchronous code here.
            }
        });

        // Async function with Return value.
        var iterations = await Task.Run(() => 
        {
            var i = 0;
            while (i++ < 1_000_000) 
            {
                // Write Synchronous code here.
            }
            return i;
        });

    }
    
    public async Task RunMultipleTasks_FastAsync()
    {
        var t1 = Task.Run(() =>
        {
            var i = 0;
            while (i++ < 1_000_000) 
            {
                // Write Synchronous code here.
            }
        });
        var t2 = Task.Run(() =>
        {
            var i = 0;
            while (i++ < 1_000_000) 
            {
                // Write Synchronous code here.
            }
        });
        var t3 = Task.Run(() =>
        {
            var i = 0;
            while (i++ < 1_000_000)
            {
                // Write Synchronous code here.
            }
        });

        await Task.WhenAll(t1, t2, t3); // Waits until all the tasks to complete execution
    }
    
    public async ValueTask<int> SyncAndAsyncReturns()
    {
        var random = new Random();
        var i = random.Next(0, 150);

        if (i < 85)
        {
            return i;
        }

        await Task.Run(() =>
        {
            while (i++ < 250)
            {

            }
        });
        return i;
    }

}
