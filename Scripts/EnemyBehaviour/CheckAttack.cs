using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
	#region Exposed
	#endregion

	#region Unity API

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_canAttack = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_canAttack = false;
		}
	}

	#endregion

	#region Main Methods

	public bool CanAttack()
	{
		return _canAttack;
	}

	#endregion

	#region Privates

	private bool _canAttack;

	#endregion
}