using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] var_Player player;
    [SerializeField] var_Spawn spawn;

    [Header("UI")]
    [SerializeField] CanvasGroup cStartGame;
    [SerializeField] CanvasGroup cPlayGame;
    [SerializeField] CanvasGroup cEndGame;
    [SerializeField] CanvasGroup cIsPause;

    [Header("Show End Game")]
    [SerializeField] Text scorePlayGame;
    [SerializeField] Text scoreEndGame;
    [SerializeField] Text bestScore;
    [SerializeField] GameObject bronze;
    [SerializeField] GameObject Sliver;
    [SerializeField] GameObject Gold;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlaySoundBackround();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScorePlayGame();
        if (player.isDetected)
        {
            ShowEngGame();
            ShowScoreEndGame();
        }
    }

    #region OnClickButtonUI

    public void OnClickStartGame()
    {
        player.isSoundFly = true;
        Time.timeScale = 1;
        Hide(cStartGame);
        Show(cPlayGame);
        Hide(cEndGame);
        Hide(cIsPause);
    }

    public void OnClickPauseGame()
    {
        Time.timeScale = 0;
        Hide(cStartGame);
        Hide(cPlayGame);
        Hide(cEndGame);
        Show(cIsPause);
        player.isSoundFly = false;
    }

    public void ShowEngGame()
    {
        Time.timeScale = 0;
        Hide(cStartGame);
        Hide(cPlayGame);
        Show(cEndGame);
        Hide(cIsPause);
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        Hide(cStartGame);
        Show(cPlayGame);
        Hide(cEndGame);
        Hide(cIsPause);
        player.isSoundFly = true;
    }

    public void OnClickHome()
    {
        Time.timeScale = 0;
        Show(cStartGame);
        Hide(cPlayGame);
        Hide(cEndGame);
        Hide(cIsPause);
        ResetGame();
        player.isSoundFly = false;
    }

    public void OnClickAgain()
    {
        Time.timeScale = 1;
        Hide(cStartGame);
        Show(cPlayGame);
        Hide(cEndGame);
        Hide(cIsPause);
        ResetGame();
        player.isSoundFly = true;
    }

    public void ResetGame()
    {
        player.currentScore = 0;
        player.isSoundFly = false;
        player.isDetected = false;
        player.transform.position = new Vector3(0, 0, 0);
        foreach (GameObject obj in PipePool.Instance.Pipes)
        {
            obj.SetActive(false);
        }
        spawn.timer = spawn.maxTime;
    }

    public void SoundUIClick()
    {
        if(AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("UIClick");
        }
    }

    void SetActiveCanvasGroup(CanvasGroup canvasGroup,bool isActive)
    {
        canvasGroup.blocksRaycasts = isActive;
        if(isActive)
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.alpha = 0;
        }
    }

    void Hide(CanvasGroup canvasGroup)
    {
        SetActiveCanvasGroup(canvasGroup, false);
    }

    void Show(CanvasGroup canvasGroup)
    {
        SetActiveCanvasGroup(canvasGroup, true);
    }

    public void SoundUIHover()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("UIHover");
        }
    }

    public void SoundOn()
    {
        AudioListener.volume = 1;
    }

    public void SoundOff()
    {
        AudioListener.volume = 0;
    }
    #endregion

    #region UIPlayGame
    void ShowScorePlayGame()
    {
        scorePlayGame.text = player.currentScore.ToString();
    }
    #endregion

    #region UIEndGame
    void BestScore()
    {

        if (player.currentScore >= player.bestScore)
        {
            player.bestScore = player.currentScore;
        }
    }

    void ShowScoreEndGame()
    {
        scoreEndGame.text = player.currentScore.ToString();
        BestScore();
        bestScore.text = player.bestScore.ToString();
        if(player.currentScore <= 20)
        {
            bronze.SetActive(true);
            Sliver.SetActive(false);
            Gold.SetActive(false);
        }
        else if(player.currentScore <= 50 && player.currentScore > 20)
        {
            bronze.SetActive(false);
            Sliver.SetActive(true);
            Gold.SetActive(false);
        }
        else if(player.currentScore > 50 )
        {
            bronze.SetActive(false);
            Sliver.SetActive(false);
            Gold.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        player.currentScore = 0;
    }

    #endregion
}