using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentRankingSystem
{
    /// <summary>
    /// Represents a team participating in the tournament.
    /// Implements IComparable for custom sorting:
    /// Points (descending) then Name (ascending).
    /// </summary>
    public class Team : IComparable<Team>
    {
        /// <summary>
        /// Team name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total points earned in the tournament.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Compares teams by Points descending, then by Name ascending.
        /// </summary>
        public int CompareTo(Team other)
        {
            if (other == null) return 1;

            int pointComparison = other.Points.CompareTo(this.Points);
            return pointComparison != 0
                ? pointComparison
                : this.Name.CompareTo(other.Name);
        }
    }

    /// <summary>
    /// Represents a match between two teams.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// First participating team.
        /// </summary>
        public Team Team1 { get; }

        /// <summary>
        /// Second participating team.
        /// </summary>
        public Team Team2 { get; }

        /// <summary>
        /// Score of Team1.
        /// </summary>
        public int Team1Score { get; set; }

        /// <summary>
        /// Score of Team2.
        /// </summary>
        public int Team2Score { get; set; }

        /// <summary>
        /// Initializes a new match.
        /// </summary>
        public Match(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        /// <summary>
        /// Creates a shallow copy of the match for undo functionality.
        /// </summary>
        public Match Clone()
        {
            return new Match(Team1, Team2)
            {
                Team1Score = this.Team1Score,
                Team2Score = this.Team2Score
            };
        }
    }

    /// <summary>
    /// Manages tournament operations including scheduling,
    /// ranking, match recording, and undo functionality.
    /// </summary>
    public class Tournament
    {
        /// <summary>
        /// Stores rankings sorted by points (ascending key).
        /// Each key contains a list to handle duplicate point values.
        /// </summary>
        private SortedList<int, List<Team>> _rankings = new();

        /// <summary>
        /// Maintains match schedule.
        /// </summary>
        private LinkedList<Match> _schedule = new();

        /// <summary>
        /// Stores match history for undo functionality.
        /// </summary>
        private Stack<Match> _undoStack = new();

        /// <summary>
        /// Schedules a match.
        /// </summary>
        public void ScheduleMatch(Match match)
        {
            _schedule.AddLast(match);
        }

        /// <summary>
        /// Records match result, updates team points,
        /// and updates rankings.
        /// </summary>
        public void RecordMatchResult(Match match, int team1Score, int team2Score)
        {
            _undoStack.Push(match.Clone());

            match.Team1Score = team1Score;
            match.Team2Score = team2Score;

            if (team1Score > team2Score)
                match.Team1.Points += 3;
            else if (team2Score > team1Score)
                match.Team2.Points += 3;
            else
            {
                match.Team1.Points += 1;
                match.Team2.Points += 1;
            }

            UpdateRankings(match.Team1);
            UpdateRankings(match.Team2);
        }

        /// <summary>
        /// Updates ranking structure for a team.
        /// </summary>
        private void UpdateRankings(Team team)
        {
            foreach (var entry in _rankings.Values)
                entry.Remove(team);

            if (!_rankings.ContainsKey(team.Points))
                _rankings[team.Points] = new List<Team>();

            _rankings[team.Points].Add(team);
        }

        /// <summary>
        /// Undoes the last recorded match.
        /// </summary>
        public void UndoLastMatch()
        {
            if (_undoStack.Count == 0) return;

            var lastMatch = _undoStack.Pop();

            lastMatch.Team1.Points = 0;
            lastMatch.Team2.Points = 0;

            _rankings.Clear();
            UpdateRankings(lastMatch.Team1);
            UpdateRankings(lastMatch.Team2);
        }

        /// <summary>
        /// Returns sorted rankings (highest points first).
        /// </summary>
        public List<Team> GetRankings()
        {
            return _rankings
                .OrderByDescending(r => r.Key)
                .SelectMany(r => r.Value.OrderBy(t => t))
                .ToList();
        }

        /// <summary>
        /// Returns ranking position of a team using BinarySearch.
        /// </summary>
        public int GetTeamRanking(Team team)
        {
            var rankingList = GetRankings();
            int index = rankingList.BinarySearch(team);
            return index >= 0 ? index + 1 : -1;
        }
    }

    /// <summary>
    /// Entry point of the Tournament Ranking System.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Tournament tournament = new Tournament();

            Team teamA = new Team { Name = "Team Alpha", Points = 0 };
            Team teamB = new Team { Name = "Team Beta", Points = 0 };

            Match match = new Match(teamA, teamB);

            tournament.ScheduleMatch(match);
            tournament.RecordMatchResult(match, 3, 1);

            var rankings = tournament.GetRankings();
            Console.WriteLine(rankings[0].Name); // Expected: Team Alpha

            tournament.UndoLastMatch();
            Console.WriteLine(teamA.Points); // Expected: 0
        }
    }
}
