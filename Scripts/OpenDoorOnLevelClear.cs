using UnityEngine;

public class OpenDoorOnLevelClear : MonoBehaviour
{
    #region Exposed

    [SerializeField] private Animator _animator;
	[SerializeField] private AudioSource m_audioSource;

	#endregion

	#region Unity API
	private void OnDestroy()
	{
		if (_animator != null)
			_animator.SetTrigger("OpenTrigger");
		if (m_audioSource != null)
			m_audioSource.Play();
	}
	#endregion

	#region Main Methods
	#endregion

	#region Privates
	#endregion
}
