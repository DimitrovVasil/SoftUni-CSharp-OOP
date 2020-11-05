using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private List<Soldier> privates;

        public Engine()
        {
            privates = new List<Soldier>();
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = inputLine.Split();

                string soldierType = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    Private @private = null;
                    @private = new Private(id, firstName, lastName, salary);

                    privates.Add(@private);
                    Console.WriteLine(@private.ToString());
                }

                if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        int currentId = int.Parse(soldierInfo[i]);

                        Soldier currentPrivate = privates.FirstOrDefault(p => p.Id == currentId);
                        lieutenantGeneral.Privates.Add(currentPrivate);
                    }

                    privates.Add(lieutenantGeneral);
                    Console.WriteLine(lieutenantGeneral.ToString());
                }

                if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    if (soldierInfo[5] != "Airforces" && soldierInfo[5] != "Marines")
                    {
                        continue;
                    }

                    Corp corp = (Corp)Enum.Parse(typeof(Corp), soldierInfo[5]);
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < soldierInfo.Length - 1; i = i + 2)
                    {
                        string currentPart = soldierInfo[i];
                        int currentHours = int.Parse(soldierInfo[i + 1]);

                        Repair repair = new Repair(currentPart, currentHours);
                        engineer.Repairs.Add(repair);
                    }

                    privates.Add(engineer);
                    Console.WriteLine(engineer.ToString());
                }

                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    if (soldierInfo[5] != "Airforces" && soldierInfo[5] != "Marines")
                    {
                        continue;
                    }

                    Corp corp = (Corp)Enum.Parse(typeof(Corp), soldierInfo[5]);
                    Commando commando = new Commando(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < soldierInfo.Length - 1; i = i + 2)
                    {
                        string codeName = soldierInfo[i];
                        string state = soldierInfo[i + 1];

                        if (state == "inProgress" || state == "Finished")
                        {
                            Mission mission = new Mission(codeName, state);
                            commando.Missions.Add(mission);
                        }
                    }

                    privates.Add(commando);
                    Console.WriteLine(commando.ToString());
                }

                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierInfo[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    privates.Add(spy);
                    Console.WriteLine(spy.ToString());
                }
            }
        }
    }
}
