using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool gameHasStarted = false;
    public TimerNew timer;
    public GameObject StartBanner, CheckGood, CheckBad, WinIcon, RestartGameButton, AudioButton, BackgroundButton, BackgroundObject, CheckButton, MiniBoxes;
    public TextMeshProUGUI BestTimeText;
    public FaderController FaderController;
    public bool isMainMenu = false;
    private Coroutine falseEndGameRoutine = null;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

    private void Start() 
    {
        SetPlayerPrefKeys();
        BestTimeText.text = PlayerPrefs.GetString(PrefKeys.BestTime);
         print(PlayerPrefs.GetString(PrefKeys.BestTime));
    }

    private void Update()
    {
        if (isMainMenu)
            return;
        if (!gameHasStarted && Input.anyKey)
        {
            gameHasStarted = true;
            MiniBoxes.SetActive(true);
            timer.CountingTime = true;
            StartBanner.SetActive(false);
        }
    }

    private void SetPlayerPrefKeys()
    {
        if (!PlayerPrefs.HasKey(PrefKeys.FirstTimePlaying))
        {
           
            PlayerPrefs.SetInt(PrefKeys.FirstTimePlaying, 1);
            PlayerPrefs.SetFloat(PrefKeys.BestTimeAsFloat, 999999999999999f);
            PlayerPrefs.SetString(PrefKeys.BestTime, "N/A");
        }
    }

    public void SetNewScore(float __timeAsFloat, string __newBestTime)
    {
        if (__timeAsFloat < PlayerPrefs.GetFloat(PrefKeys.BestTimeAsFloat))
        {
            PlayerPrefs.SetFloat(PrefKeys.BestTimeAsFloat, __timeAsFloat);
            PlayerPrefs.SetString(PrefKeys.BestTime, __newBestTime);
        }
    }

    public void TriggerEndGame()
    {
        if (falseEndGameRoutine != null)
        {
            StopCoroutine(falseEndGameRoutine);
        }

        falseEndGameRoutine = StartCoroutine(EndGameRoutine());
    }

    public void TriggerFalseEndGame()
    {
        if (falseEndGameRoutine != null)
        {
            StopCoroutine(falseEndGameRoutine);
        }
        falseEndGameRoutine = StartCoroutine(FalseEndGameRoutine());
    }

    IEnumerator EndGameRoutine()
    {
        CheckButton.SetActive(false);
        BlockPositionManager.Instance.FadeOutFrameBoxes();
        CheckGood.SetActive(true);
        yield return new WaitForSeconds(2f);
        timer.StopTimerAndSendNewScore();
        WinIcon.SetActive(true);
        RestartGameButton.SetActive(true);
        
    }

    IEnumerator FalseEndGameRoutine()
    {
        CheckButton.SetActive(false);
        CheckBad.SetActive(true);
        BlockPositionManager.Instance.FadeOutFrameBoxes();
        yield return new WaitForSeconds(2f);
        BlockPositionManager.Instance.FadeInFrameBoxes();
        CheckBad.SetActive(false);
        CheckButton.SetActive(true);
    }

}
