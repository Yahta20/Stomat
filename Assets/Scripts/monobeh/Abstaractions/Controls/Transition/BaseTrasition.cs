using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class BaseTrasition
{
    protected readonly StateBase _from;
    protected StateBase _to;

    protected BaseTrasition(StateBase from, StateBase to) {
        _from = from;
        _to = to;
    } 
}


