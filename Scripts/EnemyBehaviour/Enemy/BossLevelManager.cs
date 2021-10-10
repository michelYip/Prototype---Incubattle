using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelManager : MonoBehaviour
{
    #region Exposed

    [SerializeField] private Transform m_enemyManager;

    #endregion

    #region Unity API

    void FixedUpdate()
    {
        if (m_enemyManager.childCount <= 0)
		{
            SceneManager.LoadScene("WinScreen");
		}
    }
    #endregion

    #region Main Methods
    #endregion

    #region Privates
    #endregion
}
