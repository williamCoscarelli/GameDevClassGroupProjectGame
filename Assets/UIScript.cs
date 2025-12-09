using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text ScoreText;
    public Text TimeText;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    
    public Image HealthBar;
    //public GameTimer GameTimer;
    
    public void SetScoreText(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowTime()
    {
        //TimeText.text = GameTimer.GetTimeAsString();
    }
    
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void DrawHealthBar()
    {
        // Get the health percentage (a float between 0.0 and 1.0)
        float percentage = HealthKeeper.GetHealthPercentage(); 
    
        // Set the Image's fillAmount property directly. 
        // This is the correct way to control a Filled Image.
        HealthBar.fillAmount = percentage; 
    }
}
