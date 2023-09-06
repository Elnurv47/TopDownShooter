using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORİZONTAL_AXİS = "Horizontal";
    private const string VERTİCAL_AXİS = "Vertical";
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis(HORİZONTAL_AXİS);
        float inputY = Input.GetAxis(VERTİCAL_AXİS);
        movement = new Vector2(inputX, inputY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
