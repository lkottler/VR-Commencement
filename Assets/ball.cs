using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject stadium;
    private float kickForce = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(stadium.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("Clone"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(-direction * kickForce, ForceMode.Impulse);
        }
    }
}
