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
    [HideInInspector] public bool isAlive;

    public bool EnablePlayerInput = true;
    public void Initialize()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position=new Vector3(0, FloorManager.Instance.floorList[1].transform.position.y, -Radious);
        Camera_top = FloorManager.Instance.floorList[1].transform.position.y+9;
        Camera_bottom = FloorManager.Instance.floorList[1].transform.position.y-9;
        isAlive = true;
    }

    public void Refresh()
    {
        // Debug.Log("ASDFADF");
        if (EnablePlayerInput)
        {
            PlayerInput();
        }

    }
    public void PostInitialize()
    { 

    }

    public void FixedRefresh()
    {
  
    }


    public void PlayerInput()
    {
        CrackFix();
        DisplacementFix();

        if (Input.GetKey(KeyCode.W))
        {
            if (!(transform.position.y >= Camera_top))
                transform.position += Vector3.up * 0.04f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!(transform.position.y <= Camera_bottom))
                transform.position -= Vector3.up * 0.04f;
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -1, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 1, 0);
    }

    void CrackFix()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.X))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Crack>())
                {
                    GameObject crack = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    Destroy(hit.collider.gameObject.GetComponent<Crack>());
                    Destroy(crack);
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
        

    

    



