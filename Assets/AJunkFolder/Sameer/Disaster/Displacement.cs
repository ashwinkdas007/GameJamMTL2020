using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displacement : Disaster
{
    [HideInInspector]public Vector3 DisplacementVectorNeeded;
    public void Awake()
    {
        DisplacementVectorNeeded = new Vector3();
        Vector3 newPosition=transform.position;
        if(Random.value>0.5f)
        {
            //x
            if (Random.value > 0.5f)
            {
                //-
                newPosition += new Vector3(-Random.Range(0.5f,5f),0,0);
            }
            else
            {
                //+
                newPosition += new Vector3(Random.Range(0.5f, 5f), 0, 0);

            }
            if (Random.value>0.8f)
            {
                //z
                if (Random.value > 0.5f)
                {
                    //-
                    newPosition += new Vector3(0,0,-Random.Range(0.5f, 5f));
                }
                else
                {
                    //+
                    newPosition += new Vector3(0,0,Random.Range(0.5f, 5f));

                }
            }
        }
        else
        {
            //z
            if (Random.value > 0.5f)
            {
                //-
                newPosition += new Vector3(0, 0, -Random.Range(0.5f, 5f));
            }
            else
            {
                //+
                newPosition += new Vector3(0, 0, Random.Range(0.5f, 5f));
            }
            if (Random.value > 0.8f)
            {
                //xif (Random.value > 0.5f)
                if (Random.value > 0.5f)
                {
                    //-
                    newPosition += new Vector3(-Random.Range(0.5f, 5f), 0, 0);
                }
            else
                {
                    //+
                    newPosition += new Vector3(Random.Range(0.5f, 5f), 0, 0);

                }
            }
        }
        DisplacementVectorNeeded= newPosition- transform.position;
        transform.position = newPosition;
    }
    public void Refresh()
    {
        
      
    }
    public Vector3 GetDisplacementVector()
    {
        return DisplacementVectorNeeded;
    }


}
