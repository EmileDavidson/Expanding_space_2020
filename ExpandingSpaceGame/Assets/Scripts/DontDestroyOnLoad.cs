using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject DontDestroy;
    void Start()
    {
        DontDestroyOnLoad(DontDestroy);
    }
}
