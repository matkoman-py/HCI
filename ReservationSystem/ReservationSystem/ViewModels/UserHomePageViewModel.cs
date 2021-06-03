using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class UserHomePageViewModel : BaseViewModel
    {

        
        public List<Suggestion> Suggestions { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public static string SelectedId { get; set; }
        public ICommand LogOutCommand
        {
            get; set;
        }
        public ICommand ProfileCommand
        {
            get; set;
        }
        public ICommand RequestCreationCommand
        {
            get; set;
        }
        public static ICommand RequestViewCommand
        {
            get; set;
        }


        public UserHomePageViewModel(ICommand updateViewCommand)
        {

            UpdateViewCommand = updateViewCommand;
            LogOutCommand = new DelegateCommand(LogOut);
            ProfileCommand = new DelegateCommand(Profile);
            RequestViewCommand = new RequestViewCommand(UpdateViewCommand);
            RequestCreationCommand = new DelegateCommand(RequestCreation);
            Suggestions = getOffers();
        }

        public void RequestCreation()
        {
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand));
        }

        public void Profile()
        {
           
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand));
        }

        public void LogOut()
        {
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
        }

        
        public List<Suggestion> getOffers()
        {
            // OVDE TREBA IZ DB UZETI SVE SUGGESTIONE KOJI IMAJU ID USERA KOJI JE PROSLEDJEN OVOM PROZORU
            // TO DALJE SALJES
            return new List<Suggestion>()
            {
                new Suggestion("1",new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"kurcina", "Nije obradjeno"),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno"),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno")
                }, "MASU JAK PREDLOG1", new PartyRequest()),
                new Suggestion("2",new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"", "Nije obradjeno"),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno"),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno")
                }, "MASU JAK PREDLOG2", new PartyRequest()),
                new Suggestion("3",new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"", "Nije obradjeno"),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno"),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", "Nije obradjeno")
                }, "MASU JAK PREDLOG3", new PartyRequest())
            };
            /*return new List<SuggestionWithCommand>()
            {
                
                new SuggestionWithCommand(new Suggestion("1",new List<OrganizierTask>(){ 
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,""),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,""),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"")
                }, "MASU JAK PREDLOG1", new PartyRequest()),UpdateViewCommand),
                new SuggestionWithCommand(new Suggestion("2",new List<OrganizierTask>(){
                    new OrganizierTask("Zadaxxtak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,""),
                    new OrganizierTask("Zadatfafaacak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,""),
                    new OrganizierTask("Zadaxxaxtak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"")
                }, "MASU JAK PREDLOG2", new PartyRequest()),UpdateViewCommand),
                new SuggestionWithCommand(new Suggestion("3",new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,""),
                    new OrganizierTask("Zadatak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,""),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"")
                }, "MASU JAK PREDLOG3", new PartyRequest()),UpdateViewCommand)

            };*/
        }
    }
}
