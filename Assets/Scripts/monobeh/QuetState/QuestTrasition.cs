using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class QuestTrasition : BaseTrasition
{
    private readonly QuestMaster _master;

    public QuestTrasition(SimpleQuestState _from, SimpleQuestState _to, QuestMaster _qm) : base(_from,_to) {
        _master = _qm;
    }

    public void MakeTransition() {
        _from.Stop();
        _to.Start();
    }

}

