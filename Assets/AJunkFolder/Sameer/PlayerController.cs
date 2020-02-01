using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Radious = 10f;
    Vector3 center = new Vector3(0, 0, 0);
    public float heightOfEachFloor = 10f;
    [HideInInspector] public bool isAlive;
    public void Initialize()
    {
        //Debug.Log("ASDFADF");
        GameObject.FindGameObjectWithTag("MainCamera").transform.position=new Vector3(0,0,-Radious);
        isAlive = true;
    }

    // Update is called once per frame
    public void Refresh()
    {
       // Debug.Log("ASDFADF");
        if (Input.GetKey(KeyCode.W))
        {
            if(!(transform.position.y>=((heightOfEachFloor*3)/2)))
                transform.position += Vector3.up * 0.04f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!(transform.position.y <= (-(heightOfEachFloor * 3) / 2)))
                transform.position -= Vector3.up * 0.04f;
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -1, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 1, 0);
    }
    public void PostInitialize()
    { 

    }

    public void PhysicsRefresh()
    { 
    }

    }
