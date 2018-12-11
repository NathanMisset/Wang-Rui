using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriger : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(this.gameObject);
            Debug.LogError("Hit");
        }
    }
}
