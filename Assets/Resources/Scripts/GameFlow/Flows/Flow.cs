using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow  {


	public virtual void InitializeFlow()
    {
        Debug.Log("Flow");
        PlayerManager.Instance.Initialize();
    }

    public virtual void UpdateFlow(float dt)
    {
        PlayerManager.Instance.Refresh(dt);

    }

    public virtual void FixedUpdateFlow(float dt)
    {
        
    }

    public virtual void CloseFlow()
    {

    }
}
