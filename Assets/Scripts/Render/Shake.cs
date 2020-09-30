using System.Collections;
using UnityEngine;
using Cinemachine;

namespace Pink.Graphics
{
    public class Shake : MonoBehaviour
    {
        public IEnumerator Run(float duration, float amplitude = .5f, float frequency = 10f)
        {
            var cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            var profile = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            profile.m_AmplitudeGain = amplitude;
            profile.m_FrequencyGain = frequency;

            yield return new WaitForSeconds(duration / 1000f);

            profile.m_AmplitudeGain = 0f;
            profile.m_FrequencyGain = 0f;
        }
    }

}
