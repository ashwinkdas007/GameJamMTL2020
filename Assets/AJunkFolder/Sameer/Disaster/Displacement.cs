using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displacement : Disaster
{
    [HideInInspector]public Vector3 oldPos;
    public void Awake()
    {
        oldPos = new Vector3();
        Vector3 newPosition = transform.position;
        if(Random.value>0.5f)
        {
            //x
            if (Random.value > 0.5f)
            {
                //-
                newPosition += new Vector3(-Random.Range(0.5f,3f),0,0);
            }
            else
            {
                //+
                newPosition += new Vector3(Random.Range(0.5f, 3f), 0, 0);

            }
            if (Random.value>0.8f)
            {
                //z
                if (Random.value > 0.5f)
                {
                    //-
                    newPosition += new Vector3(0,0,-Random.Range(0.5f, 3f));
                }
                else
                {
                    //+
                    newPosition += new Vector3(0,0,Random.Range(0.5f, 3f));
                }
            }
        }
        else
        {
            //z
            if (Random.value > 0.5f)
            {
                //-
                newPosition += new Vector3(0, 0, -Random.Range(0.5f, 3f));
            }
            else
            {
                //+
                newPosition += new Vector3(0, 0, Random.Range(0.5f, 3f));
            }
            if (Random.value > 0.8f)
            {
                //xif (Random.value > 0.5f)
                if (Random.value > 0.5f)
                {
                    //-
                    newPosition += new Vector3(-Random.Range(0.5f, 3f), 0, 0);
                }
            else
                {
                    //+
                    newPosition += new Vector3(Random.Range(0.5f, 3f), 0, 0);

                }
            }
        }
       oldPos= transform.position;
        transform.position = newPosition;
    }
    public void Refresh()
    {
        
      
    }
    public Vector3 GetOldPos()
    {
        return oldPos;
    }


}
