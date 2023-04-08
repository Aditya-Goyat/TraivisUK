using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using JetBrains.Annotations;
using Photon.Pun;

public class ImageController : MonoBehaviour
{
    [SerializeField] Sprite[] pptImages;
    [SerializeField] Image pptDisplay;
    [SerializeField] PhotonView photonView;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        pptDisplay.sprite = pptImages[0];
    }

    public void OnRightButtonClick()
    {
        photonView.RPC("SynchronizeRightClick", RpcTarget.All);
    }

    public void OnLefButtonClick()
    {
        photonView.RPC("SynchronizeLeftClick", RpcTarget.All);
    }

    public void SynchronizeRightClick()
    {
        pptDisplay.sprite = pptImages[(++currentIndex) % pptImages.Length];
    }

    public void SynchronizeLeftClick()
    {
        pptDisplay.sprite = pptImages[(--currentIndex) % pptImages.Length];
    }
}
