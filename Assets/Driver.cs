using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 90f;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float speedDown = 3f;
    [SerializeField] float speedUp = 12f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started!");
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount );
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "SpeedUp") {
            moveSpeed = speedUp;
        } 
        else if (other.name == "SpeedDown") {
            moveSpeed = speedDown;
        }
    }
}
