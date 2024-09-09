using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Debouncer
{
    private CancellationTokenSource cancellationTokenSource;
    private readonly int delayMilliseconds;

    public Debouncer(int delayMilliseconds = 300)
    {
        this.delayMilliseconds = delayMilliseconds;
    }

    public void Debounce(Action action)
    {
        //Cancels previous token if it exists
        cancellationTokenSource?.Cancel();
        cancellationTokenSource = new CancellationTokenSource();

        var token = cancellationTokenSource.Token;
        Task.Delay(delayMilliseconds, token).ContinueWith(t =>
        {
            if (!t.IsCanceled)
            {
                action.Invoke();
            }
        }, TaskScheduler.Default);
    }
}