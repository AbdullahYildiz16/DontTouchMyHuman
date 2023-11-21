using System.Collections;
using UnityEngine;
using DG.Tweening;


public class EnemyCode : MonoBehaviour
{

    [SerializeField] Transform playerTransform;

    [SerializeField] float enemyArrivingTime;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip spiderDieClip, spiderWalkClip;

    [SerializeField] CircleCollider2D circleCollider2D;




    private void Start()
    {
        DOTween.Init();
       
        goToPlayer();
    }


    void goToPlayer()
    {
        gameObject.transform.DOLocalMove(playerTransform.position, enemyArrivingTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trail"))
        {
            
            StartCoroutine(ölüm());
        }
    }

    IEnumerator ölüm()
    {

        circleCollider2D.enabled = false;
   
        audioSource.PlayOneShot(spiderDieClip);

        yield return new WaitForSeconds(spiderDieClip.length);

        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + 1);

        gameObject.SetActive(false);
        
    }
    
    
}
