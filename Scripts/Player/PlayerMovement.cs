using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    // 이동할 위치 설정
    private float[] positions = { -1.75f, 0f, 1.75f };
    private int currentIndex = 1; // 초기 위치는 중앙(0)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Constraints 설정 확인 (회전 고정)
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        // 캐릭터가 시작하면 자동으로 앞으로 움직이도록 초기 속도 설정
        Vector3 forwardMove = new Vector3(0f, 0f, moveSpeed * Time.fixedDeltaTime);
        transform.Translate(forwardMove);
    }

    void Move()
    {
        float moveInput = InputManager.instance.GetHorizontalInput();

        if (moveInput < 0 && currentIndex > 0) // 왼쪽으로 이동
        {
            currentIndex--; // 인덱스 감소, 최소값은 0
        }
        else if (moveInput > 0 && currentIndex < positions.Length - 1) // 오른쪽으로 이동
        {
            currentIndex++; // 인덱스 증가, 최대값은 positions.Length - 1
        }

        // 목표 위치로 이동
        Vector3 targetPosition = new Vector3(positions[currentIndex], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("Collision with Object tagged object detected");
            GameManager.instance.GameOver();
        }
    }
}
