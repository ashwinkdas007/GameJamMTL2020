using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DisasterType { Fire,Burglar,Displacement }
public class DisasterManager : GenericManager<SampleEntity>
{
    //public Dictionary<DisasterType, Disaster> disasterPrefabDict = new Dictionary<DisasterType, Disaster>(); //all enemy prefabs
    // Start is called before the first frame update

    #region

    private static DisasterManager instance;

    private DisasterManager() : base() { }
    
    public static DisasterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DisasterManager();
            }
            return instance;
        }
    }
    #endregion

    public int sinceLastFire;
    public int sinceLastCracks;
    public int sinceLastBugs;
    public int sinceLastBurglar;
    public Fire fire;
    public Crack crack;
    public override void Initialize()
    {
        //foreach (DisasterType dtype in System.Enum.GetValues(typeof(DisasterType))) //fill the resource dictionary with all the prefabs
        //{
        //    disasterPrefabDict.Add(dtype, Resources.Load<Disaster>("Scripts/Disaster/" + dtype.ToString())); //Each enum matches the name of the enemy perfectly
        //}

    }
    public void getRandomDisaster(Transform side)
    {
        float randNumber = Random.value;
      
       if( randNumber<=0.25f)
        {
            side.gameObject.AddComponent<Fire>();
            fire = side.GetComponent<Fire>();
            fire.Initialize();

            //if (Random.Range(0f, 1f) <= (FloorManager.Instance.floorNumber / 100)/2f)
            //{
            //    if(Random.Range(0f, 1f) <= (FloorManager.Instance.floorNumber / 100)/4f)
            //    {
            //        fire.Initialize();
            //    }
            //        fire.Initialize();
            //}
        }
        else if (randNumber > 0.25 && randNumber<=0.5)
        {
            side.gameObject.AddComponent<Burglar>();
        }
       else if(randNumber > 0.5 &&randNumber<=0.75)
        {
            side.gameObject.AddComponent<Crack>();
            crack = side.GetComponent<Crack>();
            crack.Initialize();
        } 
        else if(randNumber > 0.75 &&randNumber<=1.0)
        {
            //side.gameObject.AddComponent<Bugs>();
        }

        
    }
    public void getDisplacementDisaster(Transform floor)
    {
        floor.gameObject.AddComponent<Displacement>();
        foreach (Transform side in floor)
        {
            getRandomDisaster(side);
        }
    }
    public override void PostInitialize()
    {

    }


    public override void Refresh(float dt)
    {

    }
    public override void FixedRefresh()
    {

    }
    // Update is called once per frame

}
