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

                    }, false, "kurcina", UserApproval.Neobradjen);

                OrganizierTask or2 = new OrganizierTask("Zadatak2", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

                OrganizierTask or3 = new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

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

                PartyRequest pr = new PartyRequest(partyType1, 500, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak1", "Duvanje", RequestState.Accepted, 1);
                PartyRequest pr1 = new PartyRequest(partyType2, 500, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak2", "Duvanje", RequestState.Accepted, 1);
                PartyRequest pr2 = new PartyRequest(partyType3, 500, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak3", "Duvanje", RequestState.Accepted, 1);

                PartyRequest pr1 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Zezanje", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr2 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Kanada", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr3 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Banana split", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr4 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "BOBI I COBI", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr5 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Tekela", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr6 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Pakle", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr7 = new PartyRequest(partyType1, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak1", "Duvanje", RequestState.Pending, 1);
                PartyRequest pr8 = new PartyRequest(partyType2, 600, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak2", "Duvanje", RequestState.Accepted, 1);
                PartyRequest pr9 = new PartyRequest(partyType3, 700, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak3", "Duvanje", RequestState.Active, 1);
                PartyRequest pr10 = new PartyRequest(partyType3, 700, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak4", "Duvanje", RequestState.Rejected, 1);

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
                }, "MASU JAK PREDLOG1", pr1);
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
