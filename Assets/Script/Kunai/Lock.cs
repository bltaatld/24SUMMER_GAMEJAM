using System;
using UnityEngine;
using static LockBehaviour;
public class Lock : MonoBehaviour
{
    public Animator animator;

    private GameObject rotateObject;
    private BoxCollider2D boxCollider;
    private bool isHit;

    private void Start()
    {
        rotateObject = GameObject.Find("Hostage");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotateObject.GetComponent<LockBehaviour>().orbitSpeed * Time.deltaTime));

        if (isHit)
        {

            // 충돌된 Lock 오브젝트를 제거
            lockBehaviour.lockObjectList.Remove(gameObject);
            lockBehaviour.orbitingObjects.Remove(gameObject);
            Destroy(gameObject);

            isHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kunai"))
        {
            AudioManager.instance.PlaySound(8);
            lockBehaviour.numberOfLocks--;
            Destroy(this.boxCollider);
            animator.SetTrigger("IsDead");
            Invoke("KunaiHitAction", 0.5f);
        }
    }

    public void KunaiHitAction()
    {
        isHit = true;
    }
}
