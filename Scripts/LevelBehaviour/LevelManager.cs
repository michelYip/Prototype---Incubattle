using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Exposed

    private static LevelManager m_instance;

	#endregion

	#region Unity API

	private void Awake()
	{
		if (m_instance != null && m_instance != this)
			Destroy(gameObject);
		m_instance = this;

		_isCameraBlocked = false;
		_currentWave = null;
	}

	private void Update()
	{
		if (Mathf.RoundToInt(Time.time) % 1 != 0)
			return;

		_isCameraBlocked = (_currentWave != null) ? true : false;
	}

	#endregion

	#region Main Methods

	public bool IsCameraBlocked { get => _isCameraBlocked; set => _isCameraBlocked = value; }
	public WaveManager CurrentWave { get => _currentWave; set => _currentWave = value; }
	public static LevelManager Instance { get => m_instance; set => m_instance = value; }

	#endregion

	#region Privates

	private bool _isCameraBlocked;
	private WaveManager _currentWave;

	#endregion
}
