using System.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] GameObject[] gameObj;
    private float _HSV;

    private void Start()
    {
        GenerateColor();
        StartColor();
    }

    private void GenerateColor()
    {
        _HSV = Random.Range(0.01f, 0.99f);
    }

    public void NextColor()
    {
        _HSV += Random.Range(0.05f, 0.25f);
        CheckColorLim();
        for (int i = 0; i < gameObj.Length; i++)
        {
            if (gameObj[i].name != "Main Camera")
            {
                var sprite = gameObj[i].GetComponent<SpriteRenderer>();
                Color.RGBToHSV(sprite.color, out float _H, out float _S, out float _V);
                StartCoroutine(LerpColorsSprites(sprite, _S, _V));
            }
            else
            {
                var sprite = gameObj[i].GetComponent<Camera>();
                Color.RGBToHSV(sprite.backgroundColor, out float _H, out float _S, out float _V);
                StartCoroutine(LerpColorsCamera(sprite, _S, _V));
            }
        }
    }

    public void StartColor()
    {
        _HSV += 0.16f;
        CheckColorLim();
        for (int i = 0; i < gameObj.Length; i++)
        {
            if (gameObj[i].name != "Main Camera")
            {
                var sprite = gameObj[i].GetComponent<SpriteRenderer>();
                Color.RGBToHSV(sprite.color, out float _H, out float _S, out float _V);
                sprite.color = Color.Lerp(sprite.color, Color.HSVToRGB(_HSV, _S, _V), 1);
            }
            else
            {
                var sprite = gameObj[i].GetComponent<Camera>();
                Color.RGBToHSV(sprite.backgroundColor, out float _H, out float _S, out float _V);
                sprite.backgroundColor = Color.Lerp(sprite.backgroundColor, Color.HSVToRGB(_HSV, _S, _V), 1);
            }
        }
    }

    private void CheckColorLim()
    {
        if (_HSV >= 1) {
            GenerateColor();
        }
    }

    private IEnumerator LerpColorsCamera(Camera sprite, float _S, float _V)
    {
        float elapsedTime = 0.0f;
        float totalTime = 3.0f;
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            sprite.backgroundColor = Color.Lerp(sprite.backgroundColor, Color.HSVToRGB(_HSV, _S, _V), (elapsedTime / totalTime));
            yield return null;
        }
    }
    private IEnumerator LerpColorsSprites(SpriteRenderer sprite, float _S, float _V)
    {
        float elapsedTime = 0.0f;
        float totalTime = 3.0f;
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            sprite.color = Color.Lerp(sprite.color, Color.HSVToRGB(_HSV, _S, _V), (elapsedTime / totalTime));
            yield return null;
        }
    }
}