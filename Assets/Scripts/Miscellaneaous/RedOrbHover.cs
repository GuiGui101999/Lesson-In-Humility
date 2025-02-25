using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOrbHover : MonoBehaviour
{
    public float floatSpeed = 2f;

    [Range(0f, 1f)]
    public float floatDistance = 0.5f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float transformY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        transform.position = new Vector3(startPos.x, transformY, startPos.z);
    }
}
