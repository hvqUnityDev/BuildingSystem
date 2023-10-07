using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Ins;
    [SerializeField] private AudioSource effect;
    
    private void Awake()
    {
        if (Ins != null){
            Destroy(gameObject);
            return;
        }

        Ins = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClick()
    {
        effect.Play();
    }
}