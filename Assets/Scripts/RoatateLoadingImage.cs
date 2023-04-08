using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoatateLoadingImage : MonoBehaviour
{
    private RectTransform rect_transform;

    private void Awake()
    {
        rect_transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect_transform.Rotate(Vector3.forward * Time.deltaTime * 150f);
    }
}
