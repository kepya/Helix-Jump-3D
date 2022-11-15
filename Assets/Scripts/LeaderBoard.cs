/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderBoard
{

    //Post player score to a leaderboard
   public void PostPlayerScore(int score)
   {
        Social.ReportScore(score, "player1", (bool success) =>
        {
            //handle success or faiilure
        });
   }
   public void ShowLeaderBoardUI()
   {
        Social.ShowLeaderboardUI();
   }

    //Get LeaderBoardData
    public void LeaderBoardData1()
    {
        ILeaderboard lb = PlayGamesPlatform.Instance.CreateLeaderboard();
        lb.id = "MY_LEADERBOARD_ID";
        lb.LoadScores(ok =>
        {
            if (ok)
            {
                LoadUsersAndDisplay(lb);
            }
            else
            {
                Debug.Log("Error retrieving leadboardi");
            }
        });
    }
    public void LeaderBoardData()
    {
        PlayGamesPlatform.Instance.LoadScores(
            GPGSIds.leaderboard_leaders_in_smoketesting, 
            LeaderboardStart.PlayerCentered,
            100,
            LeaderboardCollection.Public,
            LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                mStatus = "Leaderboard data valid: " + data.Valid;
                mStatus += "\n approx:" + data.ApproximateCount + " have " + data.Scores.Length;
            }
            );
    }

    public void GetNextPage(LeaderboardScoreData data)
    {
        PlayGamesPlatform.Instance.LoadMoreScore(data.NextPageToken, 10, (results) =>
        {
            mStatus = "Leaderboard data valid: " + data.Valid;
            mStatus += "\n approx:" + data.ApproximateCount + " have " + data.Scores.Length;
        });
    }
    internal void LoadUsersAndDisplay(ILeaderboard lb)
    {
        // get the user ids
        List<string> userIds = new List<string>();

        foreach (IScore score in lb.scores)
        {
            userIds.Add(score.userID);
        }
        // load the profiles and display (or in this case, log)
        Social.LoadUsers(userIds.ToArray(), (users) =>
        {
            string status = "Leaderboard loading: " + lb.title + " count = " +
              lb.scores.Length;
            foreach (IScore score in lb.scores)
            {
                IUserProfile user = FindUser(users, score.userID);
                status += "\n" + score.formattedValue + " by " +
                  (string)(
                    (user != null) ? user.userName : "**unk_" + score.userID + "**");
            }
            Debug.Log(status);
        });
    }
}
*/