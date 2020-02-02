using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : Disaster
{
    GameObject spiderPrefab;
    Transform floor;
    float offset;
    Vector3 offsetPos = new Vector3(0,0,-4.62f);
    Vector3 offsetRot = new Vector3(-90f, 0, 0);
    Vector3 movement = Vector3.one;
    float speed = 1f;
    

    private void Awake()
    {
        spiderPrefab = Resources.Load<GameObject>("Prefabs/Spider");



    }
    private void Start()
    {
         //floor = FindObjectOfType<Floor>().transform;
        GameObject.Instantiate(spiderPrefab,new Vector3(0,0,0),transform.rotation*Quaternion.Euler(offsetRot));



        
    }
    private void Update()
    {
        transform.position += movement*speed*Time.deltaTime;
    }

}
