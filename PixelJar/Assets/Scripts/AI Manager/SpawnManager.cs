using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAdventurerSpawnEnabled = false;
    private bool isMonsterSpawnEnabled = false;

    [SerializeField]
    private GameObject adventurerPrefab;

    [SerializeField] 
    private GameObject monsterPrefab;
    
    [SerializeField]
    public Transform minPosition;
    [SerializeField]
    public Transform maxPosition;
    
    public float spawnTimer = 3f;

    public int maxMonsters = 10;
    public int maxAdventurers = 10;

    public List<Transform> SpawnPoints;
    
    public int MonsterCount => GameObject.FindObjectsOfType<Monster>().Length;
    public int AdventureCount => GameObject.FindObjectsOfType<Adventurer>().Length;
    private void Awake()
    {
    }

    void Start()
    {
        GameManager.instance.StartListening("Day", UpdateAdventurerSpawn);
        GameManager.instance.StartListening("Night", UpdateMonsterSpawn);
    }

    private void OnEnable()
    {
        StartCoroutine(spawnMonster());
        StartCoroutine(spawnAdventurer());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnMonster());
        StopCoroutine(spawnAdventurer());
    }

    private void UpdateMonsterSpawn()
    {
        isAdventurerSpawnEnabled = false;
        isMonsterSpawnEnabled = true;
    }

    private void UpdateAdventurerSpawn()
    {
        isAdventurerSpawnEnabled = true;
        isMonsterSpawnEnabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        /*if(MonsterCount <= maxMonsters && spawnTimer <= 0) {
            StartCoroutine(spawnMonster());
        }
        if(AdventureCount <= maxAdventurers && spawnTimer <= 0) {
            StartCoroutine(spawnAdventurer());
        }*/
    }

    IEnumerator spawnMonster()
    {
        while (true)
        {
            if (isMonsterSpawnEnabled)
            {
                // Vector3 randomPosition = new Vector3(
                //     Random.Range(minPosition.position.x, maxPosition.position.x),
                //     Random.Range(minPosition.position.y, maxPosition.position.y),
                //     maxPosition.position.z
                // );

                Vector3 randomPosition = this.SpawnPoints[Random.Range(0, this.SpawnPoints.Count)].position;

                Instantiate(monsterPrefab, randomPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    IEnumerator spawnAdventurer()
    {
        while (true)
        {
            if (isAdventurerSpawnEnabled)
            {
                // Vector3 randomPosition = new Vector3(
                //     Random.Range(minPosition.position.x, maxPosition.position.x),
                //     Random.Range(minPosition.position.y, maxPosition.position.y),
                //     maxPosition.position.z
                // );

                Vector3 randomPosition = this.SpawnPoints[Random.Range(0, this.SpawnPoints.Count)].position;

                Instantiate(adventurerPrefab, randomPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    
    
}
