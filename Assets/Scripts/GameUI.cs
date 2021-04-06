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
    public GameObject GamePanel;

    public List<GameObject> Health = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GC.UI = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextScore.text = Mathf.Round(GC.Score).ToString();
    }



    public void HideMainMenu()
    {
        MainMenuPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGamePanel()
    {
        GamePanel.SetActive(false);
    }

    public void ShowGamePanel()
    {
        GamePanel.SetActive(true);
    }

    public void ChangeHealth(int count)
    {
        for (int i = 2; i >= count; i--)
        {
            Health[i].SetActive(false);
        }
    }

}
