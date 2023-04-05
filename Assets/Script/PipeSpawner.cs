using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject pipeHolder;

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(2f);

        Vector3 pos = this.transform.position;
        pos.y = Random.Range(-1.5f, 1.5f);

        Instantiate(pipeHolder,pos, Quaternion.identity);
        StartCoroutine(SpawnPipe());

    }
}
