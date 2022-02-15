using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RestartManager : MonoBehaviour
{
    private GameObject[] remainingRect;
    [SerializeField] InterstitialAdExample adScr;
    private int adRem;

    private void Start()
    {
        this.transform.DOScale(Vector3.one, 0.5f);
        DestroyRem();
        CheckAds();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void DestroyRem()
    {
        remainingRect = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < remainingRect.Length; i++)
        {
            var script = remainingRect[i].GetComponent<Rectangles>();
            script.DestroyRect(remainingRect[i]);
        }

        remainingRect = GameObject.FindGameObjectsWithTag("Color");
        for (int i = 0; i < remainingRect.Length; i++)
        {
            if (remainingRect[i].name == "pointrectangle(Clone)")
            {
                var script = remainingRect[i].GetComponent<Rectangles>();
                script.DestroyRect(remainingRect[i]);
            }
        }
    }

    private void CheckAds()
    {
        adRem = PlayerPrefs.GetInt("adRem");
        adRem += 1;
        PlayerPrefs.SetInt("adRem", adRem);
        if (adRem == 10)
        {
            adScr.LoadAd();
            adScr.ShowAd();
            adRem = 0;
            PlayerPrefs.SetInt("adRem", adRem);
        }
    }
}
