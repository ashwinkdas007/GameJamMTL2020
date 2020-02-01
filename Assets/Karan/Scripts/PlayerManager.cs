using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {
    #region Singleton
    private static PlayerManager instance;
    public PlayerManager() { }
    public static PlayerManager Instance { get { if (instance == null) { instance = new PlayerManager(); } return instance; } }
    #endregion
   public Player player;
   
    public void Initialize()
    {
        GameObject newPlayer = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/player"));
        player.Initialize();
        
    }
    public void Update(float dt)
    {
        if (player)
            player.UpdatePlayer(dt);
    }

    public void FixedUpdate(float dt)
    {
        if (player)
            player.FixedUpdatePlayer(dt);
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
