using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backgroundRenderer;
    [SerializeField] private GameObject _pauseMenu;
    private void OnEnable()
    {
        Time.timeScale = 0;
        StartCoroutine(Initiate());
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }

    private IEnumerator Initiate()
    {
        _backgroundRenderer.color = new Color(1, 1, 1, 0);
        while (_backgroundRenderer.color.a < 1)
        {
            _backgroundRenderer.color = new Color(1, 1, 1, _backgroundRenderer.color.a + 0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        _pauseMenu.SetActive(true);
    }

}
