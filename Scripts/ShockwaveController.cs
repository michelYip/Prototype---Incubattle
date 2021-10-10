using UnityEngine;

public class ShockwaveController : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float m_shockwaveSpeed = 1f;

	#endregion

	#region Unity API

	private void Awake()
	{
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = Vector2.zero;
        _lifeTimeTimer = Time.time + _lifeTimeDuration;
	}

	private void Update()
	{
        if (_direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Time.time > _lifeTimeTimer)
		{
            Destroy(gameObject);
		}
    }

	private void FixedUpdate()
    {
        _rigidbody2D.velocity += _direction * m_shockwaveSpeed * Time.fixedDeltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Environment"))
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
	}

	#endregion

	#region Main Methods

	public void SetDirection(Vector2 newDir)
	{
        _direction = newDir;
	}

    #endregion

    #region Privates

    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;

    private float _lifeTimeDuration = 20f;
    private float _lifeTimeTimer;


    #endregion
}
