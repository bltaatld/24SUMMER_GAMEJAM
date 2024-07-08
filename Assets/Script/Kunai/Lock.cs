using System;
using UnityEngine;
using static LockBehaviour;
public class Lock : MonoBehaviour
{
    private GameObject rotateObject;

    private void Start()
    {
        rotateObject = GameObject.Find("Hostage");
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotateObject.GetComponent<LockBehaviour>().orbitSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kunai"))
        {
            lockBehaviour.numberOfLocks--;

            // �浹�� Lock ������Ʈ�� ����
            lockBehaviour.lockObjectList.Remove(gameObject);
            lockBehaviour.orbitingObjects.Remove(gameObject);
            Destroy(gameObject);
            Destroy(other.gameObject); // Kunai ������Ʈ ����
        }
    }
}
