using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    #region Singleton
    private static UIManager instance;
    public UIManager() { }
    public static UIManager Instance { get { if (instance == null) { instance = new UIManager(); } return instance; } }

    #endregion
    Player player;
    public int livesCount = 3;
    public RawImage[] Lives;
    public void Initialize(Player player)
    {

    }

    public void PhysicsRefresh()
    {
        
    }

    public void PostInitialize()
    {
        
    }

    public void Refresh()
    {
       
    }

    public void DecrementLives()
    {
        livesCount--;
        Lives[livesCount].enabled = false;
    }
}

