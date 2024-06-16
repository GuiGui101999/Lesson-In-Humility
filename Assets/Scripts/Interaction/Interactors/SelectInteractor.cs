using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SelectInteractor : Interactor
{
    [Header("Select Interaction")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactionLayerMask;
    [SerializeField] private float interactionDistance;
    [SerializeField] public GameObject selectPrompt;

    private RaycastHit hit;
    private ISelect selection;

    public override void Interact()
    {
        //Cast a ray from middle of camera
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)); //Converts middle point of screen to a ray

        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayerMask)) //out keyword gets information from objects we interact with. It also has 16 method overloads, so 16 different ways to use it.
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);
            selection = hit.transform.GetComponent<ISelect>();  //hit stores information about colliders we hit as well as the transform, and with that, we can get the component of ISelectable.
            if (selection != null) //whatever has ISelectable
            {
                selectPrompt.SetActive(true);
                selection.OnHoverEnter(); //calls on the OnHoverEnter method associated with the object with ISelectable
                if (playerInput.activatePressed && selection != null) //Once player hovers over selectable, checks if E key is pressed, at which point it will call on the OnSelect method associated with object.
                {
                    selection.OnSelect();
                }
            }
        }

        if (hit.transform == null && selection != null) //if object is still present but player camera is not hovering over it, calls on OnHoverExit methods.
        {
            selection.OnHoverExit();
            selection = null; //You don't have any selected object again.
            selectPrompt.SetActive(false);
        }
    }
}
