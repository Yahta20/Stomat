using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class QuestTaskState : QuestBaseState
{
    readonly QuestTask _questTask;
    public QuestTaskState(QuestMaster control, QuestTask questTask) : base(control) {
        _questTask = questTask;
    }

    public override void Start()
    {
    }

    public override void Stop()
    {
    }

    public override void Update()
    {
    }
}
