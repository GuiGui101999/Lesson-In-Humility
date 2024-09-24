using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHolder : MonoBehaviour
{
    public CylinderMovementCommand movementCommand;

    public void ExecuteMovementCommand()
    {
        if (movementCommand != null)
        {
            movementCommand.Execute();
        }
    }
    public void UndoMovementCommand()
    {
        if (movementCommand != null)
        {
            movementCommand.Undo();
        }
    }
}
