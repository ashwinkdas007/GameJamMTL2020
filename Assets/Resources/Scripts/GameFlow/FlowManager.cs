using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager  {
    public enum SceneNames { MainMenu, MainScene }

    #region Singleton
    private static FlowManager instance;

    private FlowManager() { }

    public static FlowManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FlowManager();
            }
            return instance;
        }
    }
    #endregion

    public SceneNames currentScene;
    Flow currentFlow;
    bool flowInitialized = false;
    

    public void InitializeFlowManager(SceneNames initialScene)
    {

        currentScene = initialScene;
        currentFlow = CreateFlow(initialScene);
        flowInitialized = true;
        currentFlow.InitializeFlow();
        FloorManager.Instance.Initialize();
        PlayerManager.Instance.Initialize();

    }

    public void Refresh(float dt)
    {

        if (currentFlow != null && flowInitialized)
            currentFlow.UpdateFlow(dt);

        FloorManager.Instance.Refresh(dt);
        PlayerManager.Instance.Refresh(dt);

    }

    public void FixedRefresh(float dt)
    {
        if (currentFlow != null && flowInitialized)
            currentFlow.FixedUpdateFlow(dt);

        FloorManager.Instance.FixedRefresh();

    }

    public void ChangeFlows(SceneNames _flowToLoad)
    {
        flowInitialized = false;
        currentFlow.CloseFlow();
        currentFlow = CreateFlow(_flowToLoad);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private Flow CreateFlow(SceneNames _flowToLoad)
    {
        Flow toRet;
        switch (_flowToLoad)
        {
            case SceneNames.MainMenu:
                toRet = new MainMenuFlow();
                break;
            case SceneNames.MainScene:
                toRet = new GameFlow();
                break;
            default:
                toRet = new GameFlow();
                Debug.LogError("Unhandled Switch: " + _flowToLoad.ToString());
                break;
        }
        return toRet;
    }

    public void SceneLoaded(Scene sceneLoaded, LoadSceneMode loadSceneMode)
    {
        //Not used at the moment, but example of an event registered to listen to scene change
        Debug.Log("Scene: " + sceneLoaded.name + " finished loading");
        currentFlow.InitializeFlow();
        flowInitialized = true;
        SceneManager.sceneLoaded -= SceneLoaded; //Clear the event system
        
    }
}
