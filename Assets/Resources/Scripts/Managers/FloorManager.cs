using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : GenericManager<SampleEntity>
{
    #region
    private static FloorManager instance;

    private FloorManager() : base() { }

    public static FloorManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FloorManager();
            }
            return instance;
        }
    }
    #endregion Singleton

    GameObject floor;
    GameObject FloorParent;
    public List<GameObject> floorList = new List<GameObject>();
    public int NoOfFloorsInView = 3;
    public float floorHeight;
    Vector3 center;
    float lerpActivationCounter = 0f;
    public float lerpActivationTime = 10f;
    bool isInitialized = false;

    float lerpTimer = 0;
    float lerpCooldown = 3;

    int NoOfFloorGroups = 2;

    public override void Initialize()
    {
        FloorParent = new GameObject("FloorParent");
        center = new Vector3(0, 0, 0);
        floor = Resources.Load<GameObject>("Prefabs/Floor");
        InitFloors();
    }

    public override void PostInitialize()
    {

    }

    public override void Refresh(float dt)
    {

        ReplaceFloors(dt);
        //Debug.Log(timePass);
        lerpActivationCounter += dt;
        if(lerpActivationCounter >= lerpActivationTime)
            LerpFloorsDown(dt);
    }
    public override void FixedRefresh()
    {

    }
    
    public void GetFloorDisaster()
    {
        foreach (Transform floor in FloorParent.transform)
        {
            if (Random.value > 0.5f)
            {
                foreach (Transform side in floor)
                {
                    DisasterManager.Instance.getRandomDisaster(side);
                }
            }
            else
            {
                DisasterManager.Instance.getDisplacementDisaster(floor);
            }
        }

    }
    
    void InitFloors()
    {
        if (!isInitialized)
        {
            for (int i = 0; i < (NoOfFloorsInView * NoOfFloorGroups); i++)
            {
                floorList.Add(GameObject.Instantiate(floor, center, Quaternion.identity, FloorParent.transform));
            }
            isInitialized = true;
            InitFloorsHeight();
        }
            
        for (int i = 0; i < floorList.Count; i++)
        {
            floorList[i].transform.name = "Floor" + i;
        }

        //GetFloorDisaster();
    }

    public void InitFloorsHeight()
    {
        floorHeight = floorList[0].transform.GetChild(0).transform.localScale.y;
        floorList[0].transform.position = center;
        for (int i = 1; i < floorList.Count; i++)
        {
            Vector3 pos = floorList[i].transform.position;
            floorList[i].transform.position = new Vector3(pos.x, pos.y + (i * floorHeight) + i, pos.z);
        }
    }
    public void ReplaceFloors(float dt)
    {

        GameObject bottomFloor = floorList[0];
        float teleportHeightOffset = (floorHeight * floorList.Count) + floorList.Count;
        if (bottomFloor.transform.position.y <= -11)
        {
            bottomFloor.transform.position = new Vector3(bottomFloor.transform.position.x, bottomFloor.transform.position.y + teleportHeightOffset, bottomFloor.transform.position.z);
            floorList.RemoveAt(0);
            floorList.Add(bottomFloor);
        }
            
        InitFloors();     
    }

    public void LerpFloorsDown(float dt)
    {
        float distCovered = dt * 0.6f;
        lerpTimer += dt;
        if(lerpTimer <= lerpCooldown)
        {
            PlayerManager.Instance.player.EnablePlayerInput = false;
            Vector3 floorParentPos = FloorParent.transform.position;
            float heightOffset = ((floorHeight * NoOfFloorGroups) + NoOfFloorsInView);
            FloorParent.transform.position = Vector3.Lerp(floorParentPos, new Vector3(floorParentPos.x, floorParentPos.y - heightOffset, floorParentPos.z),  distCovered / heightOffset);
        }
        else
        {
            lerpTimer = 0;
            lerpActivationCounter = 0;
            PlayerManager.Instance.player.EnablePlayerInput = true;
        }
    }
}


