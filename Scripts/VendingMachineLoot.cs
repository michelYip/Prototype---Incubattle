using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineLoot : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private GameObject[] _loots;

    [SerializeField]
    private int _numberOfLoots;

    #endregion

    #region Unity API
    void Awake()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Main Methods

    public void DropLoot()
    { 
        for(int i = 0; i < _numberOfLoots;i++)
        {
            int randomIndex = Random.Range(0, _loots.Length);
            LootSpawn newLoot = Instantiate(_loots[randomIndex], transform.position, _loots[randomIndex].transform.rotation).GetComponent<LootSpawn>();
            newLoot.Start = transform.position;
            newLoot.Destination = (Vector2)transform.position + new Vector2(Random.Range(-1, 1f), Random.Range(-1, -2f));
        }
    }

    #endregion

    #region Privates
    #endregion
}