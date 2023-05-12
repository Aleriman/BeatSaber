using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    
    public GameObject cube;
    public float spawnTimeMin, spawnTimeMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        while (true){
            GameObject cubeRight = null;
            GameObject cubeLeft =  null; 
            if (Random.Range(0, 100) <= 50)
            {
                cubeRight = Instantiate(cube, transform.position + Vector3.right * 0.2f, Quaternion.identity);
            }
            if (Random.Range(0, 100) >= 51)
            {
                cubeLeft = Instantiate(cube, transform.position + Vector3.right * -0.2f, Quaternion.identity);
            }
            if(cubeRight != null)
                cubeRight.GetComponent<Cube>().angle = Random.Range(0, 4);

            if (cubeLeft != null)
                cubeLeft.GetComponent<Cube>().angle = Random.Range(0, 4);


            if (Random.Range(0, 100) < 30 && cubeRight != null)
            {
                cubeRight.GetComponent<Cube>().blue = false;
            }
            else if (cubeLeft != null)
            {
                if (cubeRight == null)
                {

                    cubeLeft.GetComponent<Cube>().blue = Random.Range(0, 2) == 0 ? true : false;
                }
                cubeLeft.GetComponent<Cube>().blue = false;
            }
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }
    /*

    public GameObject cubePrefab;
    public float cubeSize = 1f;
    public int numCubes = 1;
    public float maxScale = 5.0f;
    public float scaleFactor = 0.2f;
    public AudioClip musicClip;
    public float threshold = 0.1f;

    private AudioSource audioSource;
    private float[] spectrumData;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.Play();

        spectrumData = new float[256];
    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        for (int i = 0; i < numCubes; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = transform.position + Vector3.back * (i - numCubes / 2) * cubeSize;
            cube.transform.localScale = new Vector3(spectrumData[i] * maxScale + 0.1f, cubeSize, spectrumData[i] * maxScale + 0.1f);

            if (cube.transform.localScale.x > threshold)
            {
                cube.GetComponent<Renderer>().material.color = GetCubeColor(cube.transform.position);
            }
            else
            {
                cube.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    Color GetCubeColor(Vector3 position)
    {
        if (position.z < -1.0f || position.z > 1.0f)
        {
            return Color.white;
        }
        else if (position.x < -0.5f || position.x > 0.5f)
        {
            return Color.white;
        }
        else if (position.x < 0.0f)
        {
            return Color.red;
        }
        else
        {
            return Color.blue;
        }
    }*/
}



