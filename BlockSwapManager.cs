using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwapManager : MonoBehaviour
{
    public Camera ViewCamera;
    public LayerMask blockMask;
    private bool isDragging = false;

    private BlockSwapper blockOne, blockTwo;

    private void Awake()
    {
        blockMask = LayerMask.GetMask("SwappableBlock");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = ViewCamera.ScreenPointToRay(Input.mousePosition);
            //find raycast position on playing board
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, blockMask))
            {
                if (_hit.transform.gameObject.CompareTag("SwappableBlock"))
                {
                    blockOne = _hit.transform.GetComponent<BlockSwapper>();
                }
            }
        }

        if (isDragging)
        {
            RaycastHit _hit;
            Ray _ray = ViewCamera.ScreenPointToRay(Input.mousePosition);
            //find raycast position on playing board
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, blockMask))
            {
                if (_hit.transform.gameObject.CompareTag("SwappableBlock") && _hit.transform.gameObject != this.gameObject)
                {
                    blockTwo = _hit.transform.GetComponent<BlockSwapper>();
                }
                else
                {
                    blockTwo = null;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            blockOne.TargetTranform = blockTwo.transform;
            blockTwo.TargetTranform = blockOne.transform;
            blockOne.isSwapping = true;
            blockTwo.isSwapping = true;
        }

    }
}
