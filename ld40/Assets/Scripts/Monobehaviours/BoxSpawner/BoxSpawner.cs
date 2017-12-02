using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour 
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    [SerializeField] Clock clock;
    //[SerializeField] Loss loss;
    [SerializeField] GameData data;
    //[SerializeField] GameController controller;

    void Start()
    {
        StartCoroutine(SpawnBoxes());
        SpawnBox();
    }

    void Update() 
    {
        if(data.gameOver) {
            StopAllCoroutines();
        }
    }

    void SpawnBox() {
        Color color = Color.black;
        ColorTypes colorType = ColorTypes.UNSET;
        int temp = Random.Range(0, 5);
        switch(temp) {
            case 0:
                color = Color.blue;
                colorType = ColorTypes.BLUE;
                break;
            case 1:
                color = Color.green;
                colorType = ColorTypes.GREEN;
                break;
            case 2:
                color = Color.red;
                colorType = ColorTypes.RED;
                break;
            case 3:
                color = Color.yellow;
                colorType = ColorTypes.YELLOW;
                break;
            case 4:
                color = Color.black;
                colorType = ColorTypes.BLACK;
                break;
            default:
                Debug.LogWarning("BoxSpawner::SpawnBox::ColorOutOfRange");
                break;
        }

        GameObject boxGO = Instantiate(boxPrefab, transform.position, Quaternion.identity) as GameObject;
        boxGO.GetComponentInChildren<SpriteRenderer>().color = color;
        boxGO.GetComponent<Box>().colorType = colorType;
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
