using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ForCube : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody rb;
    public float force = 10f;
    public int a;
    public int b;
    public int c;
    public GameObject capsule;
    public Text x;
    public GameObject cam;
    public GameObject bcam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = 100;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * 5 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 5 * Speed * Time.deltaTime);
        }


        if (c <= 0)
        {
            cam.SetActive(true);
            bcam.SetActive(false);
            this.gameObject.SetActive(false);
            x.text = "Конец игры";
        }
        else x.text = c.ToString();
        
    }
    private void OnMouseDown()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
    private void OnMouseEnter()
    {
        capsule.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    private void OnMouseExit()
    {
        capsule.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CEN");
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        c--;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CET");
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("CS");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TE");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TX");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("CS");
    }
    public void heal()
    {
        c = c + 10;
    }
}
