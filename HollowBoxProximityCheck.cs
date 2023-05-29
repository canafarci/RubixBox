using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class HollowBoxProximityCheck : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        boxCollider.isTrigger = true;
        Vector3 _boxTriggerSize = boxCollider.size;
        boxCollider.size = Vector3.Scale(new Vector3(1f, 1.35f, 0.01f) , _boxTriggerSize);
        BoxCollider _boxCollider = gameObject.AddComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        _boxCollider.size =  Vector3.Scale(new Vector3(1f, 0.01f, 1.35f) , _boxTriggerSize); ;
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("BoxChild"))
        {
            other.transform.parent.transform.GetComponent<LeanSelectableBlock>().isSwappable = true;
            
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("BoxChild"))
        {
            other.transform.parent.transform.GetComponent<LeanSelectableBlock>().isSwappable = false;
        }
    }

    IEnumerator DisableLeanTouch(Collider other)
    {
        yield return new WaitForSeconds(0.4f);
        other.transform.parent.transform.GetComponent<LeanSelectableBlock>().enabled = false;
    }
}
