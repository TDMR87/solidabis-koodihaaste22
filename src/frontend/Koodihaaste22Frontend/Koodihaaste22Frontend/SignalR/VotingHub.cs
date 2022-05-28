namespace Koodihaaste22Frontend.SignalR;

/// <summary>
/// SignalR hub that acts as a messaging service 
/// for notifying clients of any changes to restaurant votes.
/// </summary>
public class VotingHub : Hub
{
    /// <summary>
    /// Notifies each connected client that a vote has been added or removed.
    /// </summary>
    /// <returns></returns>
    public Task VoteRestaurant()
    {
        return Clients.All.SendAsync("VoteReceived");
    }
}
