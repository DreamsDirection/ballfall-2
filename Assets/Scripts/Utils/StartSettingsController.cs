using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Items.Models;
using UnityEngine;
using UnityEngine.UI;

public class StartSettingsController : MonoBehaviour
{
    public InputField GravityInputField;
    public InputField SpeedInputField;
    public InputField CamStartSpeed;
    public InputField CamSpeedMultiplier;
    public InputField CamMaxSpeed;

    public StartSettings Model;


    GameController GC => GameController.GC;


    private void Start()
    {
        Load();
    }
    

    public void Setup()
    {
        GC.BallSpeed = (float) Convert.ToDouble(SpeedInputField.text);
        GC.BallGravity = (float) Convert.ToDouble(GravityInputField.text);
        GC.CameraStartSpeed = (float) Convert.ToDouble(CamStartSpeed.text);
        GC.CameraSpeedMultiplier = (float) Convert.ToDouble(CamSpeedMultiplier.text);
        GC.CameraMaxSpeed = (float) Convert.ToDouble(CamMaxSpeed.text);
        
        
        Model.BallSpeed = (float) Convert.ToDouble(SpeedInputField.text);
        Model.BallGravity = (float) Convert.ToDouble(GravityInputField.text);
        Model.CamStartSpeed = (float) Convert.ToDouble(CamStartSpeed.text);
        GC.CameraSpeedMultiplier = (float) Convert.ToDouble(CamSpeedMultiplier.text);
        GC.CameraMaxSpeed = (float) Convert.ToDouble(CamMaxSpeed.text);
        Save();
    }



    void Save()
    {
        PersistentCache.Save("model", Model);
    }

    public void Load()
    {
        Model = PersistentCache.TryLoad<StartSettings>("model");
        if (Model == null) Model = new StartSettings();
        GravityInputField.text = Model.BallGravity.ToString();
        SpeedInputField.text = Model.BallSpeed.ToString();
        CamStartSpeed.text = Model.CamStartSpeed.ToString();
        CamSpeedMultiplier.text = Model.CamSpeedMultiplier.ToString();
        CamMaxSpeed.text = Model.CamMaxSpeed.ToString();
    }

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }
}
