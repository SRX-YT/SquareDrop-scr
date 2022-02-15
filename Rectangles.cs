using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Rectangles : MonoBehaviour
{
    private float speed = 4.1f;
    private Vector3 player;
    [SerializeField] GameObject explosionParticles;
    private Shake shakeScript;
    [SerializeField] SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        player = GameObject.Find("Player").transform.position;
        shakeScript = GameObject.Find("Main Camera").GetComponent<Shake>();
        FindPath();
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(-speed, 0) * Time.fixedDeltaTime);
        CheckScale();
    }

    private void FindPath()
    {
        Vector3 direction = new Vector3(Random.Range(-1.65f, 1.65f), -0.25f) - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(direction);
        this.transform.Rotate(new Vector3(0, 90, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Wall")
        {
            DestroyRect(this.gameObject);
        }
    }

    private void CheckScale()
    {
        if (transform.localScale == Vector3.zero)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyRect(GameObject rect)
    {
        soundManager.PlayDestroy();
        rect.transform.DOScale(0, 0.25f);
        shakeScript.DoShake();
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
    }
}
