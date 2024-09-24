using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovementCommand : CylinderCommand
{
    private CylinderController receiver;
    private Vector3 direction;
    private Vector3 originalPosition;
    public float moveAmount = 0.34f;

    public CylinderMovementCommand(CylinderController receiver, Vector3 direction, float moveAmount)
    {
        this.receiver = receiver;
        this.direction = Vector3.right;
        this.moveAmount = moveAmount;
    }

    public override void Execute()
    {
        originalPosition = receiver.transform.position;
        receiver.Move(direction * moveAmount);
    }

    public override void Undo()
    {
        receiver.Move(direction * moveAmount * -1);
    }
}
