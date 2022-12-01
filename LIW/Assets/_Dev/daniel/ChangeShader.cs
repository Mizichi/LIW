using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader : MonoBehaviour
{
    public GameObject player;

    range isInRange;

    float minDistance = 7f;

    Shader OutOfRangeShader;
    Shader InRangeShader;


    enum range
    {
        outOfRange,
        inRange,
    }
    private void Awake()
    {
        OutOfRangeShader = Shader.Find("Legacy Shaders/Diffuse");
        InRangeShader = Shader.Find("Unlit/NewUnlitShader");
    }

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
            this.gameObject.GetComponent<Renderer>().materials[1].shader = InRangeShader;
        }
        else
        {
            isInRange = range.outOfRange;
            this.gameObject.GetComponent<Renderer>().materials[1].shader = OutOfRangeShader;
        }
    }
}
