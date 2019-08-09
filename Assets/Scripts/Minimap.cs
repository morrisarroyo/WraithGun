using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private GameObject enemyIcon;
    [SerializeField] private float minimapZoomFactor = 1;
    List<Transform> objectsToRender;
    List<GameObject> icons;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRadarScript.OnEnterRadar += AddObjectToRender;
        PlayerRadarScript.OnExitRadar += RemoveObjectToRender;
        objectsToRender = new List<Transform>();
        icons = new List<GameObject>();
        playerTransform = Player.instance.transform;
        for (int i = 0; i < 10; ++i)
        {
            icons.Add(Instantiate(enemyIcon, transform));
        }
        //Debug.Log(icons.Count);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < icons.Count; ++i)
        {
            if (i < objectsToRender.Count)
            {
                icons[i].SetActive(true);
                //icons[i].transform.position = new Vector3(1, 0, 1);
                //Debug.Log(objectsToRender.Count);
                Vector3 relativePos = (objectsToRender[i].position - playerTransform.position);
                Vector2 minimapPos = new Vector2(relativePos.x, relativePos.z) * 10 * minimapZoomFactor;
                icons[i].GetComponent<RectTransform>().anchoredPosition = minimapPos;
                //icons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(1, 1);
            }
            else
            {
                //Debug.Log("No objects to render");

                icons[i].SetActive(false);
            }
        }
        //icons[objectsToRender.Count].transform.position
    }

    void AddObjectToRender(Transform transform)
    {
        if (!objectsToRender.Find(tr => tr.GetInstanceID() == transform.GetInstanceID()))
        {
            objectsToRender.Add(transform);
            if (objectsToRender.Count > icons.Count)
            {
                icons.Add(Instantiate(enemyIcon));
            }
        }
        Debug.Log(transform.GetInstanceID());

    }

    void RemoveObjectToRender(Transform transform)
    {
        int index = objectsToRender.FindIndex(tr => tr.GetInstanceID() == transform.GetInstanceID());
        objectsToRender.Remove(transform);
        //StartCoroutine(ResetIcon(index));
    }

    /*
    IEnumerator ResetIcon(int index)
    {
        yield return new WaitForEndOfFrame();
        icons[objectsToRender.Count].SetActive(false);
    }
    */
}
