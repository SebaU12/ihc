using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageDoor : MonoBehaviour
{
    public Transform Door1; 
    public Transform Door2; 
    public Vector3 startPosition1;
    public Vector3 startPosition2;
    public Vector3 endPosition1;
    public Vector3 endPosition2;
    private bool isAnimationRunning1= false;
    private bool isAnimationRunning2= false;
    // Start is called before the first frame update
    void Start()
    {
        Door1.position = startPosition1;
        Door2.position = startPosition2;
    }

    public void RunAnimation()
    {
        isAnimationRunning1= false;
        isAnimationRunning2= false;
        StartCoroutine(CloseDoorAnimation(Door1, () => isAnimationRunning1 = true));
        StartCoroutine(CloseDoorAnimation(Door2, () => isAnimationRunning2 = true));
    }

    private IEnumerator CloseDoorAnimation(Transform door, System.Action animationRunning)
    {
        float animationTime = 2.0f;
        float time = 0.0f;
        Vector3 start = door == Door1 ? startPosition1 : startPosition2;
        Vector3 end = door == Door1 ? endPosition1 : endPosition2;

        while (time < animationTime)
        {
            time += Time.deltaTime;
            door.position = Vector3.Lerp(start, end, time / animationTime);
            yield return null;
        }
        
        animationRunning();
        if (isAnimationRunning1 && isAnimationRunning2)
        {
            AnimacionesTerminadas();
        }
    }

    private void AnimacionesTerminadas()
    {
        Debug.Log("Animaciones termianda");
        sceneManager ChangeScene = GameObject.Find("controllerScene").GetComponent<sceneManager>();

        if (ChangeScene != null)
        {
            ChangeScene.ChangeScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
