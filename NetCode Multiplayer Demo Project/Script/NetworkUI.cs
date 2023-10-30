
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField]
    private Button startServerButton;
    [SerializeField]
    private Button startHostButton;
    [SerializeField]
    private Button startClientButton;
    [SerializeField] private TextMeshProUGUI playerCountText;

    private NetworkVariable<int> playersNum = new NetworkVariable<int>(0,NetworkVariableReadPermission.Everyone);
    
    private void Update()
    {
        playerCountText.text = "Players: " + playersNum.Value.ToString();

        if (!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            
        });
        startServerButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            
        });
        startClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            
        });
    }

}
