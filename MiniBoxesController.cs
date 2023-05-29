using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoxesController : MonoBehaviour
{
    public List<ColorsOfBlocks> WinColorsList = new List<ColorsOfBlocks>();
    List<int> MiniIndexList = new List<int>();
    public static event System.Action OnAllMiniBlocksColorsSet = delegate { };

    int redCount, blueCount, greenCount, orangeCount, yellowCount, whiteCount = 0;

    public int maxSameColors;

    // Start is called before the first frame update
    void Start()
    {
        maxSameColors = Random.Range(3, 5);
        SetInitialBoxColors();
        
    }

    private void SetInitialBoxColors()
    {
        for (int i = 0; i < 9; i++)
        {
            MiniIndexList.Add(i);
        }

        int j = 0;
        while (j < 9)
        {
            RandomSetBoxColors(j);
            j++;
        }
        OnAllMiniBlocksColorsSet();

        for (int i = 0; i < 9; i++)
        {
            WinColorsList.Add(transform.GetChild(i).GetComponent<MiniBoxBlock>().ColorOfThisBlock);
        }
    }

    private void RandomSetBoxColors(int j)
    {
        int _index = Random.Range(0, 6);
        if (_index == 0)
        {
            if (redCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.Red;
                redCount++;
            }
            else
            {
                _index++;
            }
        }

        if (_index == 1)
        {
            if (blueCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.Blue;
                blueCount++;
            }
            else
            {
                _index++;
            }
        }

        if (_index == 2)
        {
            if (greenCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.Green;
                greenCount++;
            }
            else
            {
                _index++;
            }
        }

        if (_index == 3)
        {
            if (orangeCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.Orange;
                orangeCount++;
            }
            else
            {
                _index++;
            }
        }

        if (_index == 4)
        {
            if (yellowCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.Yellow;
                yellowCount++;
            }
            else
            {
                _index++;
            }
        }

        if (_index == 5)
        {
            if (whiteCount < maxSameColors)
            {
                transform.GetChild(j).GetComponent<MiniBoxBlock>().ColorOfThisBlock = ColorsOfBlocks.White;
                whiteCount++;
            }
            else
            {
                RandomSetBoxColors(j);
            }
        }
    }
}
