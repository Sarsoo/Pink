using Pink.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<PinkController>();
        if (player != null)
        {
            Debug.Log("Player Burnt");
            player.health.Hurt(4f);
        }
    }
}
