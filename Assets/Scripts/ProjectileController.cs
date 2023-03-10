using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float flightTime;
    public float maxHeight;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        StartCoroutine(Para());
    }

    private IEnumerator Para()
    {
        _startPosition = startPoint.position;
        _endPosition = endPoint.position;

        Vector3 controlPoint = _startPosition + (_endPosition - _startPosition) / 2 + Vector3.up * maxHeight;

        for (float t = 0; t < 1; t += Time.deltaTime / flightTime)
        {
            Vector3 position = Mathf.Pow(1 - t, 2) * _startPosition + 2 * t * (1 - t) * controlPoint + Mathf.Pow(t, 2) * _endPosition;
            transform.position = position;

            yield return null;
        }
    }

}


