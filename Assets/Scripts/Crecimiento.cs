using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crecimiento : MonoBehaviour
{
    public GameObject pieza;
    public int totalPiezas;

    private GameObject piezaActual;
    private bool hayHueco;

    // Start is called before the first frame update
    void Start()
    {
        hayHueco = true;
        piezaActual = null;
        StartCoroutine(Generar(0,0));
    }

    IEnumerator Generar(float x, float z)
    {
        yield return new WaitForEndOfFrame();

        if(totalPiezas > 0)
        {
            if (hayHueco == true)
            {
                piezaActual = Instantiate(pieza, new Vector3(x, 0, z), Quaternion.identity);
                totalPiezas--;
            }

            float newX = 0;
            float newZ = 0;
            int sentidoCrecimiento = Random.Range(0, 4);
            RaycastHit hit;

            switch (sentidoCrecimiento)
            {
                case 0: //norte
                    if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.forward, out hit, 3))
                    {
                        hayHueco = false;
                        piezaActual = hit.transform.gameObject;
                    }
                    else
                    {
                        hayHueco = true;
                    }
                    newX = piezaActual.transform.position.x;
                    newZ = piezaActual.transform.position.z + 5;
                    break;
                case 1: //sur
                    if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.forward * -1, out hit, 3))
                    {
                        hayHueco = false;
                        piezaActual = hit.transform.gameObject;
                    }
                    else
                    {
                        hayHueco = true;
                    }
                    newX = piezaActual.transform.position.x;
                    newZ = piezaActual.transform.position.z - 5;
                    break;
                case 2: //este
                    if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.right * -1, out hit, 3))
                    {
                        hayHueco = false;
                        piezaActual = hit.transform.gameObject;
                    }
                    else
                    {
                        hayHueco = true;
                    }
                    newX = piezaActual.transform.position.x - 5;
                    newZ = piezaActual.transform.position.z;
                    break;
                case 3: //oeste
                    if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.right, out hit, 3))
                    {
                        hayHueco = false;
                        piezaActual = hit.transform.gameObject;
                    }
                    else
                    {
                        hayHueco = true;
                    }
                    newX = piezaActual.transform.position.x + 5;
                    newZ = piezaActual.transform.position.z;
                    break;
            }

            StartCoroutine(Generar(newX, newZ));

        }
    }
}
