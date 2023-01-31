using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public abstract class QuestBaseState :StateBase
    {
    protected readonly QuestMaster _master;
    protected readonly IQuestStateSwitcher _stateSwith;
    protected QuestBaseState(QuestMaster control, IQuestStateSwitcher ss)
    {
        control = _master;
        ss = _stateSwith;
    }
    
    
 
    /*
    SLEEP,
    ACTIVE,
    DONE
     */



}
