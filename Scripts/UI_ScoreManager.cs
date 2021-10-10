using UnityEngine;
using TMPro;

public class UI_ScoreManager : MonoBehaviour
{
    #region Exposed

    [SerializeField] private PlayerStatsScriptable m_player1Stats;
    [SerializeField] private PlayerStatsScriptable m_player2Stats;

    #endregion

    #region Unity API
    void Awake()
    {
        _scoreText = transform.Find("ScorePanel").Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Mathf.RoundToInt(Time.time) % 1 != 0)
		{
            return;
		}
        else
		{
            int score = 0;
            if (m_player1Stats != null) score += m_player1Stats.Score;
            if (m_player2Stats != null) score += m_player2Stats.Score;
            _scoreText.text = score.ToString();
		}
    }
    #endregion

    #region Main Methods
    #endregion

    #region Privates

    private TextMeshProUGUI _scoreText;

    #endregion
}
