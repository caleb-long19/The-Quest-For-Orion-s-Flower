using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrderRenderer : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderDefault = 5000;
    [SerializeField]
    private int offset = 0;
    private Renderer myRenderer;

    // Update is called once per frame
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderDefault - transform.position.y - offset);
    }
}
