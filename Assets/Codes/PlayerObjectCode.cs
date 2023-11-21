using UnityEngine;
using DG.Tweening;

public class PlayerObjectCode : MonoBehaviour
{
    [SerializeField]
    float moving_speed;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        DOTween.Init();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            Vector3 touchPos = Input.mousePosition;
            touchPos.z = 10f;
            Vector3 realPos = Camera.main.ScreenToWorldPoint(touchPos);

            transform.DOLocalMove(realPos, moving_speed).OnStepComplete(()=>offAudioSource());
        }
        
    }
    void offAudioSource()
    {
        audioSource.Stop();
    }
}
