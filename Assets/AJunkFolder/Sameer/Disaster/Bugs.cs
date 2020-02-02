using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : Disaster
{
    GameObject spiderPrefab;
    static Animator anim;
    Transform floor;
    

    private void Awake()
    {
        spiderPrefab = Resources.Load<GameObject>("Prefabs/Spider");
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        //floor = GetComponent<Floor>().transform;
        
        GameObject.Instantiate(spiderPrefab);

        
    }
    private void Update()
    {
        
    }

}
