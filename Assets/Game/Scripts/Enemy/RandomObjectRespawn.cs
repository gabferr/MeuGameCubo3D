using UnityEngine;
using System.Collections;

namespace Game { 
public class RandomObjectRespawn : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject[] respawnPositions;   // Lista de game objects representando os spawns.
    public int timeToRespawn = 1;

    private int currentSpawnIndex = 0;

    void Start()
    {
        StartCoroutine(RespawnCadaSegundo(timeToRespawn));
    }

    public void DestroyRespawn(float time)
    {  
      Destroy(gameObject,time);
    }
IEnumerator RespawnCadaSegundo(float respawnInterval)
    {
        while (true)
        {
            int randomIndex = Random.Range(0, gameObjects.Length);
            GameObject selectedSpawn = respawnPositions[currentSpawnIndex];

            Vector3 respawnPosition = selectedSpawn.transform.position;

            Instantiate(gameObjects[randomIndex], respawnPosition, Quaternion.identity);

            currentSpawnIndex = (currentSpawnIndex + 1) % respawnPositions.Length; 

            yield return new WaitForSeconds(respawnInterval);
        }
    }
}
}