using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class BlockPositionManager : MonoBehaviour
{
    public static BlockPositionManager Instance;
    List<ColorsOfBlocks> MasterColorList = new List<ColorsOfBlocks>();
    List<int> IndexList = new List<int>();
    List<int> HollowIndexList = new List<int>();
    List<ColorsOfBlocks> WinColorsList = new List<ColorsOfBlocks>();
    public static event System.Action OnAllBlockColorsSet = delegate { };

    public Material RedColor, BlueColor, GreenColor, YellowColor, OrangeColor, WhiteColor, HollowColor;
    private AudioSource audioSource;

    private int calledIndex = 0;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        MiniBoxesController.OnAllMiniBlocksColorsSet += SetWinList;
    }
    private void OnDisable()
    {
        MiniBoxesController.OnAllMiniBlocksColorsSet -= SetWinList;
    }

    private void Start()
    {
        RandomSetInitialColors();
        SetHollowIndexesList();
    }

    public void SwitchListIndexes(IndividualBlock __blockOne, IndividualBlock __blockTwo)
    {
        int _indexOne = __blockOne.BlockIndex;
        int _indexTwo = __blockTwo.BlockIndex;

        ColorsOfBlocks _blockOneColor = __blockOne.ColorOfThisBlock;
        ColorsOfBlocks _blockTwoColor = __blockTwo.ColorOfThisBlock;
    
        __blockOne.BlockIndex = _indexTwo;
        __blockTwo.BlockIndex = _indexOne;

        MasterColorList[_indexOne] = _blockTwoColor;
        MasterColorList[_indexTwo] = _blockOneColor;

        calledIndex++;
    }

    public void PlayBoxSwitchAudio()
    {
        audioSource.Play();
    }
    private void RandomSetInitialColors()
    {
        for (int i = 0; i < 25; i++)
        {
            IndexList.Add(i);
            transform.GetChild(i).GetComponent<IndividualBlock>().BlockIndex = i;
        }

        int _hollowColorIndex = Random.Range(0, 25);
        transform.GetChild(_hollowColorIndex).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Hollow;
        transform.GetChild(_hollowColorIndex).GetChild(0).transform.gameObject.AddComponent<HollowBoxProximityCheck>();
        transform.GetChild(_hollowColorIndex).GetComponent<LeanSelectableBlock>().isSwappable = true;
        IndexList.RemoveAt(_hollowColorIndex);

        //red color
        for (int i = 0; i < 4; i++)
        {
            int _redColorIndex = Random.Range(0, 24 - i);
            transform.GetChild(IndexList[_redColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Red;
            IndexList.RemoveAt(_redColorIndex);

        }

        //blue color
        for (int i = 0; i < 4; i++)
        {
            int _blueColorIndex = Random.Range(0, 20 - i);
            transform.GetChild(IndexList[_blueColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Blue;
            IndexList.RemoveAt(_blueColorIndex);

        }

        //green color
        for (int i = 0; i < 4; i++)
        {
            int _greenColorIndex = Random.Range(0, 16 - i);
            transform.GetChild(IndexList[_greenColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Green;
            IndexList.RemoveAt(_greenColorIndex);

        }

        //yellow color
        for (int i = 0; i < 4; i++)
        {
            int _yellowColorIndex = Random.Range(0, 12 - i);
            transform.GetChild(IndexList[_yellowColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Yellow;
            IndexList.RemoveAt(_yellowColorIndex);

        }

        //orange color
        for (int i = 0; i < 4; i++)
        {
            int _orangeColorIndex = Random.Range(0, 8 - i);
            transform.GetChild(IndexList[_orangeColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.Orange;
            IndexList.RemoveAt(_orangeColorIndex);
        }

        //white color
        for (int i = 0; i < 4; i++)
        {
            int _whiteColorIndex = Random.Range(0, 4 - i);
            transform.GetChild(IndexList[_whiteColorIndex]).GetComponent<IndividualBlock>().ColorOfThisBlock = ColorsOfBlocks.White;
            IndexList.RemoveAt(_whiteColorIndex);
        }

        InitializeMasterColorList();
    }

    private void InitializeMasterColorList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ColorsOfBlocks _blockColor = transform.GetChild(i).GetComponent<IndividualBlock>().ColorOfThisBlock;
            MasterColorList.Add(_blockColor);
        }

        OnAllBlockColorsSet();
    }
    public void CheckWinCondition()
    {
        //6 7 8 11 12 13 16 17 18
        if (WinColorsList[0] == MasterColorList[6] &&
            WinColorsList[1] == MasterColorList[7] &&
            WinColorsList[2] == MasterColorList[8] &&
            WinColorsList[3] == MasterColorList[11] &&
            WinColorsList[4] == MasterColorList[12] &&
            WinColorsList[5] == MasterColorList[13] &&
            WinColorsList[6] == MasterColorList[16] &&
            WinColorsList[7] == MasterColorList[17] &&
            WinColorsList[8] == MasterColorList[18])

        {
            GameManager.Instance.TriggerEndGame();
        }
        else
        {
            GameManager.Instance.TriggerFalseEndGame();
        }
    }

    public void FadeOutFrameBoxes()
    {
        for (int i = 0; i < HollowIndexList.Count; i++)
        {
            foreach (IndividualBlock _ib in FindObjectsOfType<IndividualBlock>())
            {
                if (_ib.BlockIndex == HollowIndexList[i])
                {
                    _ib.ConvertToHollow();
                }
            }
            /* for (int j = 0; j < 25; j++)
            {
                if (transform.GetChild(j).GetComponent<IndividualBlock>().BlockIndex == HollowIndexList[i])
                {
                    transform.GetChild(j).GetComponent<IndividualBlock>().SetBlockColorToHollow();
                }
            } */
        }
    }

    public void FadeInFrameBoxes()
    {
        for (int i = 0; i < HollowIndexList.Count; i++)
        {
            foreach (IndividualBlock _ib in FindObjectsOfType<IndividualBlock>())
            {
                if (_ib.BlockIndex == HollowIndexList[i])
                {
                    _ib.RevertToOriginalColor();
                }
            }
            /* for (int j = 0; j < 25; j++)
            {
                if (transform.GetChild(j).GetComponent<IndividualBlock>().BlockIndex == HollowIndexList[i])
                {
                    transform.GetChild(j).GetComponent<IndividualBlock>().RevertToOriginalColor();
                }
            } */
        }
    }

    private void SetHollowIndexesList()
    {
        HollowIndexList.Add(0);
        HollowIndexList.Add(1);
        HollowIndexList.Add(2);
        HollowIndexList.Add(3);
        HollowIndexList.Add(4);
        HollowIndexList.Add(5);
        HollowIndexList.Add(9);
        HollowIndexList.Add(10);
        HollowIndexList.Add(14);
        HollowIndexList.Add(15);
        HollowIndexList.Add(19);
        HollowIndexList.Add(20);
        HollowIndexList.Add(21);
        HollowIndexList.Add(22);
        HollowIndexList.Add(23);
        HollowIndexList.Add(24);
    }

    private void SetWinList()
    {
        WinColorsList = FindObjectOfType<MiniBoxesController>().WinColorsList;
    }

}
