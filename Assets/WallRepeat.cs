using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRepeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.transform.Translate(new Vector3(0, 0, 60f));
        }
    }
}
