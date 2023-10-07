using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHome : MonoBehaviour {
    [SerializeField] private LoadScene loader;
    void Start()
    {
        loader.ClickBackHome();
    }
}
