using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    #region Singleton
    private static UIManager instance;
    public UIManager() { }
    public static UIManager Instance { get { if (instance == null) { instance = new UIManager(); } return instance; } }

    #endregion
    Player player;
    public int livesCount = 3;
    public RawImage[] Lives;
    public void Initialize(Player _player)
    {
        player = _player;
    }

    public void PhysicsRefresh()
    {
        
    }

    public void PostInitialize()
    {
        
    }

    public void Refresh(Player _player)
    {
        player = _player;
    }

    public void DecrementLives()
    {
        livesCount--;
        Lives[livesCount].enabled = false;
    }
}

