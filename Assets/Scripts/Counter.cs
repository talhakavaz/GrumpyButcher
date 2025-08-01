using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject meatPatty;

    public bool HasPatty => meatPatty != null;

    public GameObject TakePatty()
    {
        if (meatPatty == null) return null;

        GameObject taken = meatPatty;
        meatPatty = null;
        return taken;
    }

    public void PlacePatty(GameObject patty)
    {
        meatPatty = patty;
        meatPatty.transform.SetParent(transform);
        meatPatty.transform.localPosition = Vector3.up * 1f; // adjust height
    }
}
