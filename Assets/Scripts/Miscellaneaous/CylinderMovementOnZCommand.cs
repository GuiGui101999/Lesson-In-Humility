using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovementOnZCommand : CylinderCommand
{
    private CylinderController receiver;
    private Vector3 direction;
    private Vector3 originalPosition;

    public CylinderMovementOnZCommand(CylinderController receiver, Vector3 direction)
    {
        this.receiver = receiver;
        this.direction = Vector3.forward;
    }

    public override void Execute()
    {
        originalPosition = receiver.transform.position;
        receiver.MoveOnZ(direction);
    }

    public override void Undo()
    {
        receiver.MoveOnZ(direction * -1);
    }
}
