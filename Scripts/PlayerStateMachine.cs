using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : AbstractStateMachine
{
    #region Exposed



    #endregion


    #region Unity API

    protected override void Awake()
    {
        base.Awake();

        _playerController = GetComponent<PlayerController>();

        _playerAttack = GetComponent<PlayerAttack>();
        _playerDie = GetComponent<PlayerDie>();
        _playerDive = GetComponent<PlayerDive>();
        _playerHurt = GetComponent<PlayerHurt>();
        _playerJump = GetComponent<PlayerJump>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        _playerSpecial = GetComponent<PlayerSpecial>();
        _playerTaunt = GetComponent<PlayerTaunt>();
        _playerThrow = GetComponent<PlayerThrow>();
    }

    #endregion


    #region Main Methods

    protected override void OnStateEnter()
    {
        switch (_currentState)
        {
            case State.ATTACK:
                GetComponent<PlayerAttack>().DoInit();
                break;


            case State.DIE:
                GetComponent<PlayerDie>().DoInit();
                break;


            case State.DIVE:
                GetComponent<PlayerDive>().DoInit();
                break;


            case State.HURT:

                isHoldingCan = false;

                if (_playerController.PlayerCurrentStatsScriptable.HealthPoint <= 0)
                    TransitionToState(State.DIE);

                GetComponent<PlayerHurt>().DoInit();
                break;


            case State.JUMP:
                GetComponent<PlayerJump>().DoInit();
                break;


            case State.LOCOMOTION:                
                GetComponent<PlayerLocomotion>().DoInit();
                break;


            case State.TAUNT:
                GetComponent<PlayerTaunt>().DoInit();
                break;


            case State.THROW:
                isHoldingCan = false;
                GetComponent<PlayerThrow>().DoInit();
                break;


            case State.SPECIAL:
                isHoldingCan = false;
                GetComponent<PlayerSpecial>().DoInit();
                break;


            case State.PICKUP:
                isHoldingCan = true;
                break;
            default:
                break;
        }
    }




    protected override void OnStateUpdate()
    {
        //Debug.Log(_currentState);
        switch (_currentState)
        {
            case State.ATTACK:
                _playerAttack.DoUpdate();

                if (_playerController.IsDead)
                    TransitionToState(State.DIE);

                if (_playerController.IsInvicible && !_playerHurt.EndHurt)
                    TransitionToState(State.HURT);

                if (!_playerController.GetAttack() && !_playerController.IsJumping)
                    TransitionToState(State.LOCOMOTION);

                if (!_playerController.GetAttack() && _playerController.IsJumping)
                    TransitionToState(State.JUMP);

                if (Input.GetButtonDown("Fire1"))                
                    TransitionToState(State.ATTACK);


                if (_playerHurt.EndHurt)
                {
                    _playerHurt.InvicibilityChrono += Time.deltaTime;
                }

                break;


            case State.DIE:
                _playerDie.DoUpdate();
                break;


            case State.DIVE:
                _playerDive.DoUpdate();
                break;


            case State.HURT:

                if (_playerController.IsDead)
                    TransitionToState(State.DIE);

                if (!_playerController.IsJumping)
                    TransitionToState(State.LOCOMOTION);

                if (_playerController.IsJumping)
                    TransitionToState(State.JUMP);

                _playerHurt.DoUpdate();
                break;


            case State.JUMP:

                if (_playerHurt.InvicibilityChrono >= _playerController.PlayerCurrentStatsScriptable.IFrameDuration)
                {
                    _playerController.ResetTrigger("HitTrigger");
                    _playerController.IsInvicible = false;
                    _playerController.SetBool("IsInvincible", false);
                    _playerHurt.EndHurt = false;
                    _playerHurt.InvicibilityChrono = 0;
                }

                if (_playerController.IsDead)
                    TransitionToState(State.DIE);

                if (_playerHurt.EndHurt)
                {
                    _playerHurt.InvicibilityChrono += Time.deltaTime;
                }

                if (_playerController.IsInvicible && !_playerHurt.EndHurt)
                    TransitionToState(State.HURT);

                if (!_playerController.IsJumping)
                    TransitionToState(State.LOCOMOTION);

                if (Input.GetButtonDown("Fire1"))
                {
                    TransitionToState(State.ATTACK);
                }
                _playerJump.DoUpdate();

                break;


            case State.LOCOMOTION:

                if (_playerHurt.InvicibilityChrono >= _playerController.PlayerCurrentStatsScriptable.IFrameDuration)
                {
                    _playerController.ResetTrigger("HitTrigger");
                    _playerController.IsInvicible = false;
                    _playerController.SetBool("IsInvincible", false);
                    _playerHurt.EndHurt = false;
                    _playerHurt.InvicibilityChrono = 0;
                }

                if (_playerController.IsDead)
                    TransitionToState(State.DIE);

                if (_playerHurt.EndHurt)
                {
                    _playerHurt.InvicibilityChrono += Time.deltaTime;
                }
                if (_playerController.IsInvicible && !_playerHurt.EndHurt)
                    TransitionToState(State.HURT);

                if (Input.GetButtonDown("Jump"))
                {
                    TransitionToState(State.JUMP);
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    TransitionToState(State.ATTACK);
                }

                _playerLocomotion.DoUpdate();

                break;


            case State.TAUNT:

                if (_playerController.IsInvicible)
                    TransitionToState(State.HURT);

                _playerTaunt.DoUpdate();
                break;


            case State.THROW:
                _playerThrow.DoUpdate();
                break;


            case State.SPECIAL:
                _playerSpecial.DoUpdate();
                break;


            default:
                break;
        }
    }



    protected override void OnStateExit()
    {
        switch (_currentState)
        {
            case State.ATTACK:
                GetComponent<PlayerAttack>().DoExit();                
                break;

            case State.DIE:
                GetComponent<PlayerDie>().DoExit();
                break;

            case State.DIVE:
                GetComponent<PlayerDive>().DoExit();
                break;

            case State.HURT:
                GetComponent<PlayerHurt>().DoExit();
                break;

            case State.JUMP:
                GetComponent<PlayerJump>().DoExit();
                break;

            case State.LOCOMOTION:
                GetComponent<PlayerLocomotion>().DoExit(); 
                break;

            case State.TAUNT:
                GetComponent<PlayerTaunt>().DoExit();
                break;

            case State.THROW:
                GetComponent<PlayerThrow>().DoExit();
                break;

            case State.SPECIAL:
                GetComponent<PlayerSpecial>().DoExit();
                break;

            default:
                break;
        }
    }

    #endregion


    #region Privates

    private PlayerAttack _playerAttack;
    private PlayerDie _playerDie;
    private PlayerDive _playerDive;
    private PlayerHurt _playerHurt;
    private PlayerJump _playerJump;
    private PlayerLocomotion _playerLocomotion;
    private PlayerTaunt _playerTaunt;
    private PlayerThrow _playerThrow;
    private PlayerSpecial _playerSpecial;

    private PlayerController _playerController;

    private bool isHoldingCan = false;    
    #endregion
}