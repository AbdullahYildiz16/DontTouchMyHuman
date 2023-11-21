using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class CharacterCode : MonoBehaviour
{

    [SerializeField] GameObject levelFailedPanel;
    [SerializeField] Text dieKilledSpiderText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip scareSound;

    private void Start()
    {
        DOTween.Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            
            
            levelFailedPanel.SetActive(true);
            dieKilledSpiderText.text = "" + PlayerPrefs.GetInt("score", 0);
            audioSource.Stop();
            audioSource.volume = 1f;
            audioSource.PlayOneShot(scareSound);
            
            levelFailedPanel.transform.DOShakeRotation(0.5f).SetDelay(3f).OnStepComplete(() => restartLevel());

           
            

        }
        
    }
    public void restartLevel()
    {
        int newLevel = int.Parse(SceneManager.GetActiveScene().name.ToString());
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(newLevel -1);
    }
}
