using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineOrbHover : MonoBehaviour
{
    public float floatSpeed = 2f;

    [Range(0f, 3f)]
    public float floatDistance = 0.5f;

    public float rotationSpeed = 30f;

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

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
