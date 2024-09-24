using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CylinderController : MonoBehaviour
{
    public void Move(Vector3 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0f, 0f);
        transform.Translate(movement);
    }
}
