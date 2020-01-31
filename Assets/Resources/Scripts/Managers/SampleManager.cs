using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : GenericManager<SampleEntity>
{
    #region
    private static SampleManager instance;

    private SampleManager() : base() { }

    public static SampleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SampleManager();
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
