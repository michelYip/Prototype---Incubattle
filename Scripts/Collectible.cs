using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Collectible : MonoBehaviour
{
    #region Exposed

    [SerializeField] private PickupScriptable m_value;

	#endregion

	#region Unity API

	private void Awake()
	{
		_collectSFX = GetComponent<AudioSource>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_collectSFX.Play();
		}
	}

	#endregion

	#region Main Methods
	public PickupScriptable Value { get => m_value; set => m_value = value; }

	#endregion

	#region Privates
	private AudioSource _collectSFX;
	#endregion
}
