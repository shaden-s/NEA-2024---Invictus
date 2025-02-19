using TMPro;
using Photon.Realtime;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class ScoreboardItem : MonoBehaviourPunCallbacks
{
    Player player;
    
    public TMP_Text usernameText;
    public TMP_Text pointsText;
    public TMP_Text killsText;
    public TMP_Text deathsText;

    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
        this.player = player;
        UpdateStats();
    }

    void Update()
    {
        UpdateStats();
    }

    void UpdateStats()
    {
        if (player.CustomProperties.TryGetValue("kills", out object kills))
        {
            killsText.text = kills.ToString();
        }
        if (player.CustomProperties.TryGetValue("deaths", out object deaths))
        {
            deathsText.text = deaths.ToString();
        }
        if (player.CustomProperties.TryGetValue("points", out object points))
        {
            pointsText.text = points.ToString();
        }

    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer == player)
        {
            if (changedProps.ContainsKey("kills") || changedProps.ContainsKey("deaths") || changedProps.ContainsKey("points"))
            {
                UpdateStats();
            }
        }
    }
}
