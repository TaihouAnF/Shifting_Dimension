using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public bool platformRealOrShadow;           // Indicate this platform whether it's real or shadow
    private MeshRenderer meshRenderer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Real dimension
        if (!player.GetComponent<PlayerController>().realOrShadow &&
            !platformRealOrShadow)
        {
            Color color = new(meshRenderer.material.color.r, meshRenderer.material.color.g,
                                meshRenderer.material.color.b, 1f);
            meshRenderer.material.color = color;
        }
        else if (player.GetComponent<PlayerController>().realOrShadow && 
            platformRealOrShadow)
        {
            Color color = new(meshRenderer.material.color.r, meshRenderer.material.color.g,
                                meshRenderer.material.color.b, 1f);
            meshRenderer.material.color = color;
        }
        else if (player.GetComponent<PlayerController>().realOrShadow &&
            !platformRealOrShadow)
        {
            Color color = new(meshRenderer.material.color.r, meshRenderer.material.color.g,
                                meshRenderer.material.color.b, 0.5f);
            meshRenderer.material.color = color;
        }
        else
        {
            Color color = new(meshRenderer.material.color.r, meshRenderer.material.color.g,
                                meshRenderer.material.color.b, 0.5f);
            meshRenderer.material.color = color;
        }
    }
}
