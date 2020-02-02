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

    
    public int livesCount = 3;
    public RawImage[] Lives=null;

    
 
    public void Initialize()

    {
       
    }

    public void PhysicsRefresh()
    {
        
    }

    public void PostInitialize()
    {
        
    }



    public void Refresh(PlayerController _player)
    {
    }

    public void DecrementLives()
    {
        Lives[livesCount].enabled = false;
        livesCount--;
    }
}

