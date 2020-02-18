using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject startScherm;
    public GameObject controlsScherm;
    public GameObject creditsScherm;
    public GameObject goBackButtonScherm;

    public void StartScherm()
    {
        startScherm.SetActive(true);
        controlsScherm.SetActive(false);
        creditsScherm.SetActive(false);

        goBackButtonScherm.SetActive(false);
    }

    public void ControlsScherm()
    {
        startScherm.SetActive(false);
        controlsScherm.SetActive(true);
        creditsScherm.SetActive(false);

        goBackButtonScherm.SetActive(true);
    }

    public void CreditsScherm()
    {
        startScherm.SetActive(false);
        controlsScherm.SetActive(false);
        creditsScherm.SetActive(true);

        goBackButtonScherm.SetActive(true);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
