using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class StartSettings : MonoBehaviour
{
    public InputField GravityInputField;
    public InputField SpeedInputField;
    public InputField CamStartSpeed;
    public InputField CamSpeedMultiplier;
    public InputField CamMaxSpeed;


    GameController GC => GameController.GC;


    private void Start()
    {
        Load();
        Setup();
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        GC.BallSpeed = (float) Convert.ToDouble(SpeedInputField.text);
        GC.BallGravity = (float) Convert.ToDouble(GravityInputField.text);
        GC.CameraStartSpeed = (float) Convert.ToDouble(CamStartSpeed.text);
        GC.CameraSpeedMultiplier = (float) Convert.ToDouble(CamSpeedMultiplier.text);
        GC.CameraMaxSpeed = (float) Convert.ToDouble(CamMaxSpeed.text);
        Save();
    }



    void Save()
    {
        PlayerPrefs.SetFloat("speed", (float) Convert.ToDouble(SpeedInputField.text));
        PlayerPrefs.SetFloat("gravity", (float) Convert.ToDouble(GravityInputField.text));
        PlayerPrefs.SetFloat("camStartSpeed", (float) Convert.ToDouble(CamStartSpeed.text));
        PlayerPrefs.SetFloat("camSpeedMultiplier", (float) Convert.ToDouble(CamSpeedMultiplier.text));
        PlayerPrefs.SetFloat("camMaxSpeed", (float) Convert.ToDouble(CamMaxSpeed.text));
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("speed")) SpeedInputField.text = PlayerPrefs.GetFloat("speed").ToString();
        if (PlayerPrefs.HasKey("gravity")) GravityInputField.text = PlayerPrefs.GetFloat("gravity").ToString();
        if (PlayerPrefs.HasKey("camStartSpeed")) CamStartSpeed.text = PlayerPrefs.GetFloat("camStartSpeed").ToString();
        if (PlayerPrefs.HasKey("camSpeedMultiplier"))
            CamSpeedMultiplier.text = PlayerPrefs.GetFloat("camSpeedMultiplier").ToString();
        if (PlayerPrefs.HasKey("camMaxSpeed")) CamMaxSpeed.text = PlayerPrefs.GetFloat("camMaxSpeed").ToString();
    }


}
