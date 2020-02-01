using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameFlow : Flow {

	public override void InitializeFlow()
    {
        UIManager.Instance.Initialize(PlayerManager.Instance.player);
    }

    public override void UpdateFlow(float dt)
    {
        PlayerManager.Instance.Update(dt)

    }

    public override void FixedUpdateFlow(float dt)
    {
        PlayerManager.Instance.FixedUpdate(dt)
    }
}
