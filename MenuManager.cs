using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text scoreText;
    [SerializeField] Text recordText;
    [SerializeField] GameObject enemyManager;

    private void Update()
    {
        MoveTitleText();
        if (this.transform.localScale == Vector3.zero)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void PlayButton()
    {
        enemyManager.SetActive(true);
        scoreText.gameObject.SetActive(true);
        recordText.gameObject.SetActive(true);
        scoreText.transform.DOScale(Vector3.one, 1);
        recordText.transform.DOScale(Vector3.one, 1);
        this.transform.DOScale(Vector3.zero, 0.5f);
    }

    public void ExitButton()
    {

    }

    private void MoveTitleText()
    {
        if (titleText.transform.localScale == new Vector3(1, 1, 1))
        {
            titleText.transform.DOScale(0.9f, 1);
        }
        if (titleText.transform.localScale == new Vector3(0.9f, 0.9f, 0.9f))
        {
            titleText.transform.DOScale(1, 1);
        }
    }
}
