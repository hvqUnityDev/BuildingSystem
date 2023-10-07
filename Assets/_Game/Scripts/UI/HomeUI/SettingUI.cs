using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : BaseUIElement
{
    
    [SerializeField] private Slider sliderVolume;
    public override void OnAwake()
    {
        
    }

    public void Start()
    {
        LoadValueSlider();
    }
    
    public void ChangeValue(){
        var setting = UserDataController.Instance.GetData<Setting>(UserDataKeys.USER_SETTING, out _);
        setting.volume = sliderVolume.value;
        AudioListener.volume = setting.volume;
        UserDataController.Instance.SetData(UserDataKeys.USER_SETTING, setting);
    }

    public void LoadValueSlider()
    {
        var setting = UserDataController.Instance.GetData<Setting>(UserDataKeys.USER_SETTING, out _);
        sliderVolume.value = setting.volume;
        AudioListener.volume = setting.volume;
    }
}
