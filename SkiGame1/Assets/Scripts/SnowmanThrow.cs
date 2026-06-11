using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThown = false;

    void Start()
    {

    }

    void Update()
    {
        GameObject target = GameObject.Find("Player");

        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget < throwDistance && justThown == false)
        {
            justThown = true;
            GameObject tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);
            Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
            Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);

            targetDirection += new Vector3(0, 0.33f, 0);
            tempRb.AddForce(targetDirection * throwSpeed);
            Invoke("ThrowOver", 0.1f);
        }
    }

    void ThrowOver()
    {
        justThown = false;
    }
}