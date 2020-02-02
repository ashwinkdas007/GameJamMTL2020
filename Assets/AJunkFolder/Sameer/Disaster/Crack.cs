using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : Disaster
{
    public float xCoord;
    public float yCoord;
    public float zCoord;
    public float parentYCoord;
    GameObject crack;
    Vector3 crackPosition;
    public void Initialize()
    {
        xCoord = this.transform.position.x;
        yCoord = this.transform.position.y;
        zCoord = this.transform.position.z;
        parentYCoord = this.transform.parent.position.y;
        crack = Resources.Load<GameObject>("Prefabs/Crack");

       // spawnCracks();
    }


    public void spawnCracks()
    {
        //fire.transform.parent = this.gameObject.transform;

        if (xCoord != 0)
        {
            if (xCoord > 0)
            {
                //crack.transform.Rotate(0, 90, 0, Space.Self);
                crack.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y * 90, transform.rotation.z);
                //crack.transform.RotateAround(crack.transform.position, transform.up, 90);
                crackPosition = new Vector3(xCoord + 0.01f, parentYCoord + Random.Range(-1.8f, 1.8f), Random.Range(-1.8f, 1.8f));
            }
            else
            {
                //crack.transform.Rotate(0, 90, 0, Space.Self);
                crack.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y * 90, transform.rotation.z);
                //crack.transform.RotateAround(crack.transform.position, transform.up, 90);
                crackPosition = new Vector3(xCoord - 0.01f, parentYCoord + Random.Range(-1.8f, 1.8f), Random.Range(-1.8f, 1.8f));
            }
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
                crackPosition = new Vector3(Random.Range(-1.8f, 1.8f), parentYCoord + Random.Range(-1.8f, 1.8f), zCoord + 0.01f);
            else
                crackPosition = new Vector3(Random.Range(-1.8f, 1.8f), parentYCoord + Random.Range(-1.8f, 1.8f), zCoord - 0.01f);

        }
        GameObject.Instantiate(crack, crackPosition, Quaternion.identity, this.transform.parent);

    }
}
