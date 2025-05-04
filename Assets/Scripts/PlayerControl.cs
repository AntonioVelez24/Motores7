using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private NPCMovement npc;

    private Rigidbody myRigidbody;

    [SerializeField] private float movementX;
    [SerializeField] private float movementZ;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (movementX != 0 || movementZ != 0)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
    private IEnumerator PlayerInteract()
    {
        speed = 0f;
        audioSource.volume = 0f;
        yield return StartCoroutine(npc.Interact());
        yield return new WaitForSeconds(3f);
        audioSource.volume = 0.15f;
        speed = 15f;
    }
    private void FixedUpdate()
    {
        myRigidbody.linearVelocity = new Vector3(movementX * speed, myRigidbody.linearVelocity.y, movementZ * speed);
    }
    public void MovementX(InputAction.CallbackContext context)
    {
        movementX = context.ReadValue<float>();
    }
    public void MovementZ(InputAction.CallbackContext context)
    {
        movementZ = context.ReadValue<float>();
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (Vector3.Distance(transform.position, npc.transform.position) < 2f)
            StartCoroutine(PlayerInteract());
    }
}
