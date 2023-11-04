using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    string parentName;
    public GameObject player;
    public GameObject clone;
    
    private void Start()
    {
        parentName = transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 clonePosition = clone.transform.position;

        if (playerPosition.z > clonePosition.z+55 && parentName=="Section(Clone)")
        {
            StartCoroutine(DestroyObj());
        }


    }
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
