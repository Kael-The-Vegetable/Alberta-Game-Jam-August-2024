using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    public GameObject pauseMenu;
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }
}
