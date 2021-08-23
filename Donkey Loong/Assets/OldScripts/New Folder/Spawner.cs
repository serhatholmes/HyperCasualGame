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

    private CharacterSelect _characterSelect;

    public GameObject arrowsPrefab;

    void Awake()
    {
       
    }

    void Start()
    {
        _characterSelect = FindObjectOfType<CharacterSelect>();

        obj = _characterSelect.GetSelectedCharacter();

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
            Instantiate(arrowsPrefab);
            arrowsPrefab.transform.SetParent(player1.transform);
            chcCount++;
            destroyCount++;
            

            if (chcCount == 10)
            {
                Debug.Log("Count");
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
