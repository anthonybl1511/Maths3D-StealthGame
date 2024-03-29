using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    public static PlayerMovement instance;

    [SerializeField] private AudioSource audioSource;

    private bool isSeen;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rb.MovePosition(transform.position + ((movement.y * transform.forward) + (movement.x * transform.right)) * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetIsSeen(bool seen)
    {
        isSeen = seen;
    }

    public bool GetIsSeen()
    {
        return isSeen;
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
