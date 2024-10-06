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
