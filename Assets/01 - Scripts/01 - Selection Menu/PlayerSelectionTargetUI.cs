using UnityEngine;

public class PlayerSelectionTargetUI : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    internal void EnableSelection()
    {
        sr.enabled = true;
    }

    internal void SetTargetCharacter(SelectableCharacter character)
    {
        transform.position = character.transform.position;
    }

    internal void FinalizeAnimation()
    {
        animator.SetBool("MadeSelection", true);
    }
}
