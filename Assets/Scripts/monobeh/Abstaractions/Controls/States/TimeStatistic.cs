using System;


public struct TimeStatistic {
    TimeSpan tstart;
    TimeSpan tElapsed;
    TimeSpan[] hRequest;

    public void StartTime(TimeSpan start) {
        tstart = start;
        UpdateHistory(start);
    }

    public void ChekTime(TimeSpan start) {
        UpdateHistory(start);
    }
    public TimeSpan Elapse() => tElapsed;
    public TimeSpan[] History() => hRequest;

    public TimeSpan ElapsFromStart() => tstart - tElapsed;
    //;//= x => x * x;
    private void UpdateHistory(TimeSpan start)
    {
        tElapsed = start;
        if (hRequest ==null)
        {
            hRequest = new TimeSpan[] { start };
        }
        else {
            int nLen = hRequest.Length + 1;
            var tmpHReq = new TimeSpan[nLen];
            for (int i = 0; i < nLen; i++)
            {
                if (i <= nLen)
                {
                    tmpHReq[i] = hRequest[i];
                }
                else {
                    tmpHReq[i] = tElapsed;
                }
            }//each (TimeSpan item in hRequest)

        }

    }
}