using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    [SerializeField] GameObject spawnObjectPrefab;
    private GameObject spawnObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (spawnObject == null)
                    spawnObject = Instantiate(spawnObjectPrefab, hit.point, Quaternion.identity);
                else
                    spawnObject.transform.position = hit.point;
            }
        }
    }
}
