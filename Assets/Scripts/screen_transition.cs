using UnityEngine;
using System.Collections;
public class screen_transition : MonoBehaviour
{
    public Animator animator;
    public bool IsVisibleLoadScene = true;
    public GameObject LoadCan;
    void Start ()
    {
        StartCoroutine(WaitLoadScene());
    }
    // Update is called once per frame
    void Update()
    {
        if(!IsVisibleLoadScene)
        {
            EndDarkSreen();
            LoadCan.SetActive(false);
            IsVisibleLoadScene = true;
        }
    }
    public void StartDarkSreen ()
    {
        animator.SetTrigger("Start");
    }

    public void EndDarkSreen()
    {
        animator.SetTrigger("End");
    }
    private IEnumerator WaitLoadScene ()
    {
        yield return new WaitForSeconds(10.0f);
        IsVisibleLoadScene = false;
    }
}
