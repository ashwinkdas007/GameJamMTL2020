using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    GameObject[] walls;
    GameObject[] windowWalls;
    Color clr;
    // Start is called before the first frame update
    void Start()
    {
        clr = Random.ColorHSV();
        walls = GameObject.FindGameObjectsWithTag("Wall");
        windowWalls = GameObject.FindGameObjectsWithTag("WindowSide");

        foreach (GameObject w in walls)
        {
            if (w.transform.parent == transform)
                w.GetComponent<MeshRenderer>().material.color = clr;
        }
        foreach (GameObject wS in windowWalls)
        {
            if (wS.transform.parent.parent == transform)
                wS.GetComponent<MeshRenderer>().material.color = clr;
        }

    }
}
