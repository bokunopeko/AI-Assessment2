using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonColour : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    private Renderer rendererr;


    void Start()
    {
        rendererr = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }

   
    public void PickRandom()
    {
        Color randomColour = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColour);
        rendererr.SetPropertyBlock(propertyBlock);
              


    }
}
