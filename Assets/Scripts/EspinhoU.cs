using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoU : MonoBehaviour
{
    private Rigidbody2D espinhoRb;
    private int atrito;
    public int atritoMaximo, atritoMinimo;
    public Vector3 posicao;
    public GameObject espinhoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        espinhoRb = GetComponent<Rigidbody2D>();
        atrito = Random.Range(atritoMinimo, atritoMaximo);
        espinhoRb.drag = atrito;

        posicao = transform.position;
    }

    private void OnBecameInvisible()
    {
        Instantiate(espinhoPrefab, posicao, transform.localRotation);
        Pontua.pontos += 1;
        Destroy(this.gameObject);
    }
}
