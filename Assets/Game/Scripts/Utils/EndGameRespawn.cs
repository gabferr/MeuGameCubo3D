using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using TMPro;


public class EndGameRespawn : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI endGameText;
    private void Start()
    {
        endGameText.enabled = false;
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
        endGameText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(level);
        
    }
}
