using System;

[Serializable]
public class TaskTrasition : BaseTrasition
{
    private readonly QuestTrasition _master;

    public TaskTrasition(SimpleQuestState _from, SimpleQuestState _to, QuestTrasition _qm) : base(_from, _to)
    {
        _master = _qm;
    }

    public void MakeTransition()
    {
        _from.Stop();
        _to.Start();
    }
}
