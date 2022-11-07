using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public Light light_1;
    public Light light_2;

    public float speed;
    public float rotationSpeed;

    private Rigidbody rb;
    private AudioSource horn;
    private bool hornState;


    void Start()
    {
        speed *= Time.deltaTime;
        rotationSpeed *= Time.deltaTime;
        hornState = false;
        rb = GetComponent<Rigidbody>();
        horn = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hornState)
        {
            horn.mute = false;
        }
        else
        {
            horn.mute = true;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            hornState = true;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            hornState = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.transform.Translate(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.transform.Translate(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Rotate(0f, -rotationSpeed, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Rotate( 0f, rotationSpeed, 0f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tunnel"))
        {
            light_1.enabled = true;
            light_2.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tunnel"))
        {
            light_1.enabled = false;
            light_2.enabled = false;
        }
    }
}
