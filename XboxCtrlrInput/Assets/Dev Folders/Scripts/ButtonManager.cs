using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;


public class ButtonManager : MonoBehaviour
{
    public GameObject startScherm;
    public GameObject controlsScherm;
    public GameObject creditsScherm;

    [SerializeField] private Button startButton;

    private XboxController controller;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.B, controller) && startScherm.activeSelf == false)
        {
            StartScherm();
            
            startButton.Select();

        }
    }


    public void StartScherm()
    {
        startScherm.SetActive(true);
        controlsScherm.SetActive(false);
        creditsScherm.SetActive(false);

    }
   

    public void ControlsScherm()
    {
        startScherm.SetActive(false);
        controlsScherm.SetActive(true);
        creditsScherm.SetActive(false);

    }

    public void CreditsScherm()
    {
        startScherm.SetActive(false);
        controlsScherm.SetActive(false);
        creditsScherm.SetActive(true);

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
