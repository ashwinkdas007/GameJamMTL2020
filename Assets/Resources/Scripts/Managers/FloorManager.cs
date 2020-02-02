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
    public List<Floor> floorList = new List<Floor>();
    public int NoOfFloorsInView = 3;
    public float floorHeight;
    Vector3 center;
    float lerpActivationCounter = 0f;
    public float lerpActivationTime = 15f;
    bool isInitialized = false;
    public int floorNumber = 0;
    float lerpTimer = 0;
    float lerpCooldown = 3;

    int NoOfFloorGroups = 2;

    List<GameObject> ScenePrefabs;
    public override void Initialize()
    {
        FloorParent = new GameObject("FloorParent");
        center = new Vector3(0, 0, 0);
        ScenePrefabs = new List<GameObject>();
        for (int i = 4; i < 7; i++)
        {
            ScenePrefabs.Add(Resources.Load<GameObject>("Prefabs/Floor "+i));
        }
       
        InitFloors();
        
    }

    public override void PostInitialize()
    {

    }

    public override void Refresh(float dt)
    {

        RecycleFloors(dt);
        //Debug.Log(timePass);
        lerpActivationCounter += dt;
        if(lerpActivationCounter >= lerpActivationTime)
            LerpFloorsDown(dt);
    }
    public override void FixedRefresh()
    {

    }
    
    public void GetFloorDisaster(Transform floor)
    {
        if (floor.CompareTag("Floor"))
        {

            foreach (Transform side in floor)
            {
                if (side.CompareTag("Wall"))
                {
                    foreach (Transform d in side)
                    {
                        if (Random.value > 0.5f)
                            DisasterManager.Instance.getRandomDisaster(d);
                    }
                }
                else if (side.CompareTag("WindowSide"))
                {
                    if (Random.value > 0.5f)
                        DisasterManager.Instance.getBurglarDisaster(side);
                }
            }
            
            if (Random.value > 0.7f)
                DisasterManager.Instance.getDisplacementDisaster(floor);
           
        }

    }
    
    void InitFloors()
    {
        if (!isInitialized)
        {
            for (int i = 0; i < (NoOfFloorsInView * NoOfFloorGroups); i++)
            {

                int prefabNum = Random.Range(0, 3);
                floorList.Add(GameObject.Instantiate(ScenePrefabs[prefabNum], center, Quaternion.identity, FloorParent.transform).AddComponent<Floor>());
                
                int RandVal = Random.Range(1,4);               
                floorList[i].transform.rotation = Quaternion.Euler(0, 90*RandVal, 0);
                floorList[i].transform.name = "Floor" + i+1;
                floorList[i].floorNumber = ++floorNumber;
                GetFloorDisaster(floorList[i].transform);
            }
            isInitialized = true;
            InitFloorsHeight(); 
        }
    }

    public void InitFloorsHeight()
    {
        floorHeight = floorList[0].transform.GetChild(0).transform.localScale.y;
        floorList[0].transform.position = center;
        for (int i = 1; i < floorList.Count; i++)
        {
            Vector3 pos = floorList[i].transform.position;

            floorList[i].transform.position = new Vector3(pos.x, pos.y + (i * floorHeight), pos.z);
        }
    }
    public void RecycleFloors(float dt)
    {

        Floor bottomFloor = floorList[0];
        float teleportHeightOffset = (floorHeight * floorList.Count);

        if (bottomFloor.transform.position.y <= -11)
        {
            if (bottomFloor.disasterCount <= 0)
                PlayerManager.Instance.player.scoreCount++;
            else
                PlayerManager.Instance.player.life--;
            
            Disaster d;
            if(bottomFloor.TryGetComponent<Disaster>(out d))
                GameObject.Destroy(d);           
                
            for (int i = 0; i < bottomFloor.transform.childCount; i++)
            {
                if (bottomFloor.transform.GetChild(i).TryGetComponent<Disaster>(out d))
                    GameObject.Destroy(d);
            }

            bottomFloor.disasterCount = 0;
            bottomFloor.transform.position = new Vector3(bottomFloor.transform.position.x, bottomFloor.transform.position.y + teleportHeightOffset, bottomFloor.transform.position.z);
            floorList.RemoveAt(0);
            floorList.Add(bottomFloor);
            bottomFloor.floorNumber = ++floorNumber;
            bottomFloor.transform.name = "Floor" + bottomFloor.floorNumber;
            GetFloorDisaster(bottomFloor.transform);
        }     
    }

    public void LerpFloorsDown(float dt)
    {
        float distCovered = dt * 5.3f;
        lerpTimer += dt;
        if(lerpTimer <= lerpCooldown)
        {
            PlayerManager.Instance.player.EnablePlayerInput = false;
            Vector3 floorParentPos = FloorParent.transform.position;
            float heightOffset = ((floorHeight * NoOfFloorGroups));
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


