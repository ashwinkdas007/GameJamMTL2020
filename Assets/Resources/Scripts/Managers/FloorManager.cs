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
    public int floorNumber = 100;

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
        if (timePass >= LevelTime)
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
        floorList[0].transform.position = new Vector3(0,0,0);      
        for (int i = 1; i < FloorsInView*2; i++)
        {
            if(i<FloorsInView)
                floorList[i].transform.position = new Vector3(floorList[0].transform.position.x, floorList[i-1].transform.position.y- floorHeight-1, floorList[0].transform.position.z);    
            else
                floorList[i].transform.position = new Vector3(floorList[0].transform.position.x, floorList[i - FloorsInView].transform.position.y + ((FloorsInView) *(floorHeight + 1)), floorList[0].transform.position.z);               
        }

        //{
        //    if (i == 0)
        //    {
        //        floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, floorHeight + 0.5f, floorList[i].transform.position.z);
        //    }
        //    else if (i % 2 != 0)
        //    {
        //        floorList[i].transform.position = new Vector3(0, 0, 0);
        //    }
        //    else if (i % 2 == 0)
        //    {
        //        floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, -(floorHeight + 0.5f), floorList[i].transform.position.z);
        //    }
        ////}
        //for (int i = FloorsInView; i <= (FloorsInView*2)-1; i++)
        //{

        //    if (i % 2 != 0)
        //    {
        //        floorList[i].transform.position = new Vector3(0, 0, 0);
        //    }
        //    else if (i % 2 == 0)
        //    {
        //        floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, -(floorHeight + 0.5f), floorList[i].transform.position.z);
        //    }
        //   // floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, (floorHeight*i + 0.5f), floorList[i].transform.position.z);           
          
        //}
        //FloorParent.transform.position = new Vector3(3.457822f, -3.329794f, -9.04807f);
    }
    public void GetFloorDisaster()
    {
        foreach (Transform floor in FloorParent.transform)
        {
            //if (Random.value > 0.5f)
            //{
                foreach (Transform side in floor)
                {
                    DisasterManager.Instance.getRandomDisaster(side);
                }
           // }
            //else
            //{
            //   // DisasterManager.Instance.getDisplacementDisaster(floor);
            //}
        }

    }
    
    public void ViewLevel()
    {
        
        if (!isInitialized)
        {
            for (int i = 0; i <= ((FloorsInView * 2)-1); i++)
            {
                floorList.Add(GameObject.Instantiate(floor, FloorParent.transform));
                floorList[i].transform.name = "Floor" + i;
                floorList[i].transform.position = center;
                floorNumber++; //counter for floor
            }
            FloorsHeightAdjustment();
            isInitialized = true;
        }
        else
        {
            for (int i = 0; i <= ((FloorsInView * 2)-1); i++)
            {

            }
        }
        
        GetFloorDisaster();
    }
    public void ReplaceFloors()
    {
        floorListCurrent = new List<GameObject>();
        floorListNew = new List<GameObject>();
        
        for (int i = 0; i < (FloorsInView*2); i++)//assign 123 floors to floorListCurrent and 456 to floorlistnew
        {

            if (i < FloorsInView)
            {
                floorListCurrent.Add(floorList[i]);
            }
            else
            {
                floorListNew.Add(floorList[i]);
            }
        }

        floorList = new List<GameObject>();
        for (int i = 0; i < (FloorsInView * 2); i++)//assign 123 floors to floorListCurrent and 456 to floorlistnew
        {
            if (i < FloorsInView)
            { 

            }
        }
        floorList = new List<GameObject>();
        for (int i = 0; i < floorListNew.Count; i++)//assign new and current to the actual floor list
        {
            if (i < FloorsInView)
                floorList.Add(floorListNew[i]);
        }
        for (int i = 0; i < floorListCurrent.Count; i++)//assign new and current to the actual floor list
        {
            floorList.Add(floorListCurrent[i]);
        }


        CameraMove();
        ViewLevel();
    }
    public void CameraMove()
    {
        PlayerManager.Instance.player.getPlayerInput = false;
        float yAxisDifferenceInView = floorList[0].transform.position.y- floorList[(FloorsInView*2)-1].transform.position.y;

       
        for (int i = ((FloorsInView * 2) - 1); i >=0 ; i--)
        {
             floorList[i].transform.position = Vector3.Lerp(floorList[i].transform.position, new Vector3(floorList[i].transform.position.x, floorList[i].transform.position.y - yAxisDifferenceInView, floorList[i].transform.position.z), (yAxisDifferenceInView-(yAxisDifferenceInView - floorList[i].transform.position.y) / yAxisDifferenceInView));
        }
        for (int i = FloorsInView; i < FloorsInView * 2; i++)
        {

            // floorList[i].transform.position = new Vector3(floorList[i].transform.position.x, floorList[i].transform.position.y-0.5f,floorList[i].transform.position.z);
            floorList[i].transform.position = Vector3.Lerp(floorList[i].transform.position, new Vector3(floorList[i].transform.position.x, floorList[i].transform.position.y + (2 * yAxisDifferenceInView), floorList[i].transform.position.z), (yAxisDifferenceInView - (yAxisDifferenceInView - floorList[i].transform.position.y) / yAxisDifferenceInView));
        }
        PlayerManager.Instance.player.getPlayerInput = true;

    }
      
    
}


