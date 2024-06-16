using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickInteractor : Interactor
{
    [Header("Pickup Interaction")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private float pickupDistance;
    [SerializeField] private Transform attachTransform;
    [SerializeField] public GameObject pickPrompt;

    private RaycastHit hit;
    private IPick pickable;

    private bool isPicked = false;

    public override void Interact()
    {
        //Cast a ray
        if (Physics.Raycast(GetCamRay(), out hit, pickupDistance, pickupLayerMask))
        {
            pickPrompt.SetActive(true);
            if (playerInput.activatePressed && !isPicked) //if E key is hit and isPicked is false.
            {
                pickable = hit.transform.GetComponent<IPick>();
                if (pickable == null) return;

                pickable.OnPicked(attachTransform);
                isPicked = true;
                return;
            }
        }
        else
        {
            pickPrompt.SetActive(false);
        }

        if (playerInput.activatePressed && isPicked && pickable != null) //Checks to see if e key is pressed, isPicked is true, and pickable which is a reference to interface is not null.
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }
    private Ray GetCamRay()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        return ray; //Check hour into lesson 4
    }
}
