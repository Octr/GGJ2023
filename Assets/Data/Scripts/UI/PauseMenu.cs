using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool m_isPaused;
    public GameObject m_pauseObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (m_isPaused)
        {
            Time.timeScale = 0;
            m_pauseObj.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            m_pauseObj.SetActive(false);
        }

        m_isPaused = !m_isPaused;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
