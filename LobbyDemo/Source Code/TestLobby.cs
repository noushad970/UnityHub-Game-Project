using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Collections.Generic;

public class TestLobby : MonoBehaviour
{
    private Lobby hostLobby;
    private Lobby JoinedLobby;
    private float heartBeatTimer;
    private string playerName;
    private float lobbyUpdateTimer;
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        playerName = "Noushad" + UnityEngine.Random.Range(1, 100);
        Debug.Log(playerName);
    }
    private void Update()
    {
        HandleLobbyHeartBeat();
        HandleLobbyPollForUpdate();
    }

    private async void HandleLobbyHeartBeat()
    {
        if (hostLobby != null)
        {
            heartBeatTimer -= Time.deltaTime;
            if (heartBeatTimer < 0f)
            {
                float heartBeatMax = 15;
                heartBeatTimer = heartBeatMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }
    private async void HandleLobbyPollForUpdate()
    {

        if (JoinedLobby != null)
        {
            lobbyUpdateTimer -= Time.deltaTime;
            if (lobbyUpdateTimer < 0f)
            {
                float lobbyUpdateTimerMax = 1.1f;
                lobbyUpdateTimer = lobbyUpdateTimerMax;

                Lobby lobby = await LobbyService.Instance.GetLobbyAsync(JoinedLobby.Id);
                JoinedLobby = lobby;
            }
        }
    }

    private async void CreateLobby()
    {
        try { string LobbyName = "MyLobby";
            int maxPlayer = 4;
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer(),
                Data = new Dictionary<string, DataObject> {
                    { "GameMode",new DataObject(DataObject.VisibilityOptions.Public,"CaptureTheFlag"/*,DataObject.IndexOptions.S1*/)},
                    {"Map",new DataObject(DataObject.VisibilityOptions.Public,"De_Dust2") }
                }

            };


            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(LobbyName, maxPlayer, createLobbyOptions);
            hostLobby = lobby;
            Debug.Log("Created Lobby! " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);
            printPlayer(hostLobby);
        } catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }

    }
    private async void ListLobby()
    {

        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions {
                Count = 25,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots,"0",QueryFilter.OpOptions.GT),
                    //new QueryFilter(QueryFilter.FieldOptions.S1,"CaptureTheFlag",QueryFilter.OpOptions.EQ)
                },
                Order = new List<QueryOrder> { new QueryOrder(false, QueryOrder.FieldOptions.Created) }

            };
            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);

            Debug.Log("Lobbies found: " + queryResponse.Results.Count);
            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Data["GameMode"].Value);
            }
        } catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
    private async void JoinLobbyByCode(string LobbyCode)
    {
        try
        {
            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions {
                Player = GetPlayer(),

            };

            Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(LobbyCode, joinLobbyByCodeOptions);
            JoinedLobby = lobby;
            Debug.Log($"JoinLobbyByCode: {LobbyCode}");

        } catch (LobbyServiceException e) { Debug.Log(e);
        }
    }

    private async void QuickJoinLobby()
    {
        try
        {
            await Lobbies.Instance.QuickJoinLobbyAsync();

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
    private Player GetPlayer()
    {
        return new Player
        {
            //Id= AuthenticationService.Instance.PlayerId,
            Data = new Dictionary<string, PlayerDataObject>
                    {
                        { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
                    }
        };

    }
    private void printPlayers()
    {
        printPlayer(JoinedLobby);
    }
    private void printPlayer(Lobby lobby)
    {
        Debug.Log("Player in Lobby " + lobby.Name + " " + lobby.Data["GameMode"].Value + " " + lobby.Data["Map"].Value);
        foreach (Player player in lobby.Players)
        {
            Debug.Log(player.Id + " " + player.Data["PlayerName"].Value);
        }
    }
    private async void UpdateLobbyGameMood(string gameMode)
    {
        try
        {
            hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject> {
                    {
                        "GameMode",new DataObject(DataObject.VisibilityOptions.Public,gameMode)
                    } }
            });
            JoinedLobby = hostLobby;

        }
        catch (LobbyServiceException e) { Debug.Log(e); }
    }
    private async void updatePlayerName(string newPlayerName)
    {
        try
        {
            playerName = newPlayerName;
            await LobbyService.Instance.UpdatePlayerAsync(JoinedLobby.Id, AuthenticationService.Instance.PlayerId, new UpdatePlayerOptions
            {
                Data = new Dictionary<string, PlayerDataObject> { { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) } }
            });

        }
        catch(LobbyServiceException e) { Debug.Log(e); }
     }
    
    private async void LeaveLobby()
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(JoinedLobby.Id, AuthenticationService.Instance.PlayerId);
        }
        catch(LobbyServiceException ex) { Debug.Log(ex); }
    }
    private async void KickedPlayer()
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(JoinedLobby.Id,  JoinedLobby.Players[1].Id);
        }
        catch (LobbyServiceException ex) { Debug.Log(ex); }
    }
    private async void MigrateLobbyHost()
    {
        try
        {
            hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                HostId = JoinedLobby.Players[1].Id
            });
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
    private async void DeleteLobby()
    {
        try
        {
            await LobbyService.Instance.DeleteLobbyAsync(JoinedLobby.Id);  
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
}
