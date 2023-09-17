using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager instance;

    [SerializeField]
    private GameObject boar_prefab,Canibal_prefab;

    public Transform[] canibal_spawn_Point, Boar_spawnPoint;

    [SerializeField]
    private int Canibal_Enemy_Count, Boar_Enemy_Count;

    private int initial_canibal_count, initial_boar_count;

    public float wait_before_spawn_enemies_time = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        initial_canibal_count = Canibal_Enemy_Count;
        initial_boar_count = Boar_Enemy_Count;
        SpawnEnemies();
        StartCoroutine("CheckToSpawnEnemies");

    }

    // Update is called once per frame
    void MakeInstance()
    {
        if(instance == null) {
            instance = this;
        }
    }
    void SpawnEnemies()
    {
        SpawnCanibal();
        SpawnBoar();
    }
    //void CheckToSpawnEnemies()
    //{

    //}
    void SpawnCanibal()
    {
        int index = 0;
        for(int i = 0; i < Canibal_Enemy_Count;i++) {

            if(index>=canibal_spawn_Point.Length)
            {
                index = 0;
            }
            Instantiate(Canibal_prefab, canibal_spawn_Point[index].position,Quaternion.identity);
            index++;
        }
        Canibal_Enemy_Count = 0;
    }
    void SpawnBoar()
    {

        int index = 0;
        for (int i = 0; i < Boar_Enemy_Count; i++)
        {

            if (index >= Boar_spawnPoint.Length)
            {
                index = 0;
            }
            Instantiate(boar_prefab, Boar_spawnPoint[index].position, Quaternion.identity);
            index++;
        }
        Boar_Enemy_Count = 0;
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_before_spawn_enemies_time);
        SpawnBoar();
        SpawnCanibal();
        StartCoroutine("CheckToSpawnEnemies");
    }
    public void EnemyDied(bool cannibal)
    {
        if(cannibal)
        {
            Canibal_Enemy_Count++;
            if(Canibal_Enemy_Count>initial_canibal_count)
            {
                Canibal_Enemy_Count=initial_canibal_count;
            }
        }
        else
        {
            Boar_Enemy_Count++;
            if (Boar_Enemy_Count > initial_boar_count)
            {
                Boar_Enemy_Count = initial_boar_count;
            }
        }
    }
    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
}
















