using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	#region Exposed

	#endregion

	#region Unity API

	private void Awake()
	{
		if (m_instance != null && m_instance != this)
			Destroy(gameObject);
		m_instance = this;

		_numberOfPlayer = 1;
	}

	#endregion

	#region Main Methods

	public void LoadLevel(string _nextLevel)
	{
		SceneManager.LoadScene(_nextLevel);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public int NumberOfPlayer { get => _numberOfPlayer; set => _numberOfPlayer = value; }
	public static MenuManager Instance { get => m_instance; set => m_instance = value; }

	#endregion

	#region Privates

	private int _numberOfPlayer;
	private static MenuManager m_instance;

	#endregion
}
