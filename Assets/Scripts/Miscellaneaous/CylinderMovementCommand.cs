using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovementCommand : CylinderCommand
{
    private CylinderController receiver;
    private Vector3 direction;
    private Vector3 originalPosition;

    public CylinderMovementCommand(CylinderController receiver, Vector3 direction)
    {
        this.receiver = receiver;
        this.direction = Vector3.right;
    }

    public override void Execute()
    {
        originalPosition = receiver.transform.position;
        receiver.MoveOnX(direction);
    }

    public override void Undo()
    {
        receiver.MoveOnX(direction * -1);
    }
}
