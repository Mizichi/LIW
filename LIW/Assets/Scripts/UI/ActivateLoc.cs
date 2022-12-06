using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLoc : MonoBehaviour
{
    public void ActivateChildenInHierarchy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.activeInHierarchy == false)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
