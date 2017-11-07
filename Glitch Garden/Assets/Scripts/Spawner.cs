using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] AttackerPrefabArray;

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject thisAttacker in AttackerPrefabArray)
            if (IsTimeToSpawn(thisAttacker))
                Spawn(thisAttacker);
    }

    private void Spawn(GameObject thisAttacker)
    {
        GameObject attacker = Instantiate(thisAttacker);
        attacker.transform.parent = transform;
        attacker.transform.position = transform.position;
    }

    private bool IsTimeToSpawn(GameObject thisAttacker)
    {
        Attacker attacker = thisAttacker.GetComponent<Attacker>();
        float spawnRate = attacker.SpawnRate;
        float spawnPerSecond = 1 / spawnRate;

        float threshold = spawnPerSecond * Time.deltaTime / 5;

        if (Random.value < threshold)
            return true;

        return false;
    }
}