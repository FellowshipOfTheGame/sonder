using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Player thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(thePlayer.gameObject.transform.position.x,thePlayer.gameObject.transform.position.y,-10f);
    }
}
