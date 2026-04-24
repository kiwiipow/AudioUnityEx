using UnityEngine;
using System;

public class S_FootStepManager : MonoBehaviour
{
    [Serializable]
   struct FootStepSurface
   {
       [SerializeField] private AudioClip[] footsteps;
       [SerializeField] private SurfaceType m_surface;

        AudioClip GetAudio()
        {
            if (footsteps == null || footsteps.Length == 0)
                return null;

            return footsteps[UnityEngine.Random.Range(0, footsteps.Length)];
        }
     
        
   }

    [SerializeField] private FootStepSurface[] m_FootstepsSurfaces;

    public enum SurfaceType { WOOD, GRASS, SAND };

    public static SurfaceType Surface = SurfaceType.GRASS;

    private AudioSource m_Source = null;

    private void Awake()
    {
        m_Source = GetComponent<AudioSource>();
    }
    public void PlayFootSteps()
    {
        if (m_Source == null) return;

        //sound with pitch modification are added to the sound pool, so no play oneshot
        m_Source.clip = m_FootstepsSurfaces[(int)Surface].GetAudio();

        if (m_Source.clip == null) return;
        m_Source.Play();

        //add animation events in animator
    }
    
}
