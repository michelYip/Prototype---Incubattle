using UnityEngine;

[CreateAssetMenu]
public class PickupScriptable : ScriptableObject
{
    #region Exposed

    [SerializeField] private int m_value = 0;

	#endregion

	#region Unity API
	#endregion

	#region Main Methods

	public int Value { get => m_value; set => m_value = value; }

	#endregion

	#region Privates
	#endregion
}
