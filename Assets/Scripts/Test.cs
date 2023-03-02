using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float flightTime;
    public float maxHeight;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 randomPosition;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Randomizer();
            StopAllCoroutines();
            StartCoroutine(Para());
        }
    }

    private IEnumerator Para()
    {
        _startPosition = startPoint.position;
        _endPosition = endPoint.position;

        Vector3 controlPoint = _startPosition + (_endPosition - _startPosition) / 2 + Vector3.up * maxHeight;

        for (float t = 0; t < 1; t += Time.deltaTime / flightTime)
        {
            Vector3 position = Mathf.Pow(1 - t, 2) * _startPosition + 2 * t * (1 - t) * controlPoint + Mathf.Pow(t, 2) * _endPosition;

            position += new Vector3(0, 0.469f, 0); //Doesn't go inside the ground

            transform.position = position;

            yield return null;
        }
    }

    private void Randomizer()
    {

        randomPosition.x = Random.Range(-5.67f, 5.67f);
        randomPosition.y = 0f;
        randomPosition.z = Random.Range(-5.7f, 5.7f);

        endPoint.position = randomPosition;
    }
}


