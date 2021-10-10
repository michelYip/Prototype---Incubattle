using UnityEngine;

public class PlayerController : AbstractController
{
    #region Exposed    

    [SerializeField]
    private AnimationCurve _jumpCurve;
    [SerializeField]
    private AnimationCurve _diveCurve;

    [SerializeField]
    private Transform _shadow;

    [SerializeField]
    PlayerStatsScriptable _playerCurrentStatsScriptable;

    [SerializeField]
    PlayerStatsScriptable _playerBaseStatsScriptable;



    #endregion

    #region Unity API

    protected override void Awake()
    {
        _graphics = transform.Find("Graphics").gameObject;    
        _animator = _graphics.GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocity =  Vector2.zero;

        _playerHurt = GetComponent<PlayerHurt>();
        _dustManager = GetComponent<DustManager>();

        _jumpSFX = transform.Find("JumpSFX").GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !_animator.GetBool("IsJumping"))
        {
            _dustManager.EnableJumpDust();
            _jumpSFX.Play();
        }

        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxisRaw("Vertical") / 2.2f;

        if (PlayerCurrentStatsScriptable.HealthPoint == 0)
            _isDead = true;



        if ((Mathf.Abs(_moveX) > 0.3 && Mathf.Abs(_moveX) < 0.35) && !IsJumping)
        {
            _dustManager.EnableSprintDust();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyHitbox"))
        {
            _animator.SetTrigger("HitTrigger");
            if(!_playerHurt.EndHurt)
                _playerCurrentStatsScriptable.HealthPoint--;
        }

        if(collision.CompareTag("ShockwaveHitbox") && !_isJumping)
        {
            _animator.SetTrigger("HitTrigger");
            if (!_playerHurt.EndHurt)
                _playerCurrentStatsScriptable.HealthPoint--;
        }

        if (collision.CompareTag("ScorePickup"))
		{
            Collectible pickup = collision.GetComponent<Collectible>();
            _playerCurrentStatsScriptable.Score += pickup.Value.Value;
            collision.transform.Find("Graphics").GetComponent<SpriteRenderer>().enabled = false;
            collision.transform.Find("Shadow").GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject, 1f);
		}

        if (collision.CompareTag("HealthPickup"))
        {
            Collectible pickup = collision.GetComponent<Collectible>();
            _playerCurrentStatsScriptable.HealthPoint += pickup.Value.Value;
            if (_playerCurrentStatsScriptable.HealthPoint > _playerBaseStatsScriptable.HealthPoint)
			{
                _playerCurrentStatsScriptable.HealthPoint = _playerBaseStatsScriptable.HealthPoint;
            }
            collision.transform.Find("Graphics").GetComponent<SpriteRenderer>().enabled = false;
            collision.transform.Find("Shadow").GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject, 1f);
        }
    }

    #endregion


    #region Main Methods

    public void Move()
    {         
        _animator.SetFloat("MoveX", new Vector2(_moveX, _moveY).magnitude);        
        this.SetVelocity(new Vector2(_moveX, _moveY) * _playerCurrentStatsScriptable.MoveSpeed);        
    }

    public void Jump()
    {
        float max = _jumpCurve.Evaluate(0.5f);        

        if (_chrono < 1f && _isJumping)
        {
            float y = _jumpCurve.Evaluate(_chrono);
            
            _shadow.localScale = new Vector3((max + 0.15f - y) * 10, (max + 0.15f - y) * 6, (max + 0.15f - y) * 2);            

            _graphics.transform.localPosition = new Vector2(_graphics.transform.localPosition.x, y * _playerCurrentStatsScriptable.JumpHeight);

            _animator.SetFloat("Heigth", y);
            _animator.SetTrigger("JumpTrigger");
            _animator.SetBool("IsJumping", true);            
        }
        else
        {
            _isJumping = false;
            _animator.SetBool("IsJumping", false);
            _dustManager.EnableLandDust();
        }

        if(!IsJumping)        
            _chrono = 0;                           
}


    public void Attack()
    {
        _animator.SetTrigger("AttackTrigger");
        _isAttacking = true;
    }

    public void GoToDeath()
    {
        _graphics.transform.position = Vector3.SmoothDamp(_graphics.transform.position, transform.position,ref _smoothVelocity,0.5f);
    }




    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public float Chrono { get => _chrono; set => _chrono = value; }
    public bool IsInvicible { get => _isInvicible; set => _isInvicible = value; }
    public PlayerStatsScriptable PlayerCurrentStatsScriptable { get => _playerCurrentStatsScriptable; set => _playerCurrentStatsScriptable = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }
    public bool IsSprinting { get => _isSprinting; set => _isSprinting = value; }

    #endregion


    #region Private

    private float _moveX;
    private float _moveY;

    private float _chrono = 0;

    private bool _isJumping = false;
    private bool _isInvicible = false;
    private bool _isDead = false;
    private bool _isSprinting = false;
    private bool _isSmoking = false;

    private PlayerHurt _playerHurt;
    private Vector3 _smoothVelocity;
    private DustManager _dustManager;

    private AudioSource _jumpSFX;

    #endregion
}
