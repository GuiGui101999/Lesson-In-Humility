using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInitializer : MonoBehaviour
{
    public CylinderController cylinderController;

    private void Start()
    {
        CommandHolder commandHolder = GetComponent<CommandHolder>();

        if (cylinderController != null && commandHolder != null)
        {
            commandHolder.movementCommand = new CylinderMovementCommand(cylinderController, Vector3.right, commandHolder.movementCommand.moveAmount);
        }
    }
}
