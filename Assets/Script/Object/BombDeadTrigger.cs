using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDeadTrigger : MonoBehaviour
{
    public float explodeTime;
    public float bombCoolDown;
    public GameObject tileCollider;

    private void Update()
    {
        explodeTime += Time.deltaTime;

        if (explodeTime >= bombCoolDown)
        {
            gameObject.SetActive(false);
            tileCollider.SetActive(false);
        }
    }
}
