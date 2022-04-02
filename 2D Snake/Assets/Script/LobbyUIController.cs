using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyUIController : MonoBehaviour
{
    [SerializeField] GameObject playerSectionScreen;
   
    public void onPlayButtonClick()
    {
        playerSectionScreen.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onOneButtonClick()
    {
        SceneManager.LoadScene((int)Level.SinglePlayer);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onTwoButtonClick()
    {
        SceneManager.LoadScene((int)Level.DoublePlayer);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }
}

enum Level {LobbyScene, SinglePlayer,DoublePlayer }
