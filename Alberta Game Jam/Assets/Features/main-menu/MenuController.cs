using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] protected GameObject[] _buttonObjects;
    protected GameObject _prevSelectedButton;
    protected Button[] _buttons;
    protected Animator[] _buttonAnimations;

    public EventSystem eventSystem;

    internal virtual void Awake()
    {
        _buttons = new Button[_buttonObjects.Length];
        _buttonAnimations = new Animator[_buttonObjects.Length];

        for (int i = 0; i < _buttonObjects.Length; i++)
        {
            _buttons[i] = _buttonObjects[i].GetComponent<Button>();
            _buttonAnimations[i] = _buttonObjects[i].GetComponent<Animator>();
        }

        if (_buttonObjects.Length > 0)
        { _prevSelectedButton = _buttonObjects[0]; }
        else
        { Debug.LogError("You require to have buttons exist."); }
    }

    internal virtual void OnEnable()
    {
        if (eventSystem != null)
        { eventSystem.SetSelectedGameObject(_prevSelectedButton); }
        else
        { Debug.LogError("You require to have an eventSystem exist."); }
    }

    internal virtual void OnDisable()
    {
        _prevSelectedButton = eventSystem.currentSelectedGameObject;
    }

    internal virtual IEnumerator Initialize(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        SelectNewButton();
    }

    internal virtual void Update()
    {
        if (_prevSelectedButton != eventSystem.currentSelectedGameObject)
        {
            _prevSelectedButton = eventSystem.currentSelectedGameObject;
            SelectNewButton();
        }
    }

    public virtual void SelectNewButton()
    {
        for (int i = 0; i < _buttonObjects.Length; i++)
        {
            if (_prevSelectedButton == _buttonObjects[i])
            {
                _buttonAnimations[i].SetTrigger("Selected");
            }
        }
    }

    public virtual void Outro(float waitTime, GameObject newActiveObj)
    {
        StartCoroutine(OutroWait(waitTime, newActiveObj));
    }
    internal virtual IEnumerator OutroWait(float waitTime, GameObject newActiveObj)
    {
        for (int i = 0; i < _buttonObjects.Length; i++)
            _buttonAnimations[i].SetTrigger("Leave");

        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        newActiveObj.SetActive(true);
    }
}
