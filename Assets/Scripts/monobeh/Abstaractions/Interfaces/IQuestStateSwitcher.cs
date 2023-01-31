using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IQuestStateSwitcher
{
    void SwitchQuestrState<T>() where T : QuestBaseState;

}
