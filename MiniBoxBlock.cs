using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoxBlock : MonoBehaviour
{
    public ColorsOfBlocks ColorOfThisBlock;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void OnEnable()
    {
        MiniBoxesController.OnAllMiniBlocksColorsSet += SetBlockColor;
    }

    private void OnDisable()
    {
        MiniBoxesController.OnAllMiniBlocksColorsSet -= SetBlockColor;
    }

    private void SetBlockColor()
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
}
