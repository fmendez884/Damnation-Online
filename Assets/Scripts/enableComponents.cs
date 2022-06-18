using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Mirror;

namespace StarterAssets {
    public class enableComponents : NetworkBehaviour
    {
        public Transform target;
        
        // Start is called before the first frame update
        void Start()
        {
            if(isLocalPlayer)
            {
                CharacterController cc = GetComponent<CharacterController>();
                cc.enabled = true;
                ThirdPersonController tpc = GetComponent<ThirdPersonController>();
                tpc.enabled = true;
                PlayerInput pi = GetComponent<PlayerInput>();
                pi.enabled = true;
                GameObject pfc = GameObject.Find("PlayerFollowCamera");
                // pfc.SetActive(true);
                CinemachineVirtualCamera cvc = pfc.GetComponent<CinemachineVirtualCamera>();
                cvc.Follow = target;

            }
        }

    }
}
