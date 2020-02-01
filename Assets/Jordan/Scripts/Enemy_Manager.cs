using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    public GameObject enemy_prefab;
    public List<GameObject> enemyList;

    float elapsedTime;
    const float WAVE_DELAY = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= WAVE_DELAY)
        {
            elapsedTime = elapsedTime % WAVE_DELAY;
            CreateEnemy();
        }
    }

    void CreateEnemy ()
    {
        enemyList.Add(Instantiate(enemy_prefab, new Vector3(5.5f, 6.0f, -88), Quaternion.identity));
    }
}
