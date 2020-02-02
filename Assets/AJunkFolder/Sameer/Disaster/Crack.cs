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
        crackRotate = GameObject.Instantiate(crack, transform.position + (transform.position - transform.parent.parent.position).normalized * 0.25f, Quaternion.identity, gameObject.transform);
        crackRotate.transform.localEulerAngles = Vector3.zero;

        //if (xCoord != 0)
        //    crackRotate.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);         
       
        
        crackRotate.transform.localScale = crackRotate.transform.localScale * 1 / 8;

    }
}
