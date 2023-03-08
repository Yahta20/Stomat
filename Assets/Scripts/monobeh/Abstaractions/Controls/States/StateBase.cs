using System.Collections.Generic;
using System.Diagnostics;

public abstract class StateBase
{
    public abstract void Start();
    public abstract void Update();
    public abstract void Stop();
    protected Stopwatch sw;
    protected TimeStatistic tstat;

    public StateBase()
    {
        sw = Stopwatch.StartNew();
        tstat.StartTime(sw.Elapsed);
        //Console.WriteLine("Instantiated object");
    }

    public void ShowDuration()
    {
        tstat.ChekTime(sw.Elapsed);
        UnityEngine.MonoBehaviour.print($"This instance of {this} has been in existence for {tstat.Elapse()} & {sw.Elapsed}");
        
    }

    /*
     */
    ~StateBase()
    {
        tstat.ChekTime(sw.Elapsed);
        UnityEngine.MonoBehaviour.print("Finalizing object");
        sw.Stop();
        UnityEngine.MonoBehaviour.print($"This instance of {this} has been in existence for {tstat.Elapse()} & {sw.Elapsed}");
    }
}