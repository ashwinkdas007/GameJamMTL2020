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
    public List<GameObject> floorList=new List<GameObject>();
    List<GameObject> floorListCurrent;
    List<GameObject> floorListNew = new List<GameObject>();
    public int FloorsInView = 3;
    public float floorHeight;
    Vector3 center;
    float timePass = 0f;
    public float LevelTime = 10f;
    bool isInitialized = false;

    public override void Initialize()
    {
        FloorParent = new GameObject("FloorParent");
        center = new Vector3(0, 0, 0);
        floor = Resources.Load<GameObject>("Prefabs/Floor");
        ViewLevel();
    }

    public override void PostInitialize()
    {

    }


    public override void Refresh(float dt)
    {
        timePass += dt;
        if (timePass >= 10f)
        {
            timePass = 0f;
            ReplaceFloors();
        }
        Debug.Log(timePass);
    }
    public override void FixedRefresh()
    {

    }
    public void FloorsHeightAdjustment()
    {
        floorHeight = floorList[0].transform.GetChild(0).transform.localScale.y;
        for (int i = 0; i < FloorsInView; i++)
        {
            if (i == 0)
            {
                floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, floorHeight + 0.5f, floorList[i].transform.position.z);
            }
            else if (i % 2 != 0)
            {
                floorList[i].transform.position = new Vector3(0, 0, 0);
            }
            else if (i % 2 == 0)
            {
                floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, -(floorHeight + 0.5f), floorList[i].transform.position.z);
            }
        }
        for (int i = FloorsInView; i < (FloorsInView*2)-1; i++)
        {
           
                floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, (floorHeight*i + 0.5f), floorList[i].transform.position.z);           
          
        }
        FloorParent.transform.position = new Vector3(3.457822f, -3.329794f, -9.04807f);
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
    
    public void ViewLevel()
    {
        if (!isInitialized)
        {
            for (int i = 0; i < ((FloorsInView * 2)-1); i++)
            {
                floorList.Add(GameObject.Instantiate(floor, FloorParent.transform));
            }
            FloorsHeightAdjustment();
            isInitialized = true;
        }
        else
        {
            for (int i = 0; i < ((FloorsInView * 2)-1); i++)
            {
                floorList.Add(GameObject.Instantiate(floor, FloorParent.transform));
            }
        }
        
        GetFloorDisaster();
    }
    public void ReplaceFloors()
    {
        floorListCurrent = new List<GameObject>();
        floorListNew = new List<GameObject>();
        
        for (int i = 0; i <= (FloorsInView*2)-1; i++)//assign 123 floors to floorListCurrent and 456 to floorlistnew
        {
            if(i<FloorsInView)
                floorListCurrent[i] = floorList[i];
            else
                floorListNew[i] = floorList[i];
        }

        floorList = null;
        for (int i = 0; i <= (FloorsInView*2)-1; i++)//assign new and current to the actual floor list
        {
            if (i < FloorsInView)
                floorList[i] = floorListNew[i];
            else
                floorList[i] = floorListCurrent[i];
        }
        CameraMove();
        ViewLevel();
    }
    public void CameraMove()
    {
        PlayerManager.Instance.player.getPlayerInput = false;
        float yAxisDifferenceInView = floorList[0].transform.position.y- floorList[FloorsInView].transform.position.y;
       
            for (int i = ((FloorsInView * 2)-1); i >=0 ; i++)//assign new and current to the actual floor list
            {

            // floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, floorList[i].transform.position.y-0.5f,floorList[i].transform.position.z);
            floorList[i].transform.position = Vector3.Lerp(floorList[i].transform.position, new Vector3(floorList[i].transform.position.x, floorList[i].transform.position.y - yAxisDifferenceInView, floorList[i].transform.position.z), (yAxisDifferenceInView-(yAxisDifferenceInView - floorList[i].transform.position.y) / yAxisDifferenceInView));
            }
       
    }
      
    
}


