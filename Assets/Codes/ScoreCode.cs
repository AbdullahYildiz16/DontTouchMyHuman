using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScoreCode : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject levelPassedPanel;
    [SerializeField] int levelLimitScore;
    public int score;
    private void Start()
    {
        DOTween.Init();
    }

    private void FixedUpdate()
    {
        score = PlayerPrefs.GetInt("score", 0);
        if (score >= levelLimitScore)
        {
            levelPassedPanel.SetActive(true);
            levelPassedPanel.transform.DOShakeRotation(0.5f).SetDelay(3f).OnStepComplete(()=> loadNewLevel());
            
            

        }
        scoreText.text = "" + score;
    }
    public void loadNewLevel()
    {
        int newLevel = int.Parse(SceneManager.GetActiveScene().name.ToString());
        if (newLevel >= 3)
        {
            newLevel = 0;
            PlayerPrefs.SetInt("score", 0);
        }
        SceneManager.LoadScene(newLevel);
    }
}
