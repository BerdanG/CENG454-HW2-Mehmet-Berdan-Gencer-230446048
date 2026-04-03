// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Mehmet Berdan Gençer | Student ID: 230446048

using UnityEditor.Callbacks;
using UnityEngine;


public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; // degrees/second
    [SerializeField] private float yawSpeed = 45f; // degrees/second
    [SerializeField] private float rollSpeed = 45f; // degrees/second
    [SerializeField] private float thrustSpeed = 5f; // units/second
    
    private Rigidbody rb;
    
    
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
    }
 

    void Update()
    {
    HandleRotation();
    HandleThrust();
    }


    private void HandleRotation()
    {
    float pitchInput = Input.GetAxis("Vertical");
    float yawInput   = Input.GetAxis("Horizontal");

    float rollInput = 0f;
    if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
    if (Input.GetKey(KeyCode.E)) rollInput = -1f;

    float pitchAmount = pitchInput * pitchSpeed * Time.deltaTime;
    float yawAmount   = yawInput   * yawSpeed   * Time.deltaTime;
    float rollAmount  = rollInput  * rollSpeed  * Time.deltaTime;

    transform.Rotate(Vector3.right * pitchAmount);
    transform.Rotate(Vector3.up    * yawAmount);
    transform.Rotate(Vector3.forward * rollAmount);
    }
 
 
    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
        float thrustAmount = thrustSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * thrustAmount);
        }
    }
}

