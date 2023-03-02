using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //[SerializeField] private Transform Target;

    [SerializeField] float _StartVelocity;
    [SerializeField] float _Angle;

    void Start()
    {
        float temp = -Physics.gravity.y;
        Debug.Log(temp);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle1 = _Angle * Mathf.Rad2Deg;
            StopAllCoroutines();
            StartCoroutine(Coroutine_Movement(_StartVelocity, angle1));
        }
    }

    IEnumerator Coroutine_Movement(float v0, float angle)
    {
        float t = 0;
        while (t < 100)
        {
            float z = v0 * t * -Mathf.Cos(angle);
            //print(x);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);

            transform.position = new Vector3(0, y, z);
            t += Time.deltaTime;
            yield return null;
        }
    }

   
}
