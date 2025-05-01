using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private GameObject OptionsButton;
    [SerializeField] private GameObject SceneButton;
    public void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
        OptionsButton.SetActive(false);
        SceneButton.SetActive(false);
    }

    public void CloseSoundPanel()
    {
        soundPanel.SetActive(false);
        OptionsButton.SetActive(true);
        SceneButton.SetActive(true);
    }
    public void ChangeScene1()
    {
        SceneManager.LoadScene("World2");
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene("World1");
    }
}
