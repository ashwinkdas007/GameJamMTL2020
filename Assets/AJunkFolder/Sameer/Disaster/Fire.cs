using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Disaster
{
    public float xCoord;
    public float yCoord;
    public float zCoord;
    GameObject fire;
    Vector3 firePosition;
    public void Initialize()
    {
        xCoord = gameObject.transform.position.x;
        yCoord = gameObject.transform.position.y;
        zCoord = gameObject.transform.position.z;

        fire = Resources.Load<GameObject>("Prefabs/TinyFire");

        if (xCoord != 0)
        {
            if (xCoord > 0)
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), xCoord + 0.5f, Random.Range(-3.75f, 3.75f));
            else
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), xCoord - 0.5f, Random.Range(-3.75f, 3.75f));
           // GameObject.Instantiate(fire, firePosition, Quaternion.identity);
        }
        else if(yCoord != 0)
        {
            if(yCoord > 0)
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), yCoord + 0.5f, Random.Range(-3.75f, 3.75f));
            else
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), yCoord - 0.5f, Random.Range(-3.75f, 3.75f));

        }

    }
}