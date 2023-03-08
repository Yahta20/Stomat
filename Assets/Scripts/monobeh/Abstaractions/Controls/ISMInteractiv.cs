/*

 #################
        V   ????
 #################=>????69
 */

using UnityEngine.SceneManagement;
/*
    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        
        if (arg0.name == "Cabinet")
        {
            SwitchPlayerState<MovingState>();
        }
        if (arg0.name == "MainMenu")
        {
            SwitchPlayerState<UIViewState>();
        }
    }

    private void sceneUnloaded(Scene arg0)
    {
        //print($"Unload scene:{arg0.name}");
    }

    private void SceneChanged(Scene arg0, Scene arg1)
    {
        
        
        print($"1 scene:{arg0.name},2 scene:{arg1.name}");
        print(arg0.name);
        print(arg1.name);
    }

 */

namespace KHNMU.Toolkit
{
    public interface ISMInteractiv
    {

        void ActiveSceneChanged             (Scene arg0, Scene arg1);
        void SceneUnloaded                  (Scene arg0);
        void SceneLoaded                    (Scene arg0, LoadSceneMode arg1);
}
}