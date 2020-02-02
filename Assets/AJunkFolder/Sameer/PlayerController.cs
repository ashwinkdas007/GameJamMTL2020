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
    public bool EnablePlayerInput { get; set; }
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



        //For Displacement
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Z))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponentInParent<Displacement>() != null)
                {
                    if (hit.transform.parent.position != hit.transform.gameObject.GetComponentInParent<Displacement>().GetOldPos())
                         
                    hit.transform.parent.position = Vector3.Lerp(hit.transform.gameObject.GetComponentInParent<Displacement>().GetOldPos(), hit.transform.parent.position, 50f * Time.deltaTime);
                }
            }
        }
        //Debug.Log(" hit.transform.position IN BEGINING" + hit.transform.position+"Hit NAme"+hit.transform.name);

        //Transform temp = hit.transform;
        // while (!temp.CompareTag("Floor"))
        // {
        //     temp = temp.parent.transform;

        // }
        // if (temp.GetComponent<Displacement>() != null)
        // {
        //     Debug.Log(" hit.transform.position" + hit.transform.position + "Hit NAme" + hit.transform.name);
        //     Debug.Log(temp.position + "    " + temp.name);

        //     Vector3 dirToPush = (temp.position - hit.collider.transform.position).normalized;
        //     Debug.Log(dirToPush);
        //     Rigidbody rb = temp.GetComponent<Rigidbody>();
        //     if(Vector3.SqrMagnitude( hit.transform.GetComponent<Displacement>().GetOldPos()- hit.collider.transform.position)<5)
        //     {
        //         rb.AddForce(dirToPush*2f, ForceMode.Force);                            
        //     }

        // }
    }
}
        

    

    



