using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntryCreator : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (!GameObject.FindObjectOfType<MainEntry>())
        {
            GameObject mainFlowObj = new GameObject();
<<<<<<< Updated upstream
            mainFlowObj.AddComponent<MainEntry>().Initialize();
=======
            mainFlowObj.AddComponent<MainEntry>().Start();
>>>>>>> Stashed changes
        }
        GameObject.Destroy(gameObject);
    }

}
