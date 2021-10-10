using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region Exposed

    [Header("WaveAttribute")]
    [SerializeField] private int[] m_enemyPerWaves;
    [SerializeField] private GameObject[] m_enemiesPrefabs;

    [Header("SpawnLocation")]
    [SerializeField] private Vector2 m_limitX;
    [SerializeField] private Vector2 m_limitY;

    #endregion

    #region Unity API
    void Awake()
    {
        _waveToggle = false;
        _camera = Camera.main.GetComponent<CameraFollow>();
    }

    void Update()
    {
        if (_waveToggle && transform.childCount <= 0 && _currentWaveIndex < m_enemyPerWaves.Length)
		{
            for (int i = 0; i < m_enemyPerWaves[_currentWaveIndex]; i++)
			{
                int randomEnemyIndex = Random.Range(0, m_enemiesPrefabs.Length);
                float randomXPosition = (Random.Range(0f, 1f) < 0.5f) ? transform.position.x + m_limitX.x : transform.position.x + m_limitX.y;
                float randomYPosition = transform.position.y + Random.Range(m_limitY.x, m_limitY.y);
                Vector2 randomPosition = new Vector2(randomXPosition, randomYPosition);
                Instantiate(m_enemiesPrefabs[randomEnemyIndex], randomPosition, m_enemiesPrefabs[randomEnemyIndex].transform.rotation, transform);
			}
            _currentWaveIndex++;
        }

        if (_waveToggle && _currentWaveIndex >= m_enemyPerWaves.Length && transform.childCount <= 0)
		{
            _camera.NewTarget = null;
            _waveToggle = false;
            Destroy(gameObject);
		}

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            GetComponent<Collider2D>().enabled = false;
            Debug.Log(LevelManager.Instance.IsCameraBlocked);
            LevelManager.Instance.CurrentWave = this;
            TriggerWave();
        }
	}

	#endregion

	#region Main Methods

    private void TriggerWave()
	{
        _waveToggle = true;
        _currentWaveIndex = 0;
        _camera.NewTarget = transform;
	}

    #endregion

    #region Privates

    private bool _waveToggle;
    private int _currentWaveIndex;
    private CameraFollow _camera;

	#endregion
}
