using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour {

    //This will be called by MainEntryCreator, is entry to program
    public void Start()
    {
        //Cursor.SetCursor(Resources.Load<Texture2D>("cursor"), new Vector2(0, 0), CursorMode.Auto);
        
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
