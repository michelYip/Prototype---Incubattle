using UnityEngine;

public class LootSpawn : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float m_despawnDuration = 10f;
    [SerializeField] private float m_travelDuration = 1f;

    [SerializeField] private AnimationCurve m_height;

    #endregion

    #region Unity API
    void Awake()
    {
        _despawnTimer = Time.time + m_despawnDuration;
        _graphics = transform.Find("Graphics");
        _startTime = Time.time;

        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float alpha = (Time.time - _startTime) / m_travelDuration;
        transform.position = Vector2.Lerp(_start, _destination, alpha);
        _graphics.localPosition = new Vector2(_graphics.localPosition.x, m_height.Evaluate(alpha));

        if (alpha < 1f)
            _collider.enabled = false;
        else
            _collider.enabled = true;

        if (Time.time > _despawnTimer)
		{
            Destroy(gameObject);
		}
    }
    #endregion

    #region Main Methods
    public Vector2 Start { get => _start; set => _start = value; }
    public Vector2 Destination { get => _destination; set => _destination = value; }

    #endregion

    #region Privates

    private Vector2 _start;
    private Vector2 _destination;

    private float _despawnTimer;
    private Transform _graphics;
    private float _startTime;

    private Collider2D _collider;

	#endregion
}
