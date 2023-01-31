using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SimpleQuestState : QuestBaseState
{
    public readonly Quest _quest;
    public readonly List<QuestTaskState>    CurrentQuestTask        = new List<QuestTaskState>();
    public readonly List<QuestTrasition>    CurrentTaskTransition   = new List<QuestTrasition>();

    public SimpleQuestState(QuestMaster control,Quest quest) 
        : base(control) {
        _quest = quest;
        foreach (var item in _quest.TaskList)
        {
            CurrentQuestTask.Add(
               new QuestTaskState(control, item)
               );
        }

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