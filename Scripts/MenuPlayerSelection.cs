using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuPlayerSelection : MonoBehaviour, ISelectHandler
{
	#region Exposed

	[SerializeField] private Animator m_otherAnimator;
	[SerializeField] private int m_numberOfPlayer;

	[SerializeField] private Image _spriteP2;

	#endregion

	#region Unity API

	private void Start()
	{
		_myAnimator = GetComponent<Animator>();

		if (gameObject.name == "ButtonP1")
		{
			GetComponent<Button>().Select();
		}
	}

	#endregion

	#region Main Methods

	public void OnSelect(BaseEventData eventData)
	{
		try
		{
			MenuManager.Instance.NumberOfPlayer = m_numberOfPlayer;
			_myAnimator.SetBool("Selected", true);
			m_otherAnimator.SetBool("Selected", false);

			if (gameObject.name == "ButtonP2")
				_spriteP2.enabled = true;
			else if (gameObject.name == "ButtonP1")
				_spriteP2.enabled = false;
		}
		catch
        {
			Debug.LogError("Missing MenuManager");
        }
	}

	#endregion

	#region Privates

	private Animator _myAnimator;

	#endregion
}
