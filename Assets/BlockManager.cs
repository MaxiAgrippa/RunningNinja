using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private GameObject player;
    public GameObject[] BlockerCollections;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 position = new Vector3(0, 0, (other.transform.position.z + 40f));
            int challenges = Random.Range(4, 6);
            for (int i = 0; i < challenges; i++)
            {
                int challengeNumber = Random.Range(0, (BlockerCollections.Length - 1));
                GameObject.Instantiate(BlockerCollections[challengeNumber], position, new Quaternion());
                position += new Vector3(0, 0, 20f);
            }
            this.transform.Translate(0, 0, 40f + (20f * (challenges + 1)));
        }
    }
}
