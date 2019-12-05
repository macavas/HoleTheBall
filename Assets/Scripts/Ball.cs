
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 30;
    public float ballMultiplier = 1.5f;
    public LineRenderer barrel;

    private Rigidbody2D rb;
    private Vector3 startFingerPos;

    BallState state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        state = BallState.Idle;
        barrel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && state == BallState.Idle && (Input.mousePosition.y / Screen.height) < .8f && UIManager.instance.isInGameMode)
        {
            startFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            state = BallState.Holding;
            barrel.gameObject.SetActive(true);
            barrel.SetPosition(0, transform.position);
        }
        else if(Input.GetMouseButtonUp(0) && state == BallState.Holding)
        {
            ThrowBall();
        }
        else if(state == BallState.Moving)
        {
            CheckSpeed();
        }

        if(state == BallState.Holding)
        {
            Vector3 endFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = (startFingerPos - endFingerPos);
            if (direction.magnitude > ballMultiplier) direction = direction.normalized * ballMultiplier;
            barrel.SetPosition(1, transform.position + direction);
        }
    }

    private void ThrowBall()
    {
        state = BallState.Moving;
        barrel.gameObject.SetActive(false);
        Vector3 ballPos = transform.position;
        Vector3 endFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (startFingerPos - endFingerPos);

        if (direction.magnitude > ballMultiplier) direction = direction.normalized * ballMultiplier;


        rb.velocity = direction * moveSpeed;
    }
    private void CheckSpeed()
    {
        if(rb.velocity.magnitude <= 0.05f)
        {
            state = BallState.Fail;
            LevelManager.instance.FailLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hole"))
        {
            gameObject.SetActive(false);
            LevelManager.instance.WinLevel();
        }
    }

    enum BallState { Idle, Moving, Holding, Fail}
}
