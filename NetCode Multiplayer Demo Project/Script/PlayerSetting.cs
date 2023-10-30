using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetting : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private MeshRenderer meshRenderer;
     private NetworkVariable<FixedString128Bytes> networkPlayerName= new NetworkVariable<FixedString128Bytes>("Player: 0 ",NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Server);
    public List<Color>colors = new List<Color>();

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    public override void OnNetworkSpawn()
    {
        networkPlayerName.Value = "Player: " + (OwnerClientId + 1);
        playerName.text= networkPlayerName.Value.ToString();
        meshRenderer.material.color = colors[(int)OwnerClientId];
    }

}
