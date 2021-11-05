using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TimerMove : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originPos;
    public float HSpeed;
    public float HMin = -551;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.anchoredPosition;
    }

    public void restart()
    {
        rectTransform.anchoredPosition = originPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 aPos = rectTransform.anchoredPosition;

        if (aPos.x < HMin)
        {
            restart();
            return;
        }

        aPos.x += HSpeed * Time.deltaTime;

        rectTransform.anchoredPosition = aPos;

    }
}
