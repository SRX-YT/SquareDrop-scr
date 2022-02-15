using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Sprite[] bgSpr;
    [SerializeField] SpriteRenderer spRen;

    private void Start()
    {
        int var = Random.Range(0, 5);
        spRen.sprite = bgSpr[var];
    }
}
