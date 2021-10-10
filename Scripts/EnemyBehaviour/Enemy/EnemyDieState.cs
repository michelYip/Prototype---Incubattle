using UnityEngine;

public class EnemyDieState : MonoBehaviour, StateInterface
{
	#region Exposed

	[SerializeField] private GameObject[] m_loots;
	[SerializeField] private int m_numberOfLoots;

	[SerializeField] private float m_despawnDuration = 2f;

	#endregion

	#region Unity API
	void Awake()
	{
		_enemyController = GetComponent<EnemyController>();
		_despawnTimer = Time.time;
	}
	#endregion

	#region Main Methods

	public void DoInit()
	{
		_enemyController.SetVelocity(Vector2.zero);
		_enemyController.SetTrigger("DeadTrigger");
		GetComponent<Collider2D>().enabled = false;

		_despawnTimer = Time.time + m_despawnDuration;

		for (int i = 0; i < m_numberOfLoots; i++)
		{
			int randomIndex = Random.Range(0, m_loots.Length);
			LootSpawn newLoot = Instantiate(m_loots[randomIndex], transform.position, m_loots[randomIndex].transform.rotation).GetComponent<LootSpawn>();
			newLoot.Start = transform.position;
			newLoot.Destination = (Vector2)transform.position + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		}
	}

	public void DoUpdate()
	{
		if (Time.time > _despawnTimer)
		{
			Destroy(gameObject);
		}
	}

	public void DoExit()
	{
	}


	#endregion

	#region Privates

	private EnemyController _enemyController;
	private float _despawnTimer;

	#endregion
}