using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameController GC => GameController.GC;
    public Text TextScore;

    public GameObject MainMenuPanel;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        GC.UI = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextScore.text = GC.Score.ToString();
    }



    public void MainMenuIsActive(bool b)
    {
        MainMenuPanel.SetActive(b);
    }
    public void GameOverPanelIsActive(bool b)
    {
        GameOverPanel.SetActive(b);
    }
    
    public void GameOverPanelIsActive()
    {
        
    }

}
