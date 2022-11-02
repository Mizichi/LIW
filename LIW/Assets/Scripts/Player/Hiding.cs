using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public Vector3 previousPlayerPosition;
    public Vector3 playerTransform;

    public GameObject player;

    range isInRange;

    float minDistance = 5f;


    enum range
    {
        outOfRange,
        inRange,
        inRangeHiding,
        inRangeOut
    }
    // Start is called before the first frame update
    void Start()
    {
        isInRange = range.outOfRange;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (minDistance > distance)
        {
            isInRange = range.inRange;
        }
        else
        {
            isInRange = range.outOfRange;
        }

        if (isInRange == range.inRange)
        {
            //GetComponent<Material>().color = new Color(0, 200, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                previousPlayerPosition = player.transform.position;
                player.transform.position = this.transform.position;

                isInRange = range.inRange;
            }
        }
        if(isInRange == range.inRange)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                player.transform.position = previousPlayerPosition;
            }
        }

        if (isInRange == range.outOfRange)
        {
            //GetComponent<Material>().color = new Color(255, 255, 255);
        }
    }
    
}
