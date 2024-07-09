using System;
using UnityEngine;
using static LockBehaviour;
public class Lock : MonoBehaviour
{
    public Animator animator;
    private GameObject rotateObject;
    private GameObject kunaiObject;
    private bool isHit;

    private void Start()
    {
        rotateObject = GameObject.Find("Hostage");
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotateObject.GetComponent<LockBehaviour>().orbitSpeed * Time.deltaTime));

        if (isHit)
        {
            // �浹�� Lock ������Ʈ�� ����
            lockBehaviour.lockObjectList.Remove(gameObject);
            lockBehaviour.orbitingObjects.Remove(gameObject);
            Destroy(gameObject);
            Destroy(kunaiObject); // Kunai ������Ʈ ����
            isHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kunai"))
        {
            lockBehaviour.numberOfLocks--;
            animator.SetTrigger("IsDead");
            kunaiObject = other.gameObject;
        }
    }

    public void KunaiHitAction()
    {
        isHit = true;
    }
}
