using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    static GameplayManager _instance;

    public static GameplayManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameplayManager>();

                if (!_instance)
                {
                    GameObject obj = new GameObject();
                    obj.name = "GameplayManager";
                    _instance = obj.AddComponent<GameplayManager>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Player player;
    [SerializeField] private ObjectPool objectPool;
    private float _spawnTimer;
    private void Start(){
        player.RefillAmmo();
    }
    
    private void Update()
    {
        if (_spawnTimer < 0)
        {
            _spawnTimer = 3f;
            objectPool.SpawnObject();
        }
        _spawnTimer -= Time.deltaTime;
    }

    public void InvertPenalty()
    {
        StartCoroutine(InvertPenaltyTimer());
    }

    public IEnumerator InvertPenaltyTimer()
    {
        player.InvertAim();
        float invertTimer = 5;
        while (invertTimer > 0)
        {
            invertTimer -= Time.deltaTime;
        }
        player.DeInvertAim();
        yield return 0;
    }

    public void DuckHit()
    {
        Debug.Log("DuckHit");
    }
}
