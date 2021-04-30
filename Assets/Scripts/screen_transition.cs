using UnityEngine;
using System.Collections;
public class screen_transition : MonoBehaviour
{
    public Animator animator;
    public GameObject LoadCan;
    void Start ()
    {
        Time.timeScale = 1;
        StartCoroutine(WaitLoadScene());
    }
    public void StartDarkSreen ()
    {
        animator.SetTrigger("Start");
    }

    public void EndDarkSreen()
    {
        animator.SetTrigger("End");
    }

    public void Blood (float f)
    {
        StartCoroutine(BloodI(f));
    }

    private IEnumerator BloodI(float f)
    {   
        yield return new WaitForSeconds(f);
        animator.SetTrigger("Blood");
    }

    private IEnumerator WaitLoadScene ()
    {
        yield return new WaitForSeconds(2f);
        StartDarkSreen();
        LoadCan.SetActive(false);
    }
}
