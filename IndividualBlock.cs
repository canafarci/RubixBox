using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualBlock : MonoBehaviour
{
    public ColorsOfBlocks ColorOfThisBlock;
    private MeshRenderer meshRenderer;
    public int BlockIndex;

    private void Awake()
    {
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }
    private void OnEnable()
    {
        BlockPositionManager.OnAllBlockColorsSet += SetBlockColor;
    }

    private void OnDisable()
    {
        BlockPositionManager.OnAllBlockColorsSet -= SetBlockColor;
    }

    public void SetBlockColor()
    {
        switch (ColorOfThisBlock)
        {
            case ColorsOfBlocks.Red:
                meshRenderer.material = BlockPositionManager.Instance.RedColor;
                break;
            case ColorsOfBlocks.Blue:
                meshRenderer.material = BlockPositionManager.Instance.BlueColor;
                break;
            case ColorsOfBlocks.Green:
                meshRenderer.material = BlockPositionManager.Instance.GreenColor;
                break;
            case ColorsOfBlocks.Yellow:
                meshRenderer.material = BlockPositionManager.Instance.YellowColor;
                break;
            case ColorsOfBlocks.Orange:
                meshRenderer.material = BlockPositionManager.Instance.OrangeColor;
                break;
            case ColorsOfBlocks.White:
                meshRenderer.material = BlockPositionManager.Instance.WhiteColor;
                break;
            case ColorsOfBlocks.Hollow:
                meshRenderer.material = BlockPositionManager.Instance.HollowColor;
                break;
            default:
                return;
        }
    }
    public void SetBlockColorToHollow()
    {
        meshRenderer.material = BlockPositionManager.Instance.HollowColor;
    }

    public void ConvertToHollow()
    {
        if (ColorOfThisBlock == ColorsOfBlocks.Hollow)
        {
            return;
        }
        else
        {
            meshRenderer.material = BlockPositionManager.Instance.HollowColor;
        }
        
        
    }

    public void RevertToOriginalColor()
    {
        if (ColorOfThisBlock == ColorsOfBlocks.Hollow)
        {
            return;
        }
        else
        {
            SetBlockColor();
        }
        
       
    }
}
