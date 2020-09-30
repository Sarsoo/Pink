using System.Collections;
using UnityEngine;

namespace Pink.Mechanics
{
    class FreezeControl: MonoBehaviour
    {
        public PinkController player;

        public IEnumerator Run(float duration)
        {
            player.controlAllowed = false;
            yield return new WaitForSeconds(duration / 1000f);
            player.controlAllowed = true;
        }
    }
}
