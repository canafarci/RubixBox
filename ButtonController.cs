using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private FaderController faderController;
    public Sprite BackgroundOffSprite, BackgroundOnSprite;
    public Image BackgroundImage;
    private static Coroutine loadSceneRoutine = null;
    private bool settingsOpen, backgroundClosed = false;
    private void Awake()
    {
        faderController = FindObjectOfType<FaderController>();
    }
    public void OnCheckButtonClicked()
    {
        BlockPositionManager.Instance.CheckWinCondition();
    }

    public void OnReloadButtonClicked()
    {
        GameManager.Instance.FaderController.enabled = true;
        GameManager.Instance.FaderController.FadingIn = false;
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }
            
        loadSceneRoutine = StartCoroutine(LoadSceneWithDelay(1));
    }

    public void OnLoadMainMenuButtonClicked()
    {
        GameManager.Instance.FaderController.enabled = true;
        GameManager.Instance.FaderController.FadingIn = false;
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = StartCoroutine(LoadSceneWithDelay(0));
    }

    IEnumerator LoadSceneWithDelay(int __sceneIndex)
    {
        yield return new WaitForSeconds(faderController.FadingTime);
        SceneManager.LoadScene(__sceneIndex);
    }

    public void OnSettingsButtonClicked()
    {
        if (!settingsOpen)
        {
            GameManager.Instance.AudioButton.SetActive(true);
            GameManager.Instance.BackgroundButton.SetActive(true);
            settingsOpen = true;
        }
        else
        {
            GameManager.Instance.AudioButton.SetActive(false);
            GameManager.Instance.BackgroundButton.SetActive(false);
            settingsOpen = false;
        }
    }

    public void OnBackgroundButtonClicked()
    {
        if (backgroundClosed)
        {
            GameManager.Instance.BackgroundObject.SetActive(true);
            backgroundClosed = false;
            BackgroundImage.sprite = BackgroundOnSprite;
        }
        else
        {
            GameManager.Instance.BackgroundObject.SetActive(false);
            backgroundClosed = true;
            BackgroundImage.sprite = BackgroundOffSprite;
        }
    }
}
