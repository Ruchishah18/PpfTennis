
using System.Text;

namespace Tennis.Game
{
    public class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        private readonly static string[] equalScore = ["Love-All", "Fifteen-All", "Thirty-All", "Deuce", "Deuce"];
        private readonly static string[] ScoreInWords = ["Love", "Fifteen", "Thirty", "Forty"];
        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }
      
        public string GetScore()
        {
            var diffInResult = m_score1 - m_score2;
            if (diffInResult == 0)
            {
                return equalScore[m_score1];
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                // If Different of result in positive number then send player 1's name otherwise player 2's name.
                if (diffInResult >= 1)
                { 
                    return GetAchivement(diffInResult,player1Name);
                }
                else
                {
                    return GetAchivement(diffInResult, player2Name);
                }
            }
            else
            {
                return string.Format("{0}-{1}",ScoreInWords[m_score1], ScoreInWords[m_score2]);
            }
        }

        private static string GetAchivement(int result, string playerName)
        {
            if(Math.Abs(result) == 1)
            {
                return string.Format("{0} {1}", PlayerAchivement.Advantage.ToString(), playerName);
            }
            else
            {
                return string.Format("{0} for {1}", PlayerAchivement.Win.ToString(), playerName);
            }
        }
        public enum PlayerAchivement
        {
            Advantage,
            Win
        }
    }
}
