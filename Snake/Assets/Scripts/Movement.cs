using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direccion = Vector2.right;
    public float velocidad = 5;
    public Transform segmentoPrefab;
    List<Transform> tamaņoSerpiente =new List<Transform>();

    private void Start()
    {
        tamaņoSerpiente.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direccion = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direccion = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            direccion = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direccion = Vector2.right;
        }

        
    }

    private void FixedUpdate()
    {
        for (int i = tamaņoSerpiente.Count - 1; i > 0; i--)
        {
            tamaņoSerpiente[i].position = tamaņoSerpiente[i - 1].position;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x,
                                         Mathf.Round(transform.position.y) + direccion.y,
                                         0.0f);
        }

    void Reset()
    {
        for (int i = 1; i<tamaņoSerpiente.Count; i++)
        { 
            Destroy(tamaņoSerpiente [i].gameObject);
        }
        tamaņoSerpiente.Clear();
        tamaņoSerpiente.Add(transform);

        transform.position = Vector3.zero;
    }

    void Crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = tamaņoSerpiente[tamaņoSerpiente.Count - 1].position;
        tamaņoSerpiente.Add(segmentoNuevo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pared"))
        {
            Reset();
        
        }

        if (collision.CompareTag("Comida"))

        {
            Crecer();
        }
    }
}
    
 