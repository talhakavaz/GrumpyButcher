using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    public Transform holdPoint;
    private GameObject heldItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleInteraction();
        }

        if (heldItem != null && holdPoint != null)
            heldItem.transform.position = holdPoint.position;
    }

    void HandleInteraction()
    {
        Vector3 origin = transform.position - Vector3.up;
        Vector3 direction = transform.forward;
        float rayDistance = 0.8f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            // If it's a Cutting Station
            CuttingStation cuttingStation = hit.collider.GetComponent<CuttingStation>();
            if (cuttingStation != null && heldItem != null && heldItem.CompareTag("RawMeat"))
            {
                cuttingStation.StartCutting();
                Destroy(heldItem);  // Remove raw meat
                heldItem = null;
                return;
            }

            // If it's a pickup counter (optional)
            Counter counter = hit.collider.GetComponent<Counter>();
            if (counter != null)
            {
                if (heldItem != null && !counter.HasPatty)
                {
                    counter.PlacePatty(heldItem);
                    heldItem = null;
                    return;
                }
                else if (heldItem == null && counter.HasPatty)
                {
                    heldItem = counter.TakePatty();
                    heldItem.transform.SetParent(holdPoint);
                    heldItem.transform.localPosition = Vector3.zero;
                    return;
                }
            }
        }
    }
}
