using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float playerDistanceSpawnLevel = 10f;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private GameObject player;
    private Vector3 lastEndPosition;

    private void Awake(){
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        player = GameObject.Find("Player");
        
        int spawnLevelNum = 5;
        for (int i = 0; i<spawnLevelNum; i++){
            SpawnLevelPart();
        }
    }

    private void Update(){
        Debug.Log(player.transform.position);
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerDistanceSpawnLevel){
            //Spawn platform
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart(){
        Transform chosenLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart ,lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition){
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
