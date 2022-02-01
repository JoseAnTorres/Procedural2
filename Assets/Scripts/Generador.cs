using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public int x;
    public int z;
    public GameObject pieza;

    // Start is called before the first frame update
    void Start()
    {
        float semilla = Random.Range(0.0f, 100.0f);
        float escala = 10.0f;
        int proporcion = 50;

        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < z; j++)
            {
                float corX = semilla + i / escala;
                float corY = semilla + j / escala;

                int r = (int)(Mathf.PerlinNoise(corX, corY) * proporcion);

                if(r > 20)
                {
                    Instantiate(pieza, new Vector3(i * 5, 0, j * 5), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
