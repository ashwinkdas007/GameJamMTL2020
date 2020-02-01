using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAlive = true;
    public void Initialize()    { Debug.Log("Player"); }
    public void PostInitialize() {   }
    public void UpdatePlayer(float dt) {     }
    public void FixedUpdatePlayer(float dt) {     }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerDestroy();
    }

    private void PlayerDestroy()
    {
        PlayerManager.Instance.PlayerDied();
        isAlive = false;
    }
}
