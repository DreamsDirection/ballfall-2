using System;
using Controllers;
using Items.Models;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Настройки основных параметров
/// Только для тестов
///     Удалить в релизе!!!!
/// </summary>

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
        Model.BallSpeed = (float) Convert.ToDouble(SpeedInputField.text);
        Model.BallGravity = (float) Convert.ToDouble(GravityInputField.text);
        Model.CamStartSpeed = (float) Convert.ToDouble(CamStartSpeed.text);
        Model.CamSpeedMultiplier = (float) Convert.ToDouble(CamSpeedMultiplier.text);
        Model.CamMaxSpeed = (float) Convert.ToDouble(CamMaxSpeed.text);


        GC.BallSpeed = Model.BallSpeed;
        GC.BallGravity = Model.BallGravity;
        GC.CameraStartSpeed = Model.CamStartSpeed;
        GC.CameraSpeedMultiplier = Model.CamSpeedMultiplier;
        GC.CameraMaxSpeed = Model.CamMaxSpeed;
        
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
