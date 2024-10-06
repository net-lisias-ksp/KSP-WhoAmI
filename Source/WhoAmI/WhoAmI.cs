/*
	This file is part of Who Am I? /L
		© 2024 LisiasT : http://lisias.net <support@lisias.net>

	Who Am I? /L is licensed as follows:
		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	Who Am I? /L is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 3.0
	along with Who Am I? /L. If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using UnityEngine;

namespace WhoAmI
{
    /// <summary>
    /// Display information about Kerbal in an IVA view
    /// </summary>
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class WhoAmI : MonoBehaviour
    {
        /// <summary>
        /// Mod constructor
        /// </summary>
        void Awake()
        {
            GameEvents.OnIVACameraKerbalChange.Add(OnIVACameraKerbalChange);
            GameEvents.OnCameraChange.Add(OnCameraChange);
        }


        /// <summary>
        /// Clean behind ourselfs
        /// </summary>
        void OnDestroy()
        {
            GameEvents.OnIVACameraKerbalChange.Remove(OnIVACameraKerbalChange);
            GameEvents.OnCameraChange.Remove(OnCameraChange);
        }


        /// <summary>
        /// Get transefr dialog on ALT+B
        /// </summary>
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) &&
                GameSettings.MODIFIER_KEY.GetKey() &&
                CameraManager.Instance.currentCameraMode == CameraManager.CameraMode.IVA &&
                CrewHatchController.fetch.CrewDialog == null)
            {
                CrewHatchController.fetch.SpawnCrewDialog(
                    CameraManager.Instance.IVACameraActiveKerbal.InPart,
                    false,
                    true
                );
            }
        }


        /// <summary>
        /// Show info when switching to IVA
        /// </summary>
        /// <param name="cameraMode"></param>
        private void OnCameraChange(CameraManager.CameraMode cameraMode)
        {
            if (cameraMode == CameraManager.CameraMode.IVA)
                ShowInfo();
        }


        /// <summary>
        /// Show info when switching between Kerbals in IVA
        /// </summary>
        /// <param name="kerbal"></param>
        private void OnIVACameraKerbalChange(Kerbal kerbal)
        {
            ShowInfo();
        }


        /// <summary>
        /// Simple info
        /// </summary>
        private void ShowInfo()
        {
            Kerbal kerbinaut = CameraManager.Instance.IVACameraActiveKerbal;
            ScreenMessages.PostScreenMessage(
                String.Format(
                    "{0} - {1} Level {2}\n({3})",
                    kerbinaut.crewMemberName,
                    kerbinaut.protoCrewMember.experienceTrait.TypeName,
                    kerbinaut.protoCrewMember.experienceLevel,
                    kerbinaut.InPart.partInfo.title
                )
            );
        }
    }
}
