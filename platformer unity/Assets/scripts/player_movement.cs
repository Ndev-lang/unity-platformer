using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    private Rigidbody2D _rigidbody;
    private Transform flip;
    private Animator ani;
    public int apple = 0;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        flip = GetComponent<Transform>();
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "itens")
        {
            Destroy(collision.gameObject);
            apple += 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        if (movement > 0)
        {
            flip.localScale = new Vector2(1, 1);
            ani.Play("player_run");

        }
        else if (movement < 0)
        {
            flip.localScale = new Vector2(-1, 1);
            ani.Play("player_run");
        }
        else
        {
            ani.Play("player_Idle");
        }
        if (Input.GetButtonDown("Vertical") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
