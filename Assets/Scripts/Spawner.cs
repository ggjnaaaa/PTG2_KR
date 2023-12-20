using UnityEngine;
using UnityEngine.UI;

//~~~~~~    ������ �������� �����    ~~~~~~//
public class Spawner : MonoBehaviour
{
    //~~~~~~    ������ �� ���� � ������ �����    ~~~~~~//
    public GameObject monster;
    public GameObject target;
    public Text counter;

    float spawnTime;
    float minSpawnTime;
    float currentTime;

    void Start()
    {
        spawnTime = 2;
        minSpawnTime = 1;
        currentTime = 0;
    }

    void LateUpdate()
    {
        //~~~~~~    ��������� �����    ~~~~~~//
        currentTime += Time.deltaTime;

        if(currentTime > spawnTime)
        {
            GameObject mons = Instantiate(monster, transform.position, Quaternion.identity);
            Smilr smile = mons.GetComponent<Smilr>();
            smile.target = target;
            smile.counter = counter;

            currentTime = 0;

            if (spawnTime > minSpawnTime)
                spawnTime -= 0.1f;
            else
                spawnTime = minSpawnTime;
        }
    }
}
