using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBowScript : MonoBehaviour
{
    private Rigidbody MyBody;
    public float speed = 20f;
    public float deactivor_time = 3f;
    public float damage = 50f;

    void Awake()
    {
    MyBody=GetComponent<Rigidbody>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivatedGameObject", deactivor_time);
    }
    public void launch(Camera mainCamera)
    {
        MyBody.velocity = mainCamera.transform.forward*speed;
        transform.LookAt(transform.position+ MyBody.velocity);
    }
    void DeactivatedGameObject()
    {
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider Target)
    {
        if(Target.tag==Tags.Enemy_Tag) { 
        Target.GetComponent<HealthScript>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
