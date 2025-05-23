using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Find Key - Mission", menuName = "Mission/Key Mission")]
public class Mission_KeyFind : Mission
{
    [SerializeField] private GameObject key;
    private bool keyFound;

    public override void StartMission()
    {
        MissionObject_Key.OnKeyPickedUp += PickUpKey;

        Enemy enemy = LevelGenerator.instance.GetRandomEnemy();
        enemy.GetComponent<Enemy_DropController>()?.GiveKey(key);
        enemy.MakeEnemyVIP();

        Debug.Log("Key given to enemy: " + enemy.name);
    }

    public override bool MissionCompleted()
    {
        return keyFound;
    }

    private void PickUpKey()
    {
        keyFound = true;
        MissionObject_Key.OnKeyPickedUp -= PickUpKey;
        Debug.Log("I picked up a key!");
    }
}
