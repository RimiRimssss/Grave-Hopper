using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMNextScene : MonoBehaviour

{
    private static BGMNextScene instance = null;
    public static BGMNextScene Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}