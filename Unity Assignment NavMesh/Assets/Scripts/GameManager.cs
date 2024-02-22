using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas StartCanvas;
    [SerializeField] Canvas EndCanvas;
    [SerializeField] Canvas InGameCanvas;

    [SerializeField] TextMeshProUGUI WhoWonText;
    [SerializeField] TextMeshProUGUI Place;

    [SerializeField] Transform RedPlayer;
    [SerializeField] Transform BluePlayer;
    [SerializeField] Transform YellowPlayer;

    private float YellowX, BlueX, RedX;
    private string winning;
    
    void Start()
    {
        Time.timeScale = 0;
        StartCanvas.enabled = true;
        EndCanvas.enabled = false;
        InGameCanvas.enabled = false;
    }

    void Update()
    {
        WhosLeading();
        if (RedX <= -70.03 || YellowX <= -70.03 || BlueX <= -70.03)
        {
            WhoWon();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartCanvas.enabled = false;
        EndCanvas.enabled = false;
        InGameCanvas.enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void EndGame()
    {
        InGameCanvas.enabled = false;
        EndCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void WhosLeading()
    {
        YellowX = YellowPlayer.position.x;
        BlueX = BluePlayer.position.x;
        RedX = RedPlayer.position.x;

        if (YellowX < BlueX && YellowX < RedX)
        {
            winning = "yellow";
            Place.color = Color.yellow; Place.text = "1st Place"; return;
            
        }
        else if (YellowX < BlueX && YellowX > RedX)
        {
            winning = "blue";
            Place.color = Color.cyan; Place.text = "2nd Place"; return;
        }
        else if (YellowX > BlueX && YellowX < RedX)
        {
            winning = "red";
            Place.color = Color.cyan; Place.text = "2nd Place"; return;
        }
        else if (YellowX > BlueX && YellowX > RedX)
        {
            if (BlueX < RedX) { winning = "blue"; }
            else { winning = "red"; }
           Place.color = Color.magenta; Place.text = "3rd Place"; return;
        }

    }

    public void WhoWon()
    {
        YellowX = YellowPlayer.position.x;
        BlueX = BluePlayer.position.x;
        RedX = RedPlayer.position.x;

            switch (winning)
            {
                case "red": { WhoWonText.color = Color.red; break; }
                case "blue": { WhoWonText.color = Color.blue; break; }
                case "yellow": { WhoWonText.color = Color.yellow; break; }
                default: break;
            }
            EndGame();
            WhoWonText.text = $"{winning} Won";
    }

        
  
}
