using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : GenericManager<Block>
{
    #region
    private static BlockManager instance;

    private BlockManager() : base() { }

    public static BlockManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BlockManager();
            }
            return instance;
        }
    }
    #endregion Singleton

    public override void Initialize()
    {
        base.Initialize();

    }

    public override void UpdateManager(float dt)
    {
        base.UpdateManager(dt);

    }
}
