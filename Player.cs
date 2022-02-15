using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            gameManager.Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            gameManager.GameOver();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "Color")
        {
            gameManager.GetPoint();
            Destroy(collision.gameObject);
        }
    }
}
