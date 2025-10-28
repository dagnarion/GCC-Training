using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomAnimation : MonoBehaviour
{
    [Header("Enlarge")]
    [SerializeField] Vector3 largeSize;
    [SerializeField] float zoomOutTimeMax;

    [Header("Shrink")]
    [SerializeField] Vector3 smallSize;
    [SerializeField] float zoomInTimeMax;

    [Header("Dance")]
    [SerializeField] float maxDanceTime = 0.1f;
    [SerializeField] float speed = 5f;

    [Header("Nozmal")]
    [SerializeField] float nozmalTimeMax;

    Coroutine animate;
    bool isDone = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDone)
        {
            animate = StartCoroutine(Zoom());
        }
    }

    IEnumerator Zoom()
    {
        isDone = false;
        Vector3 startSize = transform.localScale;
        Vector3 originSize = transform.localScale;
        yield return StartCoroutine(DoZoom(startSize, zoomInTimeMax, smallSize));
        
        yield return new WaitForSeconds(0.5f);
        startSize = transform.localScale;
        yield return StartCoroutine(DoZoom(startSize, zoomOutTimeMax, largeSize));

        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Dance());

        yield return new WaitForSeconds(0.5f);
        startSize = transform.localScale;
        yield return StartCoroutine(DoZoom(startSize, nozmalTimeMax, originSize));
        transform.localScale = originSize;
        isDone = true;
    }

    IEnumerator DoZoom(Vector3 startSize, float zoomTime, Vector3 size)
    {
        Vector3 targetSize = size;
        float countTimer = 0;
        while (countTimer < zoomTime)
        {
            float t = Mathf.InverseLerp(0f, zoomTime, countTimer);
            transform.localScale = Vector3.Lerp(startSize, targetSize, t);
            yield return null;
            countTimer += Time.deltaTime;
        }
    }

    IEnumerator Dance()
    {
        Vector3 baseScale = transform.localScale;
        float amplitude = 0.1f;     // Biên độ dao động    
        float countTime = 0f;
        float startTime = Time.time;
        while (countTime < maxDanceTime)
        {
            countTime += Time.deltaTime;
            float t = Time.time - startTime;
            float sinY = Mathf.Sin(t * speed);

            float scaleY = baseScale.y + sinY * amplitude; // công thức dao động điều hòa tại một điểm: x(t) = A * sin(w*t + p) + C
            transform.localScale = new Vector3(baseScale.x, scaleY, 1);

            yield return null;
        }
    }


}
