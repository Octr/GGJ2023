using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Marks as "don't destroy on load"
/// </summary>
public class ProtectiveParent : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
