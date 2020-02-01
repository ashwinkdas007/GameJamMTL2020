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

      //  player = GameObject.FindObjectOfType<PlayerController>();
        //player.transform.localEulerAngles = 
        
        GameObject newPlayer = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        player = newPlayer.GetComponent<PlayerController>();
        player.Initialize();
    }

    public override void PostInitialize()
    {
        player.PostInitialize();
    }

    

    public override void Refresh(float dt)
    {
        //Debug.Log("Refresh");
        if (player.isAlive)
      
            player.Refresh();
    }
    public override void PhysicsRefresh()
    {
        //Debug.Log("Refresh");
        if (player.isAlive)
            player.PhysicsRefresh();
    }
    public void PlayerDied()
    {
        player.gameObject.SetActive(false);
        player.isAlive = false;
        UIManager.Instance.DecrementLives();
        if (UIManager.Instance.livesCount > 0)
        {
            SpawnPlayer();
        }
        else
        {
            Debug.Log("PlayerLost");
        }
    }

    private void SpawnPlayer()
    {
        Initialize();
    }


}

