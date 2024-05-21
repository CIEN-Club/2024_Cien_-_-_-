using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGoundOffset : MonoBehaviour
{
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += GameManager.Instance.player.GetInputVec() / 2 * Time.deltaTime;
    }
}
