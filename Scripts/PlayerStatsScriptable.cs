using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsScriptable : ScriptableObject
{
    #region Exposed

    [SerializeField] private int m_healthPoint;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpHeight;
    [SerializeField] private float m_iFrameDuration;
	[SerializeField] private int m_score;

	#endregion

	#region Unity API
	#endregion

	#region Main Methods

	public int HealthPoint { get => m_healthPoint; set => m_healthPoint = value; }

	public float MoveSpeed { get => m_moveSpeed; set => m_moveSpeed = value; }

	public float JumpHeight { get => m_jumpHeight; set => m_jumpHeight = value; }

	public float IFrameDuration { get => m_iFrameDuration; set => m_iFrameDuration = value; }

	public int Score { get => m_score; set => m_score = value; }

	#endregion

	#region Privates
	#endregion
}
