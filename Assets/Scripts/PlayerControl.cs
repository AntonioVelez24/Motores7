using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioSource audioSource;

    private Rigidbody myRigidbody;

    [SerializeField]  private float movementX;
    [SerializeField] private float movementZ;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(movementX != 0 || movementZ != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    private void FixedUpdate()
    {
        myRigidbody.linearVelocity = new Vector3(movementX * speed, myRigidbody.linearVelocity.y, movementZ * speed);
    }
    public void MovementX (InputAction.CallbackContext context)
    {
        movementX = context.ReadValue<float>();
    }
    public void MovementZ(InputAction.CallbackContext context)
    {
        movementZ = context.ReadValue<float>();
    }
}
