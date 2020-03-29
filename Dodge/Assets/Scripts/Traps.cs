using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traps : MonoBehaviour
{
    public static float Tiempo = 0.0f;
    public GameObject trap;
    private GameObject cloneTrap_one;
    private GameObject cloneTrap_second;
    float z = 0;
    bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo = Time.timeSinceLevelLoad;
        string texto = Tiempo + "";
        if (!spawned)
        {
            if(Tiempo <= 10.0f)
            {
                spawned = true;
                TrapSD_One();
                StartCoroutine(DestroyObjectAfterSeconds_One());
                StartCoroutine(WaitToSpawnTrap());
            }
            else if(Tiempo >= 10.0f && Tiempo <= 20.0f)
            {
                spawned = true;
                TrapSD_One();
                StartCoroutine(DestroyObjectAfterSeconds_One());

            } 
            else if(Tiempo >= 20.0f)
            {
                Debug.Log(texto);
                spawned = true;
                TrapSD_One();
                StartCoroutine(DestroyObjectAfterSeconds_One());
                TrapSD_Second();
                StartCoroutine(DestroyObjectAfterSeconds_Second());
            }

        }

        Debug.Log(texto);

    }

    private void TrapSD_One()
    {
        float x = Random.Range(-6.9f,6.9f);
        float y = Random.Range(-4.27f,-0.78f);

        cloneTrap_one = (GameObject)Instantiate(trap,new Vector3(x,y,z),Quaternion.identity);
    }
    private void TrapSD_Second()
    {
        float x = Random.Range(-6.9f, 6.9f);
        float y = Random.Range(-4.27f, -0.78f);

        cloneTrap_second = (GameObject)Instantiate(trap, new Vector3(x, y, z), Quaternion.identity);
    }


    IEnumerator WaitToSpawnTrap()
    {
        yield return new WaitForSeconds(5);
        spawned = false;
    }

    IEnumerator DestroyObjectAfterSeconds_One()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(cloneTrap_one);
        if (Tiempo >= 10.0f && Tiempo <= 24.0f)
        {
            spawned = false;
        }
    }
    IEnumerator DestroyObjectAfterSeconds_Second()
    {
        yield return new WaitForSeconds(3);
        Destroy(cloneTrap_second);
            spawned = false;
    }
}
