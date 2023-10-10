using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner02 : MonoBehaviour
{
    public GameObject[] AIPrefab;
    public int AItoSpawn;
    private void Start()
    {
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        int count = 0;
        while (count < AItoSpawn)
        {
            int randomIndex = Random.Range(0, AIPrefab.Length);

            GameObject obj = Instantiate(AIPrefab[randomIndex]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<PoliceNPCWayPointNagivator02>().currentWaypoint = child.GetComponent<WayPoint>();

            obj.transform.position = child.position;

            yield return new WaitForSeconds(1f);
            count++;

        }
    }
}
