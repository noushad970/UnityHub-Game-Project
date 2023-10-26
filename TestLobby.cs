using QFSW.QC;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

using Unity.Netcode;


public class TestLobby : NetworkBehaviour
{
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }
    [Command]
    private async void CreateLobby()
    {
        try {
            string lobbyName = "MyLobby";
            int maxPlayer = 4;
            // LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayer);   

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayer);
            Debug.Log("Created loobby! " + lobby.Name + " " + lobby.MaxPlayers);
        }
        catch(LobbyServiceException e) { 
        Debug.Log(e);
        }
    }

    private async void ListLobbies()
    {
        try { 
        QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();
        Debug.Log("Lobbies found: "+queryResponse.Results.Count);

        foreach(Lobby lobby in queryResponse.Results)
        {
            Debug.Log(lobby.Name+" "+lobby.MaxPlayers);
        }
        }
        catch(LobbyServiceException e) { 
        Debug.Log(e);
        }
    }
}
