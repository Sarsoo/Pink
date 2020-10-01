using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Cinemachine;

namespace Pink.Graphics
{
    public class Flash : MonoBehaviour
    {
        public Light2D flasher;

        public IEnumerator Run(int count = 5, float upTime = 100f, float downTime = 100f, float intensity = 1)
        {
            for(int i = 0; i < count; i++)
            {
                flasher.intensity = intensity;
                yield return new WaitForSeconds(upTime / 1000f);
                flasher.intensity = 0;
                yield return new WaitForSeconds(downTime / 1000f);
            }
        }
    }

}
