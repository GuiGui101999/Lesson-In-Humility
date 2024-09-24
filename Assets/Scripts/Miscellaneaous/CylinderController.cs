using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CylinderController : MonoBehaviour
{
    public void MoveOnX(Vector3 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0f, 0f);
        transform.Translate(movement);
    }

    public void MoveOnZ(Vector3 direction)
    {
        Vector3 movement = new Vector3(0f, 0f, direction.z);
        transform.Translate(movement);
    }
}
