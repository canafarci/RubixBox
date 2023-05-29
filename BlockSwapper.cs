using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwapper : MonoBehaviour
{
    public bool isSwapping = false;
    public Transform TargetTranform;
    private void Update()
    {
        if (TargetTranform == null)
            return;

        if (isSwapping)
        {
            // Smoothly move to new position
            var targetPosition = Vector3.zero;

            targetPosition.x = TargetTranform.position.x;
            targetPosition.y = TargetTranform.position.y;
            targetPosition.z = TargetTranform.position.z;

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 2f);

            if (Mathf.Approximately(Vector3.Distance(transform.position, TargetTranform.position), 0f))
            {
                TargetTranform = null;
                isSwapping = false;
            }
        }
    }
}
