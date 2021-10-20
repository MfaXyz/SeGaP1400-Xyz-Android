using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class XyzUITransition : MonoBehaviour
{
    [Header("Values")] 
    public bool autoRun;
    public float delayToStart;
    public float speedOfTransition;
    private float _valueOfTransition;
    public bool setStartPosition;
    public bool hideAfterDone;
    private bool _delay = true;
    [SerializeField] private bool worker;
    
    [Header("Points")]
    public Vector2 xPosition;
    public Vector2 yPosition;
    
    [Header("Objects")] 
    public RectTransform rect;

    private void Awake()
    {
        if (autoRun)
        {
            if (setStartPosition)
            {
                rect.anchoredPosition = xPosition;
            }
            worker = true;
            StartCoroutine(DelayToStart());
        }
    }

    private void FixedUpdate()
    {
        if (worker && !_delay)
        {
            _valueOfTransition += (Time.deltaTime + speedOfTransition) / 1000;
            rect.anchoredPosition =
                Vector2.Lerp(xPosition, yPosition, _valueOfTransition);
           if (rect.anchoredPosition == yPosition)
           {
               worker = false;
               _delay = true;
               if (hideAfterDone)
               {
                   gameObject.SetActive(false);
               }
           }
        }
    }

    public void StartTransition(string newPos)
    {
        if (!worker)
        {
            _valueOfTransition = 0;
            worker = true;
            if (newPos == "")
            {
                (xPosition, yPosition) = (yPosition, xPosition);
                hideAfterDone = false;
            }else if (newPos == "D")
            {
                (xPosition, yPosition) = (yPosition, xPosition);
                hideAfterDone = true;
            }

            if (setStartPosition)
            {
                rect.anchoredPosition = xPosition;
            }
            StartCoroutine(DelayToStart());
        }
    }

    public void ReversePoints()
    {
        (xPosition, yPosition) = (yPosition, xPosition);
    }
    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(delayToStart);
        _valueOfTransition = 0;
        _delay = false;
    }
}
