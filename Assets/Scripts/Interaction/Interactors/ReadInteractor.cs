using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteractor : Interactor
{
    [Header("Read Interaction")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactionLayerMask;
    [SerializeField] private float interactionDistance;
    [SerializeField] public GameObject readPrompt;

    private RaycastHit hit;
    private IReadableObjects selection;

    public override void Interact()
    {
        //Cast a ray from middle of camera
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)); //Converts middle point of screen to a ray

        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayerMask)) //out keyword gets information from objects we interact with. It also has 16 method overloads, so 16 different ways to use it.
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);
            selection = hit.collider.GetComponent<IReadableObjects>();  //hit stores information about colliders we hit as well as the transform, and with that, we can get the component of IInteractable.
            if (selection != null) //whatever has IInteractable
            {
                readPrompt.SetActive(true);
                selection.OnHoverEnter(); //calls on the OnHoverEnter method associated with the object with IInteractable
                if (playerInput.readPressed && selection != null) //Once player hovers over selectable, checks if F key is pressed, at which point it will call on the OnRead method associated with object.
                {
                    selection.OnRead();
                }
            }
        }
        else //if ray not in contact with object
        {
            if (selection != null)
            {
                selection.OnHoverExit();
            }
        }

        if (hit.transform == null && selection != null) //if object is still present but player camera is not hovering over it, calls on OnHoverExit methods.
        {
            selection.OnHoverExit();
            selection = null; //You don't have any selected object again.
            readPrompt.SetActive(false);
        }
    }
}
