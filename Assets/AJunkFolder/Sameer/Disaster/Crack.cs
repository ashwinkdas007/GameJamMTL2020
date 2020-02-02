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
    GameObject crackRotate;
    public void Initialize()
    {
        xCoord = gameObject.transform.position.x;
        yCoord = gameObject.transform.position.y;
        zCoord = gameObject.transform.position.z;
        parentYCoord = gameObject.transform.parent.position.y;
        crack = Resources.Load<GameObject>("Prefabs/Crack");

        spawnCracks();
    }


    public void spawnCracks()
    {
        //fire.transform.parent = this.gameObject.transform;

        if (xCoord != 0)
        {
            if (xCoord > 0)
            {
                //crack.transform.Rotate(0, 90, 0, Space.Self);
                //crack
                //crack.transform.RotateAround(crack.transform.position, transform.up, 90);
                crackPosition = new Vector3(xCoord + 0.51f, parentYCoord + Random.Range(-1.8f, 1.8f), Random.Range(-1.8f, 1.8f));
            }
            else
            {
                //crack.transform.Rotate(0, 90, 0, Space.Self);
                //crack.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                //crack.transform.RotateAround(crack.transform.position, transform.up, 90);
                crackPosition = new Vector3(xCoord - 0.51f, parentYCoord + Random.Range(-1.8f, 1.8f), Random.Range(-1.8f, 1.8f));
            }
            crackRotate = GameObject.Instantiate(crack, crackPosition, Quaternion.identity, gameObject.transform);
            crackRotate.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            //crackRotate.transform.localScale = new Vector3(crackRotate.transform.localScale.x * 1/8, crackRotate.transform.localScale.y, crackRotate.transform.localScale.z);
            crackRotate.transform.localScale = crackRotate.transform.localScale * 1 / 8;
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
                crackPosition = new Vector3(Random.Range(-1.8f, 1.8f), parentYCoord + Random.Range(-1.8f, 1.8f), zCoord + 0.51f);
            else
                crackPosition = new Vector3(Random.Range(-1.8f, 1.8f), parentYCoord + Random.Range(-1.8f, 1.8f), zCoord - 0.51f);

            crackRotate = GameObject.Instantiate(crack, crackPosition, Quaternion.identity, gameObject.transform);
            crackRotate.transform.localScale = crackRotate.transform.localScale * 1 / 8;
        }
        

    }
}
