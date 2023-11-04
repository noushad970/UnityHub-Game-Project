using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    public int zPos = 55;
    public bool CreatingSection=false;
    public int SecNum;

    // Update is called once per frame
    void Update()
    {
        if (!CreatingSection)
        {
            CreatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection() {

        SecNum = Random.Range(0, 3);
        Instantiate(sections[SecNum],new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 55;
        yield return new WaitForSeconds(3);
        CreatingSection = false ;
    }

}
