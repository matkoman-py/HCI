using ReservationSystem.Models;
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
                db.Users.Add(new User("pera", "pera", "pera@gmail.com", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Customer));
                db.Users.Add(new User("mika", "mika", "mika@gmail.com", "Mika", "Mikic", new DateTime(1998, 9, 5), Role.Administrator));
                db.Users.Add(new User("zika", "zika", "zika@gmail.com", "Zika", "Zikic", new DateTime(1997, 9, 5), Role.Organizier));

                FieldOfWork fieldOfWork1 = new FieldOfWork() { Name = "Restoran" };
                FieldOfWork fieldOfWork2 = new FieldOfWork() { Name = "Ketering" };
                FieldOfWork fieldOfWork3 = new FieldOfWork() { Name = "Orkestar" };
                FieldOfWork fieldOfWork4 = new FieldOfWork() { Name = "Drugo" };

                db.FieldsOfWork.Add(fieldOfWork1);
                db.FieldsOfWork.Add(fieldOfWork2);
                db.FieldsOfWork.Add(fieldOfWork3);
                db.FieldsOfWork.Add(fieldOfWork4);

                Associate associate1 = new Associate("Petrus", "Korzo 1", "Dobar restoran", fieldOfWork1);
                db.Associates.Add(associate1);
                Associate associate2 = new Associate("Machiato", "Preko puta limanskog parka", "Loš restoran", fieldOfWork1);
                db.Associates.Add(associate2);

                Offer of1 = new Offer(associate1, "Meni ručak", 1000, "Odlična ponuda!", "nema slike");
                db.Offers.Add(of1);
                Offer of2 = new Offer(associate1, "Velika gozba", 20000, "Dobra ponuda!", "nema slike");
                db.Offers.Add(of2);
                Offer of3 = new Offer(associate2, "Zakup lokala", 15000, "Zakupite naš lokal!", "nema slike");
                db.Offers.Add(of3);
                Offer of4 = new Offer(associate2, "Zakup stola", 2000, "Zakupite sto u našem lokalu!", "nema slike");
                db.Offers.Add(of4);
                OrganizierTask or1 = new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "komentar", UserApproval.Prihvacen);

                OrganizierTask or2 = new OrganizierTask("Zadatak2", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "komentar", UserApproval.Prihvacen);

                OrganizierTask or3 = new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "komentar", UserApproval.Prihvacen);

                OrganizierTask or4 = new OrganizierTask("Zadatak4", "Četvrti zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "komentar", UserApproval.Neobradjen);

                OrganizierTask or5 = new OrganizierTask("Zadatak5", "Peti zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "komentar", UserApproval.Neobradjen);

                OrganizierTask or6 = new OrganizierTask("Zadatak6", "Šesti zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, true, "komentar", UserApproval.Neobradjen);

                OrganizierTask or7 = new OrganizierTask("Zadatak7", "Sedmi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "komentar", UserApproval.Neobradjen);

                OrganizierTask or8 = new OrganizierTask("Zadatak8", "Osmi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "komentar", UserApproval.Neobradjen);

                OrganizierTask or9 = new OrganizierTask("Zadatak9", "Deveti zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, true, "komentar", UserApproval.Neobradjen);

                db.OrganizierTasks.Add(or1);
                db.OrganizierTasks.Add(or2);
                db.OrganizierTasks.Add(or3);

                var partyType1 = new PartyType() { Name = "Rođendan" };
                var partyType2 = new PartyType() { Name = "Godišnjica" };
                var partyType3 = new PartyType() { Name = "Drugo" };

                db.PartyTypes.Add(partyType1);
                db.PartyTypes.Add(partyType2);
                db.PartyTypes.Add(partyType3);

                PartyRequest pr = new PartyRequest(partyType1, 500, "Šekspirova 5", new DateTime(2022, 9, 5), 1999, false, "Plesanje", "Kuvanje", RequestState.Accepted, 1);
                PartyRequest pr1 = new PartyRequest(partyType1, 550, "Alekova ulica 26", new DateTime(2021, 9, 5), 1999, false, "Zezanje", "White Party", RequestState.Active, 1);
                pr1.OrganiserId = 3;
                PartyRequest pr2 = new PartyRequest(partyType1, 550, "Bulevar oslobođenja 10", new DateTime(2020, 9, 5), 1999, false, "Kanada", "Narodnjaci", RequestState.Accepted, 1);
                
                PartyRequest pr3 = new PartyRequest(partyType1, 8000, "Bulevar evrope 22", new DateTime(2021, 10, 8), 50, false, "Banana split", "Ako je drina granica popicemo je", RequestState.Pending, 1);
                PartyRequest pr4 = new PartyRequest(partyType1, 5500, "Alekova ulica 55", new DateTime(2022, 9, 3), 20, false, "BOBI I COBI", "Prelo", RequestState.Pending, 1);
                PartyRequest pr5 = new PartyRequest(partyType1, 25500, "Bulevar oslobođenja 5", new DateTime(2022, 9, 5), 200, false, "Tekela", "Krajiska zurka", RequestState.Accepted, 1);
                PartyRequest pr6 = new PartyRequest(partyType1, 50000, "Bulevar evrope 54", new DateTime(2022, 9, 5), 15, false, "Pakle", "Duvanje", RequestState.Rejected, 1);
                PartyRequest pr7 = new PartyRequest(partyType1, 1500, "Narodnog fronta 20", new DateTime(2021, 9, 4), 40, false, "Zare i Goci", "Zezancija", RequestState.Pending, 1);
                PartyRequest pr8 = new PartyRequest(partyType2, 22000, "Narodnog fronta 5", new DateTime(2021, 9, 3), 25, false, "Bahanalija", "Opsta zurka", RequestState.Accepted, 1);
                PartyRequest pr10 = new PartyRequest(partyType3, 90000, "Somborska 5", new DateTime(2017, 9, 26), 50, false, "Dzabana", "Semafor party", RequestState.Rejected, 1);
                pr2.OrganiserId = 3;
                pr3.OrganiserId = 3;
                pr4.OrganiserId = 3;
                pr5.OrganiserId = 3;
                pr6.OrganiserId = 3;
                pr7.OrganiserId = 3;
                pr8.OrganiserId = 3;
                pr10.OrganiserId = 3;

                db.PartyRequests.Add(pr1);
                db.PartyRequests.Add(pr2);
                db.PartyRequests.Add(pr3);
                db.PartyRequests.Add(pr4);
                db.PartyRequests.Add(pr5);
                db.PartyRequests.Add(pr6);
                db.PartyRequests.Add(pr7);
                db.PartyRequests.Add(pr8);
                db.PartyRequests.Add(pr10);

                Suggestion sug = new Suggestion(new List<OrganizierTask>(){
                    or1,or6,or3
                }, "Odličan predlog!", pr2);
                Suggestion sug2 = new Suggestion(new List<OrganizierTask>(){
                    or4,or5,or2
                }, "Osrednji predlog!", pr1);
                Suggestion sug3 = new Suggestion(new List<OrganizierTask>(){
                    or7,or8,or9
                }, "Okej predlog!", pr3);

                sug3.Answered = AnsweredType.Prihvacen;

                db.Suggestions.Add(sug);
                db.Suggestions.Add(sug2);
                db.Suggestions.Add(sug3);
                db.SaveChanges();
            }

        }
    }
}
