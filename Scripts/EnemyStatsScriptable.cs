using UnityEngine;

[CreateAssetMenu]
public class EnemyStatsScriptable : ScriptableObject
{
	#region Exposed

	[SerializeField] private int m_healthPoint;
	[SerializeField] private float m_moveSpeed;

	#endregion

	#region Unity API
	#endregion

	#region Main Methods

	public int HealthPoint { get => m_healthPoint; set => m_healthPoint = value; }

	public float MoveSpeed { get => m_moveSpeed; set => m_moveSpeed = value; }

	#endregion

	#region Privates
	#endregion
}
