using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMove : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originPos;
    public float HSpeed = -1;
    public float HMin = -551;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 aPos = rectTransform.anchoredPosition;

        if (aPos.x < HMin) aPos = originPos;

        aPos.x += HSpeed * Time.deltaTime;

        rectTransform.anchoredPosition = aPos;

    }
}
