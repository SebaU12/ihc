using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour

{
    public Transform Door; 
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool isAnimationRunning= false;
    // Start is called before the first frame update
    void Start()
    {
        Door.position = startPosition;
    }

    public void RunAnimation()
    {
        if (!isAnimationRunning)
        {
            isAnimationRunning = true;
            StartCoroutine(CloseDoorAnimation());
        }
    }

    private IEnumerator CloseDoorAnimation()
    {
        float animationTime = 2.0f;
        float time = 0.0f;

        while (time < animationTime)
        {
            time += Time.deltaTime;
            Door.position = Vector3.Lerp(startPosition, endPosition, time / animationTime);
            yield return null;
        }
        
        EndAnimation();
        isAnimationRunning = false;
    }

    private void EndAnimation()
    {
        Debug.Log("La animacion termino");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
