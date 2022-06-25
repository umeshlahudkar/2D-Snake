using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    public void onRestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onMainMenuButtonClick()
    {
        SceneManager.LoadScene((int)Level.LobbyScene);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onPauseButtonClick()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onResumeButtonClick()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);

    }

}
