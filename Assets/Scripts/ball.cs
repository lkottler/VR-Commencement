using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public static float kickForce = 20f;

    public GameObject stadium;
    private AudioSource kick;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);
        rb.mass = 0.5f;
        kick = gameObject.GetComponent<AudioSource>();
        Physics.IgnoreCollision(stadium.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("Clone"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(-direction * kickForce, ForceMode.Impulse);
            kick.Play();
        }
    }
}
