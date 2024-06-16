using UnityEngine;

public interface IPick //interface does not inherit.
{
    public void OnPicked(Transform attachTransform);
    public void OnDropped();
}
