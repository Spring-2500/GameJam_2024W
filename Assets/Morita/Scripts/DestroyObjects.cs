using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���������I�u�W�F�N�g��destroyTimeb�b��ɍ폜
public class DestroyObjects : MonoBehaviour
{
    [SerializeField] float destroyTime = 3.0f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
