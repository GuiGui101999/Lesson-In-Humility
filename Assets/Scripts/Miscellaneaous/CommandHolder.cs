using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHolder : MonoBehaviour
{
    public CylinderMovementCommand movementOnXCommand;
    public CylinderMovementOnZCommand movementOnZCommand;

    public void ExecuteMovementOnXCommand()
    {
        if (movementOnXCommand != null)
        {
            movementOnXCommand.Execute();
        }
    }
    public void UndoMovementOnXCommand()
    {
        if (movementOnXCommand != null)
        {
            movementOnXCommand.Undo();
        }
    }

    public void ExecuteMovementOnZCommand()
    {
        if (movementOnZCommand != null)
        {
            movementOnZCommand.Execute();
        }
    }

    public void UndoMovementOnZCommand()
    {
        if (movementOnZCommand != null)
        {
            movementOnZCommand.Undo();
        }
    }
}
