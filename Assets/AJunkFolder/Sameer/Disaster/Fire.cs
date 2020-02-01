using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Disaster
{
    public float xCoord;
    public float yCoord;
    public float zCoord;
    public float parentYCoord;
    GameObject fire;
    Vector3 firePosition;
    public void Initialize()
    {
        xCoord = this.transform.position.x;
        yCoord = this.transform.position.y;
        zCoord = this.transform.position.z;
        parentYCoord = this.transform.parent.position.y;
        fire = Resources.Load<GameObject>("Prefabs/TinyFire");

        spawnFires();
    }


    public void spawnFires()
    {
        //fire.transform.parent = this.gameObject.transform;

        if (xCoord != 0)
        {
            if (xCoord > 0)
                firePosition = new Vector3(xCoord + 0.5f, parentYCoord + Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f));
            else
                firePosition = new Vector3(xCoord - 0.5f, parentYCoord + Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f));
        }
        //else if(yCoord != 0)
        //{
        //    if(yCoord > 0)
        //        firePosition = new Vector3(Random.Range(-3.5f, 3.5f), yCoord + 0.5f, Random.Range(-3.5f, 3.5f));
        //    else
        //        firePosition = new Vector3(Random.Range(-3.5f, 3.5f), yCoord - 0.5f, Random.Range(-3.5f, 3.5f));
        //}
        else if (zCoord != 0)
        {
            if (zCoord > 0)
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), parentYCoord + Random.Range(-3.5f, 3.5f), zCoord + 0.5f);
            else
                firePosition = new Vector3(Random.Range(-3.5f, 3.5f), parentYCoord + Random.Range(-3.5f, 3.5f), zCoord - 0.5f);

        }
        GameObject.Instantiate(fire, firePosition, Quaternion.identity);

    }
}