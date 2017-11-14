using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSizeController : MonoBehaviour
{

    private float xdis, ydis;
    private float sizePlatformX;
    public float tamMinimo;
    private int numRays;
    private Vector3 sizePlayer;
    private Vector3 temp;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        sizePlayer = GameObject.Find("Player").GetComponent<BoxCollider2D>().bounds.size;
        sizePlatformX = GetComponent<Transform>().localScale.x;
        tamMinimo = 0.15f;
        print(sizePlatformX);
    }

    void FixedUpdate()
    {
        xdis = rend.bounds.size.x;
        ydis = rend.bounds.size.y;

        Vector2 toplefttip = new Vector2(transform.position.x - xdis / 2, transform.position.y + ydis / 2);
        numRays = (int)Mathf.Ceil(xdis / sizePlayer.x) + 2; //calcula el numero de rayos de forma dinámica dependiendo del tamaño de la plataforma

        for (int i = 0; i < numRays; i++)
        {
            Debug.DrawLine(toplefttip + new Vector2((xdis / (numRays - 1)) * i, 0), toplefttip + new Vector2((xdis / (numRays - 1)) * i, +0.05f), Color.green); //Origen, fin, color
            RaycastHit2D rayosDown = Physics2D.Raycast(toplefttip + new Vector2((xdis / (numRays - 1)) * i, 0), new Vector2(0, 1), 0.05f); //origen, direccion, longitud

            if (rayosDown)
            {
                print("colision");
                if (rayosDown.collider.tag == "Player")
                {
                    if (transform.localScale.x > tamMinimo)
                    {
                        temp = transform.localScale;
                        temp.x -= 0.3f * Time.deltaTime;
                        transform.localScale = temp;
                    }
                }

            }

            /*else {

                print("fuera");
                if (transform.localScale.x < sizePlatformX) {
                    temp = transform.localScale;
                    temp.x += Time.deltaTime;
                    transform.localScale = temp;
                }
            }*/
        }
    }
}

