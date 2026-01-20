using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;

    [SerializeField] float waitTime = 0.3f;
    
    [SerializeField] int maxamountToSpawn = 10;
    bool infiniteInt = false;

    void Start()
    {
        infiniteInt = maxamountToSpawn <= 0?  true : false;
        StartCoroutine(UpdateSpawn());
    }

    IEnumerator UpdateSpawn()
    {
        print("start coroutine");
        int i = 0;
        while (i < maxamountToSpawn || infiniteInt)
        {

            GameObject clone = BasicPuller.instance.Instantiate(objectToSpawn);
            
            clone.name = clone.name + "_clone" + i;
            RandomizeTransforms(clone.transform);
            i++;
            yield return new WaitForSeconds(waitTime);

        }
        print("Finished coroutine");
    }

    void RandomizeTransforms(Transform obj)
    {
        obj.position += RandomVector(-1f, 1f);
        obj.localScale = VectorABS(RandomVector(-1f, 1f));
        obj.rotation = Quaternion.Euler(RandomVector(0f, 360f));
    }

    Vector3 VectorABS(Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    Vector3 RandomVector(float min = 0f, float max = 1f)
    {
        float x, y, z;
        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
}
