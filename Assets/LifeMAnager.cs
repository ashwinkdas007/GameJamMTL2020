using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {        
        switch (PlayerManager.Instance.player.life)
        {
            case 1:
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case 2:
                {
                    transform.GetChild(2).gameObject.SetActive(false);
                }
                break;
            case 3:
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(true);
                }
                break;
        }
    }
}
