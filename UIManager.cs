using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreRecordText;

    public void SetScore(int value, int record)
    {
        scoreText.text = value.ToString();
        scoreRecordText.text = record.ToString();
    }
}
