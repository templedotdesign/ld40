using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour 
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    [SerializeField] Clock clock;
    [SerializeField] Loss loss;

    void Start()
    {
        StartCoroutine(SpawnBoxes());   
    }

    void Update() 
    {
        if(loss.total >= 50) {
            StopAllCoroutines();
        }
    }

    void SpawnBox() {
        Color color = Color.black;
        int temp = Random.Range(0, 5);
        switch(temp) {
            case 0:
                color = Color.blue;
                break;
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.red;
                break;
            case 3:
                color = Color.yellow;
                break;
            case 4:
                color = Color.black;
                break;
            default:
                Debug.LogWarning("BoxSpawner::SpawnBox::ColorOutOfRange");
                break;
        }
        GameObject boxGO = Instantiate(boxPrefab, transform.position, Quaternion.identity) as GameObject;
        SpriteRenderer boxSR = boxGO.GetComponentInChildren<SpriteRenderer>();
        boxSR.color = color;
    }

    IEnumerator SpawnBoxes() 
    {
        while (true)
        {
            if(clock.minutes >= 4) {
                minDelay = 0.3f;
                maxDelay = 0.9f;
            }else if(clock.minutes >= 3) {
                minDelay = 0.4f;
                maxDelay = 1f;
            } else if(clock.minutes >= 2) {
                minDelay = 0.5f;
                maxDelay = 1.25f;
            } else if(clock.minutes >= 1) {
                minDelay = 0.6f;
                maxDelay = 1.5f;
            }

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            SpawnBox();
        }
    }
}
