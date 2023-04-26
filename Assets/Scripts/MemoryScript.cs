using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryScript : MonoBehaviour
{
    public float amplitude = 1f; // Set the amplitude of the object's movement
    public float speed = 1f; // Set the speed of the object's movement
    public float rotationSpeed = 1f; // Set the speed of the object's rotation
    private Vector3 startPos; // Store the object's initial position

    void Start()
    {
        startPos = transform.position; // Set the object's initial position
    }


    void Update()
    {
        // Move the object up and down on a loop using a sine wave
        float y = startPos.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Rotate the object continuously
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter() {
        SceneManager.LoadScene("HomeScreen");
    }
}
