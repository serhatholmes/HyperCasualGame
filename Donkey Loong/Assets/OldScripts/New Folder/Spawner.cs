using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Spawner : MonoBehaviour
{

    CharacterChanging char1;
  

    [SerializeField] Transform startPos;
    [SerializeField] GameObject obj;
    [SerializeField] bool spawning = false;

    public SkinnedMeshRenderer smr;

    private int timeCounter;
    private int spawnTime;
    private bool spawnTrigger = false;

    Player player1;

    int chcCount = 0;
    int destroyCount = 0;
    GameObject[] chcs=new GameObject[10];

    public GameObject[] characterPrefabs;

    void Start()
    {
        //smr = GameObject.FindObjectOfType<SkinnedMeshRenderer>();
        //char1 = gameObject.GetComponent<SkinnedMeshRenderer>().materials;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boy")
        {
            player1 = other.gameObject.GetComponent<Player>();
            SpawnJumper();
            
            Debug.Log("spawn");
            other.gameObject.GetComponent<Player>().enabled = false;
        }
    }

    public void SpawnJumper()
    {
        if (!spawnTrigger)
        {

            spawnTrigger = true;
            StartCoroutine(spawnTriggerResetter());
            var character = Instantiate(obj, startPos.position, Quaternion.identity);
            //character = player1.GetComponent<SkinnedMeshRenderer>();
            chcCount++;
            destroyCount++;
            Debug.Log("artması lazım");

            if (chcCount == 10)
            {
                Debug.Log("Saydı");
                chcCount = 0;
                
            }
            if (destroyCount == 10)
            {
                SceneManager.LoadScene("GameOver");
            }

            if (chcs[chcCount]!=null)
            {
                Destroy(chcs[chcCount]);
                chcs[chcCount] = character;
            }
            else
            {
                chcs[chcCount] = character;
            }
           
        }
        
    }

    IEnumerator spawnTriggerResetter()
    {
        yield return new WaitForSeconds(2);
        spawnTrigger = false;
    }
}
