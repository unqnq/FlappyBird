using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject getReadyImage;
    [SerializeField] private GameObject numberImage;
    private RawImage numberImageComponent;
    [SerializeField] private Texture[] num;
    void Start()
    {
        getReadyImage = GameObject.Find("GetReadyImage");
        numberImage = GameObject.Find("NumberImage");
        numberImageComponent = numberImage.GetComponent<RawImage>();
        StartCoroutine(CountdownRoutine());
    }

     private IEnumerator CountdownRoutine()
    {
        getReadyImage.SetActive(false);
        numberImage.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            numberImageComponent.texture = num[i - 1];
            yield return new WaitForSeconds(1f);
        }

        numberImage.SetActive(false);
        getReadyImage.SetActive(true);

        yield return new WaitForSeconds(1f);
        getReadyImage.SetActive(false);
        FindAnyObjectByType<PipeSpawn>().StartSpawnPipes();
        FindAnyObjectByType<PlayerController>().GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
