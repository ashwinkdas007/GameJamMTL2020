using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameFlow : Flow {

	public override void InitializeFlow()
    {
        UIManager.Instance.Initialize(PlayerManager.Instance.player);
        PlayerManager.Instance.Initialize();
    }

    public override void UpdateFlow(float dt)
    {
<<<<<<< Updated upstream
        PlayerManager.Instance.Update(dt);
=======
        PlayerManager.Instance.Refresh();
>>>>>>> Stashed changes
        UIManager.Instance.Refresh(PlayerManager.Instance.player);

    }

    public override void FixedUpdateFlow(float dt)
    {
<<<<<<< Updated upstream
        PlayerManager.Instance.FixedUpdate(dt);
=======
        PlayerManager.Instance.PhysicsRefresh();
>>>>>>> Stashed changes
    }
}
