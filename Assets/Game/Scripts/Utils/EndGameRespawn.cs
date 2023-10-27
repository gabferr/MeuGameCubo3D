using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class EndGameRespawn : MonoBehaviour
{
    public int level;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(EndGameSceneRespawnCoroutine());
        }
    }


    IEnumerator EndGameSceneRespawnCoroutine()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(level);
        
    }
}
