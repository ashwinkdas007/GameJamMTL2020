using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burglar : Disaster
{
    Transform burglarSpawnLocation;

    public void Initialize()
    {
        if(transform.CompareTag("WindowSide"))
        {
            Transform spawnLocation = transform.GetComponent<WindowSideScript>().BurglarLocations[Random.Range(0, transform.GetComponent<WindowSideScript>().BurglarLocations.Length)];
            GameObject go = Resources.Load<GameObject>("Prefabs/Bandit");
            Instantiate(go, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
