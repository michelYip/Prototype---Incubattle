using UnityEngine;

public class PlayerHurt : MonoBehaviour, StateInterface
{
    #region Exposed

    [SerializeField] private GameObject m_hitEffect;

    #endregion

    #region Unity API
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _hurtSFX = transform.Find("HurtSFX").GetComponent<AudioSource>();
    }

    #endregion

    #region Main Methods

    public void DoInit()
    {        
        if (_playerController.Chrono < 0.5 && _playerController.IsJumping)
        {
            _playerController.Chrono += (0.5f - _playerController.Chrono) * 2;
        }

        m_hitEffect.SetActive(false);
        m_hitEffect.SetActive(true);

        _hurtSFX.Play();
    }

    public void DoUpdate()
    {
    }

    public void DoExit()
    {
        _endHurt = true;        
    }

    #endregion


    #region Privates

    private PlayerController _playerController;
    private float _invicibilityChrono = 0;
    private bool _endHurt = false;

    private AudioSource _hurtSFX;

    public float InvicibilityChrono { get => _invicibilityChrono; set => _invicibilityChrono = value; }
    public bool EndHurt { get => _endHurt; set => _endHurt = value; }

    #endregion
}