using System.Collections.Generic;
using UnityEngine;

public class SearchObjects : MonoBehaviour
{
	#region Exposed

	[SerializeField] private float m_detectionRadius = 30f;
	[SerializeField] private string[] m_searchTags;

	#endregion

	#region Unity API

	private void Awake()
	{
		_target = null;
		_targetsInRange = new List<Transform>();
		GetComponent<CircleCollider2D>().radius = m_detectionRadius;
	}

	private void Update()
	{
		if (Mathf.RoundToInt(Time.time) % 1 != 0)
		{
			return;
		}
		else if (_targetsInRange.Count == 0)
		{
			_target = null;
			return;
		}
		else
		{
			float maxDistance = float.MaxValue;
			foreach(Transform t in _targetsInRange)
			{
				if (Vector2.Distance(t.position, transform.position) < maxDistance)
				{
					_target = t;
					maxDistance = Vector2.Distance(t.position, transform.position);
				}
			}
			if (_target != null)
			{
				/*_target.position = new Vector3((Vector2.Distance(transform.position, _target.position + Vector3.left) <
									Vector2.Distance(transform.position, _target.position + Vector3.right)) ? -1f : 1f,
									_target.position.y,
									_target.position.z);*/
				_destinationPosition = _target.position;
				_destinationPosition.x += (Vector2.Distance(transform.position, _target.position + Vector3.left) <
										   Vector2.Distance(transform.position, _target.position + Vector3.right)) ? 
										   -1f : 1f;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		foreach(string str in m_searchTags)
		{
			if (collision.CompareTag(str))
			{
				_targetsInRange.Add(collision.transform);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		foreach (string str in m_searchTags)
		{
			if (collision.CompareTag(str))
			{
				_targetsInRange.Remove(collision.transform);
			}
		}
	}

	#endregion

	#region Main Methods

	public Transform GetTarget()
	{
		return _target;
	}

	public Vector3 GetDestination()
	{
		return _destinationPosition;
	}

	public float GetDetectionDistance()
	{
		return m_detectionRadius;
	}

	public float GetTargetDistance()
	{
		if (_target != null)
		{
			return Vector2.Distance(_target.position, transform.position);
		}
		else
		{
			return 0f;
		}
	}

	#endregion

	#region Privates

	private Transform _target;
	private List<Transform> _targetsInRange;
	private Vector3 _destinationPosition;

	#endregion
}
