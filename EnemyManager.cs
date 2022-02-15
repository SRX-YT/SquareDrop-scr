using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject friendly;
    private float timeBtwSpawn = 0.85f;
    private float timeNow = 0;
    bool canSpawn = true;

    private void FixedUpdate()
    {
        if (canSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if ((timeNow += Time.fixedDeltaTime) >= timeBtwSpawn)
        {
            float randomX = Random.Range(-2, 2);
            int friendlyChance = Random.Range(1, 5);
            if (friendlyChance == 1)
            {
                Instantiate(friendly, new Vector3(randomX, 6), Quaternion.identity);
                timeNow = 0;
            } else
            {
                Instantiate(enemy, new Vector3(randomX, 6), Quaternion.identity);
                timeNow = 0;
            }
        }
    }
}
