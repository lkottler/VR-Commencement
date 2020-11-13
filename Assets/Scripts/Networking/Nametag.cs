using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Nametag : MonoBehaviour
{
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        //GetComponent<TextMesh>().text = (PhotonNetwork.LocalPlayer.NickName != "") ? PhotonNetwork.LocalPlayer.NickName : "Guest";
        GetComponent<TextMesh>().text = PV.Owner.NickName;
    }
}
