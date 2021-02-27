using UnityEngine;
using System.Collections;
public class screen_transition : MonoBehaviour
{
    public Animator animator;
    public GameObject LoadCan;
   // public bool IsRealLoading = true;
    void Start ()
    { //if(!IsRealLoading)
        //{
            StartCoroutine(WaitLoadScene());
        //}
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
        yield return new WaitForSeconds(2f);
        StartDarkSreen();
        LoadCan.SetActive(false);
    }
}
