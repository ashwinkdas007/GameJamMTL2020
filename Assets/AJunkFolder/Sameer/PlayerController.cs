using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Radious = 20f;
    Vector3 center = new Vector3(0, 0, 0);
    public float heightOfEachFloor = 15f;
    public float Camera_top;//= FloorManager.Instance.floorList[2].transform.position.y;
    public float Camera_bottom;// = FloorManager.Instance.floorList[0].transform.position.y;

    ParticleSystem water;
    GameObject hammer;

    [HideInInspector] public bool isAlive;

    Vector3 initialMiddleFloorPos;

    public bool EnablePlayerInput = true;
    public void Initialize()
    {
        initialMiddleFloorPos = FloorManager.Instance.floorList[1].transform.position;
        transform.position = new Vector3(0, initialMiddleFloorPos.y, -Radious);
        Camera_top = initialMiddleFloorPos.y + 3;
        Camera_bottom = initialMiddleFloorPos.y - 3;
        isAlive = true;
        water = Resources.Load<ParticleSystem>("Prefabs/WaterParticles");
        hammer = Resources.Load<GameObject>("Prefabs/Hammer");
    }

    public void Refresh(float dt)
    {
        // Debug.Log("ASDFADF");
        if (EnablePlayerInput)
        {
            PlayerInput(dt);
        }

    }
    public void PostInitialize()
    { 

    }

    public void FixedRefresh()
    {
  
    }


    public void PlayerInput(float dt)
    {
        CrackFix();
        DisplacementFix();
        FireExtunguish();

        if (Input.GetKey(KeyCode.W))
        {
            if (!(transform.position.y >= Camera_top))
                transform.position += Vector3.up * 5 * dt;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!(transform.position.y <= Camera_bottom))
                transform.position -= Vector3.up * 5 * dt;
        }
        if (Input.GetKey(KeyCode.A))
            transform.RotateAround(Vector3.zero, Vector3.up, 5);
        if (Input.GetKey(KeyCode.D))
            transform.RotateAround(Vector3.zero, Vector3.up, -5);
    }

    void FireExtunguish()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.C))
        {
            GameObject waterEffect = Instantiate(water, transform.GetChild(0).transform.position, Quaternion.LookRotation(transform.forward)).gameObject;
            waterEffect.transform.Rotate(new Vector3(0, waterEffect.transform.rotation.y - 90, 0));
            Destroy(waterEffect, 4f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Fire>())
                {
                    Destroy(hit.collider.gameObject.transform.GetComponentInChildren<ParticleSystem>().transform.parent.gameObject, 1f);
                    Destroy(hit.collider.gameObject.GetComponent<Fire>(), 2f);
                }
            }
        }
    }
    void CrackFix()
    {
        
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.X))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hammerObj = Instantiate(hammer, hit.point, transform.rotation); //new Vector3(transform.GetChild(0).transform.position.x, hit.point.y, transform.GetChild(0).transform.position.z)
                hammerObj.transform.position -= .5f * hammerObj.transform.forward;
                hammerObj.transform.Rotate(new Vector3(0, 0, 90)); ;

                Destroy(hammerObj, 2f);

                if (hit.collider.gameObject.GetComponent<Crack>())
                {
                    GameObject crack = hit.collider.gameObject.transform.GetComponentInChildren<SpriteRenderer>().gameObject;
                    Destroy(hit.collider.gameObject.GetComponent<Crack>(), 1.5f);
                    Destroy(crack, 1.5f);
                }
            }
        }
    }

    void DisplacementFix()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Z))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponentInParent<Displacement>())
                {      
                    hit.transform.gameObject.GetComponentInParent<Displacement>().transform.position = Vector3.Lerp(hit.transform.gameObject.GetComponentInParent<Displacement>().transform.position,
                    new Vector3(0, hit.transform.gameObject.GetComponentInParent<Displacement>().transform.position.y, 0), 50f * Time.deltaTime);
                    Destroy(hit.transform.gameObject.GetComponentInParent<Displacement>(), 2f);
                }
            }
        }
    }
}
        

    

    



