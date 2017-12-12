using UnityEngine;
using System.Collections;

public class Gold : Resource 
{
    Gold()
    {
        mDescription = "Gold";
    }

    void Awake()
    {
        /*for (int i = 0; i < 3; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }*/
    }
}
