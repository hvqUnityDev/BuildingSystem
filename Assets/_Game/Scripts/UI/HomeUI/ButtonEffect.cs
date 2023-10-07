using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    public void Click()
    {
        SFX.Ins.PlayClick();
    }
}
