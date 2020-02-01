using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Radious = 20f;
    Vector3 center = new Vector3(0, 0, 0);
    public float heightOfEachFloor = 15f;
    public float Camera_top = 0f;
    public float Camera_bottom = -11f;
    [HideInInspector] public bool isAlive;
    public bool getPlayerInput = true;
    public void Initialize()
    {
        //Debug.Log("ASDFADF");
        GameObject.FindGameObjectWithTag("MainCamera").transform.position=new Vector3(0, FloorManager.Instance.floorList[0].transform.position.y, -Radious);
        isAlive = true;
    }

    // Update is called once per frame
    public void Refresh()
    {
        // Debug.Log("ASDFADF");
        if (getPlayerInput)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (!(transform.position.y >= Camera_top))
                    transform.position += Vector3.up * 0.04f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (!(transform.position.y <= Camera_bottom))
                    transform.position -= Vector3.up * 0.04f;
            }
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(0, -1, 0);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(0, 1, 0);
        }
    }
    public void PostInitialize()
    { 

    }

    public void PhysicsRefresh()
    { 
    }


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

