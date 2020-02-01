using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour {

    //This will be called by MainEntryCreator, is entry to program
    public void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        FlowManager.Instance.InitializeFlowManager((FlowManager.SceneNames)System.Enum.Parse(typeof(FlowManager.SceneNames), UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));
        
    }
   
    public void Update()
    {
        FlowManager.Instance.Refresh(Time.deltaTime);
    }

    public void FixedUpdate()
    {
        FlowManager.Instance.FixedRefresh(Time.fixedDeltaTime);
    }


}
