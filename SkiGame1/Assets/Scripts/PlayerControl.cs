using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    private InputAction move;
    [SerializeField] private float turnSpeed = 10;
    [SerializeField] private float speed = 10;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Vector3 obstacleKnockback;
    private Rigidbody rb;

    private bool canMove = true;

    private void OnEnable()
    {
        Obstacle.OnObstacleHit += OnCollision;
    }

    private void OnDisable()
    {
        Obstacle.OnObstacleHit -= OnCollision;
    }

    private void OnCollision()
    {
        Debug.Log("Collision");
        rb.AddForce(obstacleKnockback, ForceMode.Impulse);
        canMove = false;
        Invoke("AllowMove", 2);
    }

    private void AllowMove()
    {
        canMove = true;
    }

    private void Awake()
    {
        Instance = this;
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        bool isGrounded = Physics.Linecast(transform.localPosition, transform.position - Vector3.up, ground);
        if (isGrounded)
        {
            Vector2 moveVector = move.ReadValue<Vector2>();
            float rotateSpeed = -moveVector.x * turnSpeed * Time.fixedDeltaTime;
            rb.AddTorque(new Vector3(0, rotateSpeed, 0));
        }

        float speedMultipiler = Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * transform.localEulerAngles.y));
        rb.AddForce(transform.forward * speed * speedMultipiler * Time.fixedDeltaTime);

        ClampRotation();
    }

    private void ClampRotation()
    {
        float y = transform.localEulerAngles.y;

        if (y < 90f || y > 270f)
        {
            float clampedY = (y <= 180f) ? 90f : 270f;
            rb.rotation = Quaternion.Euler(0, clampedY, 0);
            Vector3 av = rb.angularVelocity;
            av.y = 0;
            rb.angularVelocity = av;
        }
    }
}