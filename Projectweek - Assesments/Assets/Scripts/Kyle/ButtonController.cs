using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void BattleScreen1()
    {
        GameObject.FindObjectOfType<AudioPenis>().GetComponent<AudioPenis>().StopAudio();
        SceneManager.LoadScene("FirstBattleScreen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlayTesting");
    }

    public void ToMidScreen()
    {
        SceneManager.LoadScene("BetweenMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
