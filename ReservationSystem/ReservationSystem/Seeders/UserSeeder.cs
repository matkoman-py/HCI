﻿using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Seeders
{
    class UserSeeder
    {
        public void Execute()
        {

            using (var db = new ProjectDatabase())
            {

                if (db.Users.ToList().Count != 0)
                {
                    return;
                }

                db.Users.Add(new User("pera", "pera", "peragmajl", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Customer));
                db.Users.Add(new User("mika", "mika", "mikagmajl", "Mika", "Mikic", new DateTime(1998, 9, 5), Role.Administrator));
                db.Users.Add(new User("zika", "zika", "zikagmajl", "Zika", "Zikic", new DateTime(1997, 9, 5), Role.Organizier));

                FieldOfWork fieldOfWork1 = new FieldOfWork() { Name = "Restaurant" };
                FieldOfWork fieldOfWork2 = new FieldOfWork() { Name = "Catering" };
                FieldOfWork fieldOfWork3 = new FieldOfWork() { Name = "Other" };

                db.FieldsOfWork.Add(fieldOfWork1);
                db.FieldsOfWork.Add(fieldOfWork2);
                db.FieldsOfWork.Add(fieldOfWork3);

                Associate associate = new Associate("Kod Jove", "Kumanovska 2, Zrenjanin", "Nesto nesto nesto", fieldOfWork1);
                db.Associates.Add(associate);

                Offer of1 = new Offer(associate, "Ime", 100, "Opasna ponuda1", "nema slike");
                db.Offers.Add(of1);
                Offer of2 = new Offer(associate, "Ime", 150, "Opasna ponuda2", "ima slike");
                db.Offers.Add(of2);
                Offer of3 = new Offer(associate, "Ime", 200, "Opasna ponuda3", "nema slike");
                db.Offers.Add(of3);
                OrganizierTask or1 = new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "kurcina", UserApproval.Prihvacen);

                OrganizierTask or2 = new OrganizierTask("Zadatak2", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Prihvacen);

                OrganizierTask or3 = new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Prihvacen);

                OrganizierTask ora1 = new OrganizierTask("Zadatak11", "Prvi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "kurcina", UserApproval.Neobradjen);

                OrganizierTask ora2 = new OrganizierTask("Zadatak22", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

                OrganizierTask ora3 = new OrganizierTask("Zadatak33", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, true, "kurcina", UserApproval.Neobradjen);

                db.OrganizierTasks.Add(or1);
                db.OrganizierTasks.Add(or2);
                db.OrganizierTasks.Add(or3);

                var partyType1 = new PartyType() { Name = "Birthday" };
                var partyType2 = new PartyType() { Name = "Anniversary" };
                var partyType3 = new PartyType() { Name = "Other" };

                db.PartyTypes.Add(partyType1);
                db.PartyTypes.Add(partyType2);
                db.PartyTypes.Add(partyType3);

                PartyRequest pr = new PartyRequest(partyType1, 500, "Mite cenica1", new DateTime(2022, 9, 5), 1999, false, "Plesanje", "Kuvanje", RequestState.Accepted, 1);
                PartyRequest pr1 = new PartyRequest(partyType1, 550, "Mite cenica2", new DateTime(2021, 9, 5), 1999, false, "Zezanje", "White Party", RequestState.Active, 1);
                pr1.OrganiserId = 3;
                PartyRequest pr2 = new PartyRequest(partyType1, 550, "Mite cenica3", new DateTime(2020, 9, 5), 1999, false, "Kanada", "Narodnjaci", RequestState.Accepted, 1);
                
                PartyRequest pr3 = new PartyRequest(partyType1, 550, "Mite cenica4", new DateTime(2022, 9, 4), 1999, false, "Banana split", "Ako je drina granica popicemo je", RequestState.Pending, 1);
                PartyRequest pr4 = new PartyRequest(partyType1, 550, "Mite cenica5", new DateTime(2022, 9, 3), 1999, false, "BOBI I COBI", "Prelo", RequestState.Pending, 1);
                PartyRequest pr5 = new PartyRequest(partyType1, 550, "Mite cenica6", new DateTime(2022, 9, 5), 1999, false, "Tekela", "Krajiska zurka", RequestState.Accepted, 1);
                PartyRequest pr6 = new PartyRequest(partyType1, 550, "Mite cenica7", new DateTime(2022, 9, 5), 1999, false, "Pakle", "Duvanje", RequestState.Rejected, 1);
                PartyRequest pr7 = new PartyRequest(partyType1, 550, "Mite cenica8", new DateTime(2021, 9, 4), 1999, false, "Zare i Goci", "Zezancija", RequestState.Pending, 1);
                PartyRequest pr8 = new PartyRequest(partyType2, 600, "Mite cenica9", new DateTime(2021, 9, 3), 1999, false, "Bahanalija", "Opsta zurka", RequestState.Accepted, 1);
                PartyRequest pr9 = new PartyRequest(partyType3, 700, "Mite cenica10", new DateTime(1997, 9, 5), 1999, false, "Gospodsko", "Kosulja party", RequestState.Active, 1);
                PartyRequest pr10 = new PartyRequest(partyType3, 700, "Mite cenica11", new DateTime(1997, 9, 5), 1999, false, "Dzabana", "Semafor party", RequestState.Rejected, 1);
                pr2.OrganiserId = 3;
                pr3.OrganiserId = 3;
                pr4.OrganiserId = 3;
                pr5.OrganiserId = 3;
                pr6.OrganiserId = 3;
                pr7.OrganiserId = 3;
                pr8.OrganiserId = 3;
                pr9.OrganiserId = 3;
                pr10.OrganiserId = 3;

                db.PartyRequests.Add(pr1);
                db.PartyRequests.Add(pr2);
                db.PartyRequests.Add(pr3);
                db.PartyRequests.Add(pr4);
                db.PartyRequests.Add(pr5);
                db.PartyRequests.Add(pr6);
                db.PartyRequests.Add(pr7);
                db.PartyRequests.Add(pr8);
                db.PartyRequests.Add(pr9);
                db.PartyRequests.Add(pr10);

                Suggestion sug = new Suggestion(new List<OrganizierTask>(){
                    or1,or2,or3
                }, "MASU JAK PREDLOG1", pr2);
                Suggestion sug2 = new Suggestion(new List<OrganizierTask>(){
                    or1,or2,or3
                }, "MASU JAK PREDLOG1", pr1);

                db.Suggestions.Add(sug2);
                db.Suggestions.Add(sug);
                db.SaveChanges();
            }

        }
    }
}
