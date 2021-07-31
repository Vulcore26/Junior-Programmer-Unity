using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string player;
    public int highScore;
    public List<HighScores> league = new List<HighScores>();
    public class HighScores : IComparable<HighScores>
    {
        public string playerName;
        public int highScore;

        public int CompareTo(HighScores other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The temperature comparison depends on the comparison of
            // the underlying Double values.
            return other.highScore - highScore;
        }
    }
    public string GetScores()
    {
        if (league.Count == 0)
            return "";

        league.Sort();
        string s = "TOP SCORES \n\r";
        int i = 0;
        foreach (HighScores h in league)
        {
            if (i >= 4)
                continue;

            s += h.playerName + " : " + h.highScore + "\n\r";
            i++;
        }

        return s;
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public HighScores UpdatePlayerHighScore(int newScore)
    {
        HighScores r = new HighScores();
        foreach( HighScores h in league)
        {
            if( h.playerName == player)
            {
                if (newScore > h.highScore)
                    h.highScore = newScore;

                return h;
            }
        }
        r.playerName = player;
        r.highScore = newScore;
        league.Add(r);
        return r;
    }
}
