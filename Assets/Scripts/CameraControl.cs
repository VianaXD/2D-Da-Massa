
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; //o objeto que a câmera seguirá
    public float smoothSpeed = 5f; // Suavidade de movimento
    public Vector3 offset = new Vector3(0f, 0f, -10f); //posição da camera
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target == null)
            return;

        Vector3 posicaoDesejada = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, posicaoDesejada, smoothSpeed * Time.deltaTime);

        transform.position = smoothPosition;
    }
}
