using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesController : MonoBehaviour {
    [SerializeField] private List<PlacedObjectTypeSO> enemiesSO;
    [SerializeField] private List<Transform> listSpawnPosition;
    [SerializeField] private bool isSpawn = true;
    private float timeSpawn = 0;
    private List<ActorBase> actorBases;

    private void Start() {
        actorBases = new List<ActorBase>();
    }

    private void Update() {
        if (Time.time > timeSpawn && isSpawn) {
            timeSpawn = Time.time + Random.Range(2, 8);
            PlacedObjectTypeSO placeSO = enemiesSO[Random.Range(0, enemiesSO.Count)];
            Transform trans = listSpawnPosition[Random.Range(0, listSpawnPosition.Count)];
            var actor = Instantiate( placeSO.prefabs, trans).GetComponent<ActorBase>();
            actor.Init(placeSO);
            actorBases.Add(actor);
        }
    }
}
