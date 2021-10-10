using UnityEngine;

public class BossSpecialState : MonoBehaviour, StateInterface
{
    #region Exposed

    [Header("Triple Shockwave Attributes")]
    [SerializeField] private GameObject m_bigShockwave;
    [SerializeField] private float m_shockwaveDuration;

    [Space(10)]
    [Header("Ground Slam Attributes")]
    [SerializeField] private float m_groundSlamDuration;
    [SerializeField] private AnimationCurve m_jumpHeight;


    #endregion

    #region Unity API
    void Awake()
    {
        _bossController = GetComponent<BossController>();
        _graphics = transform.Find("Graphics");
    }
    #endregion

    #region Main Methods

    public void DoInit()
    {
        _bossController.DoSpecialAttack = false;
        _specialID = Random.Range(0, 2);
        _bossController.SetVelocity(Vector2.zero);
        if (_specialID == 0)
		{
            _shockwaveStartTime = Time.time;
            _bossController.SetTrigger("SlamTrigger");
        }
        if (_specialID == 1)
		{
            _groundSlamStartTime = Time.time;
            _start = transform.position;
            _destination = _bossController.GetDestination();
        }
        _specialDone = false;
    }

    public void DoUpdate()
    {
        float alpha = 0f;
        if (_specialID == 0)
		{
            _bossController.SetVelocity(Vector2.zero);
            alpha = (Time.time - _shockwaveStartTime) / m_shockwaveDuration;
            _bossController.SetTrigger("SlamTrigger");
        }
        else if (_specialID == 1)
		{
            _bossController.SetTrigger("SlamTrigger");
            alpha = (Time.time - _groundSlamStartTime) / m_groundSlamDuration;
            transform.position = Vector2.Lerp(_start, _destination, alpha);
            _graphics.localPosition = new Vector2(_graphics.localPosition.x, m_jumpHeight.Evaluate(alpha));
        }
        if (alpha > 1f)
		{
            _specialDone = true;
		}
    }

    public void DoExit()
    {
        _bossController.DoSpecialAttack = false;
    }

    public void CreateShockwaves()
	{
        if (_specialID == 0)
		{
            ShockwaveController shockwave1 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            shockwave1.SetDirection(new Vector2(-1, 0.5f));
            //ShockwaveController shockwave2 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            //shockwave2.SetDirection(new Vector2(-1, 0));
            ShockwaveController shockwave3 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            shockwave3.SetDirection(new Vector2(-1, -0.5f));
            ShockwaveController shockwave4 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            shockwave4.SetDirection(new Vector2(1, 0.5f));
            //ShockwaveController shockwave5 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            //shockwave5.SetDirection(new Vector2(1, 0));
            ShockwaveController shockwave6 = Instantiate(m_bigShockwave, transform.position, m_bigShockwave.transform.rotation).GetComponent<ShockwaveController>();
            shockwave6.SetDirection(new Vector2(1, -0.5f));
        }
        
    }

    public bool SpecialDone { get => _specialDone; set => _specialDone = value; }

    #endregion

    #region Privates

    private BossController _bossController;

    private int _specialID;

    private float _shockwaveStartTime;

    private Transform _graphics;
    private Vector2 _start;
    private Vector2 _destination;
    private float _groundSlamStartTime;

    private bool _specialDone;

	#endregion
}