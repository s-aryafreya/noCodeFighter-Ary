using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    
    //enemies instantiate, almost random where, regular spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //name of func as string, delay, interval (by second)
        InvokeRepeating("CreateEnemyOne", 1f, 2f);
        InvokeRepeating("CreateEnemyTwo", 3f, 3f);
    }

    void CreateEnemyOne()
    {
        //needs: 1. obj 2. location 3. rotation
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0f), Quaternion.identity);
    }
    void CreateEnemyTwo()
    {
        //needs: 1. obj 2. location 3. rotation
        // Change Random.Range(-9f, 9f) to something slightly tighter like (-7f, 7f)
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-7f, 7f), 6.5f, 0f), Quaternion.identity);
    }
}
