using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour
{

    public Material beforePress;
    public Material pressing;

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject reverseButton;
    public GameObject resetButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pressCheck();
    }

    public void pressCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ChangeMaterial(leftArrow));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ChangeMaterial(rightArrow));
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            StartCoroutine(ChangeMaterial(downArrow));
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            StartCoroutine(ChangeMaterial(upArrow));
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(ChangeMaterial(reverseButton));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(ChangeMaterial(resetButton));
        }
    }

    IEnumerator ChangeMaterial (GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        renderer.material = pressing;

        yield return new WaitForSeconds(0.2f);

        renderer.material = beforePress;
    }
}
