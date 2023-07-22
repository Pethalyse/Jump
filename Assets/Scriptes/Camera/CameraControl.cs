using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //Player
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.localPosition.x, target.transform.localPosition.y+3, -1);
    }
}
