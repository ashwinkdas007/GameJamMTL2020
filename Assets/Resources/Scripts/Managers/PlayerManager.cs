using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : GenericManager<SampleEntity>
{
    #region
    private static PlayerManager instance;

    private PlayerManager() : base() { }

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    #endregion Singleton

    public PlayerController player;
    public Vector3 pos;

    public override void Initialize()
    {

        player = GameObject.FindObjectOfType<PlayerController>();
        //player.transform.localEulerAngles = 
        player.Initialize();  //isAlive = true
    }

    public override void PostInitialize()
    {
        player.PostInitialize();
    }

    

    public override void Refresh()
    {
        //Debug.Log("Refresh");
        if (player.isAlive)
            player.Refresh();
    }

    
}

