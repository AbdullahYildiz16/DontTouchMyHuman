using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TrailRendererScript : MonoBehaviour
{
    [SerializeField] TrailRenderer trail; 
    
    public GameObject ColliderPrefab;

    public int poolSize = 5;
    public float waitTime;
    public float colliderMoveSpeed;
    GameObject[] pool;

    void Start()
    {
        DOTween.Init();
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ColliderPrefab);
        }
    }

    void Update()
    {
        if (!trail.isVisible)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i].gameObject.SetActive(false);

            }
        }
        else
        {
            TrailCollission();
        }

    }

    void TrailCollission()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeSelf == false)
            {
                pool[i].gameObject.SetActive(true);

                
                pool[i].gameObject.transform.DOLocalMove(gameObject.transform.position, colliderMoveSpeed);


                StartCoroutine(hide(waitTime, pool[i].gameObject));
                return;
            }
        }
    }
    private IEnumerator hide(float waitTime, GameObject p)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            p.SetActive(false);

            yield break;
        }
        yield break;
    }

}
