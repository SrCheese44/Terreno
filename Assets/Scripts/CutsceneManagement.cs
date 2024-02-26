using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManagement : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector playableDirector;

    bool skipCutscene = false;

    public void SkipCinematic(float time) 
    {
        playableDirector.time = time;
        playableDirector.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !skipCutscene)
        {
            SkipCinematic(979f); 
            skipCutscene = true;
        }
    }
}
