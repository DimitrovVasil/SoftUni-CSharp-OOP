using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] splitInfo = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string command = splitInfo[0];
                    string teamName = splitInfo[1];

                    if (command.StartsWith("Team"))
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }

                    else if (command.StartsWith("Add"))
                    {
                        string playerName = splitInfo[2];
                        //{Endurance};{Sprint};{Dribble};{Passing};{Shooting}
                        int endurance = int.Parse(splitInfo[3]);
                        int sprint = int.Parse(splitInfo[4]);
                        int dribble = int.Parse(splitInfo[5]);
                        int passing = int.Parse(splitInfo[6]);
                        int shooting = int.Parse(splitInfo[7]);

                        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stats);

                        if (teams.Any(team => team.Name == teamName))
                        {
                            teams.First(team => team.Name == teamName).AddPlayer(player);
                        }

                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }

                    else if (command.StartsWith("Remove"))
                    {
                        string playerName = splitInfo[2];

                        if (teams.Any(team => team.Name == teamName))
                        {
                            Team team = null;
                            team = teams.First(team => team.Name == teamName);
                            team.RemovePlayer(playerName);

                        }
                    }

                    else if (command.StartsWith("Rating"))
                    {
                        if (teams.Any(team => team.Name == teamName))
                        {
                            Team team = null;
                            team = teams.First(team => team.Name == teamName);
                            Console.WriteLine(team.ToString());
                        }

                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
