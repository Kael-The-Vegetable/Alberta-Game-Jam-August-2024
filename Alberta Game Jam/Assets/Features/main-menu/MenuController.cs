using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MenuController : MonoBehaviour
{
    [SerializeField] protected GameObject[] _buttonObjects;
    protected Button[] _buttons;
    protected int _selectedIndex = 0;

    public EventSystem eventSystem;
    [Space]
    public float introWaitTime;

    internal virtual void Awake()
    {
        _buttons = new Button[_buttonObjects.Length];

        for (int i = 0; i < _buttonObjects.Length; i++)
        {
            _buttons[i] = _buttonObjects[i].GetComponent<Button>();
        }

        if (eventSystem != null && _buttonObjects.Length > 0)
        { eventSystem.SetSelectedGameObject(_buttonObjects[0]); }
        else
        { Debug.LogError("You require to have buttons exist and an eventSystem."); }
    }

    internal virtual void OnEnable()
    {
        Move(introWaitTime, Vector2.zero);
        StartCoroutine(Initialize(introWaitTime));
        eventSystem.SetSelectedGameObject(_buttonObjects[_selectedIndex]);
    }

    internal virtual void OnDisable()
    {
        for (int i = 0; i < _buttonObjects.Length; i++)
        {
            if (eventSystem.currentSelectedGameObject == _buttonObjects[i])
            { _selectedIndex = i; }
        }
    }

    protected IEnumerator Initialize(float waitTime)
    {
        DisableButtons(true);
        yield return new WaitForSecondsRealtime(waitTime);
        DisableButtons(false);
    }

    private void DisableButtons(bool disable)
    {
        for (int i = 0; i < _buttons.Length; i++)
        { _buttons[i].enabled = !disable; }
    }

    public virtual void Move(float waitTime, Vector2 newPos) 
        => gameObject.transform.DOMove(newPos, waitTime);
    
    public virtual void Outro(float waitTime, GameObject newActiveObj, Vector2 newPos) 
        => StartCoroutine(OutroWait(waitTime, newActiveObj, newPos));
    
    internal virtual IEnumerator OutroWait(float waitTime, GameObject newActiveObj, Vector2 newPos)
    {
        Move(waitTime, newPos);
        yield return new WaitForSecondsRealtime(waitTime);
        gameObject.SetActive(false);
        newActiveObj.SetActive(true);
    }
}
