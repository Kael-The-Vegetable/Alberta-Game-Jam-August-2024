using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public GameObject[] images;
    private SpriteRenderer[] _spriteRenderers;
    public float blownUpTime;
    public float firedTime;

    private void Awake()
    {
        _spriteRenderers = new SpriteRenderer[images.Length];
        for (int i = 0; i < images.Length; i++)
        { _spriteRenderers[i] = images[i].GetComponent<SpriteRenderer>(); }
        int num = Singleton.Global.Random.Next(2);
        if (num == 0)
        { // blow up
            StartCoroutine(BlownUp(blownUpTime));
        }
        else
        { // man fired
            StartCoroutine(Fired(firedTime));
        }
    }

    private IEnumerator BlownUp(float time)
    {
        images[1].SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        images[2].SetActive(true);
        images[1].SetActive(false);
    }
    private IEnumerator Fired(float time)
    {
        images[0].SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        images[3].SetActive(true);
    }
}
