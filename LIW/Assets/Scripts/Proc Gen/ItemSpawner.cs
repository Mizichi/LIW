using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //Code by Maggie Rembert

    public Transform[] spawnPoints;

    public List<GameObject> itemList;

    public static int itemCount = 0;
    public int itemLimit = 10;
    public int areaVal = 10;

    void Start()
    {
        itemList = new List<GameObject>(Resources.LoadAll<GameObject>("Items"));
        itemCount = 0;

        startInvoke();
    }

    void Update()
    {
        if (itemCount < itemLimit)
            spawn();
    }

    void startInvoke()
    {
        InvokeRepeating("spawn", 0f, 5f);
    }


    void spawn()
    {

        int ranX = Random.Range(-areaVal, areaVal);
        int ranZ = Random.Range(-areaVal, areaVal);
        int ranItem = Random.Range(0, 16); //change value based on amount of health changing items in resourse/items folder

        if (itemCount >= itemLimit) return;

        Instantiate(itemList[ranItem], new Vector3(ranX, 1, ranZ), Quaternion.identity);

        itemCount++;

    }
}
