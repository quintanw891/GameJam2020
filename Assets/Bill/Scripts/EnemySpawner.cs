using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<Enemy> spawnedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = new List<Enemy>();
        foreach (Transform enemyTransform in transform.Find("Enemies"))
        {
            GameObject enemyObject = enemyTransform.gameObject;
            enemyObject.SetActive(true);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            spawnedEnemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=spawnedEnemies.Count - 1; i>=0; i--)
        {
            Enemy enemy = spawnedEnemies[i];
            if (enemy.transform.position.y <= enemy.ground.transform.position.y)
            {
                enemy.healthController.GetComponent<HealthController>().health--;
                enemy.gameObject.SetActive(false);
                spawnedEnemies.RemoveAt(i);
            }
        }
    }
}
