using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public static event Action OnPowerUpSelected = () => {};

    private void OnGUI()
    {
        if (!WaveManager.Instance.WaveIsActive)
        {
            if (GUILayout.Button("Power Up Selected"))
            {
                OnPowerUpSelected.Invoke();
            }
        }
    }
}
