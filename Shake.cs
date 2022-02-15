using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    bool start = false;
    [SerializeField] AnimationCurve curve;
    float duration = 0.04f;
    GameObject level;

    private void Update()
    {
        level = GameObject.Find("Level");

        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            level.transform.position = new Vector3(startPosition.x, startPosition.y, level.transform.position.z) + Random.insideUnitSphere * strength;
            transform.position = new Vector3(startPosition.x, startPosition.y, transform.position.z) + Random.insideUnitSphere * strength;
            yield return null;
        }
    }

    public void DoShake()
    {
        start = true;
    }
}
