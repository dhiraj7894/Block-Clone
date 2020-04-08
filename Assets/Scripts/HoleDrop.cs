using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            other.transform.parent.GetComponent<CollectedObjController>().DropDown();
        }
    }
}
