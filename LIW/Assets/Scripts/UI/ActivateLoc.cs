using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLoc : MonoBehaviour
{
    public void LocalizationActivate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
