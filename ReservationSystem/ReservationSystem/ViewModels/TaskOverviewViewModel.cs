using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class TaskOverviewViewModel : BaseViewModel
    {
        public OrganizierTask OrganizierTask { get; set; }

        public Offer SelectedOffer { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand OfferReviewCommand { get; set; }

        public ICommand RequestViewCommand { get; set; }

        public ICommand DenyTaskCommand { get; set; }
        public ICommand AcceptTaskCommand { get; set; }
        public TaskOverviewViewModel(ICommand updateViewCommand, OrganizierTask suggestion)
        {

            UpdateViewCommand = updateViewCommand;
            OrganizierTask = suggestion;
            SelectedOffer = null;
            OfferReviewCommand = new OfferReviewCommand(UpdateViewCommand);
            RequestViewCommand = new DelegateCommand(RequestView);
            DenyTaskCommand = new DelegateCommand(DenyTask);
            AcceptTaskCommand = new DelegateCommand(AcceptTask);
        }

        public void RequestView()
        {
            //PRONADJI IZ DBA NA OSNOVU TASKA SUGGESTION KOJI SADRZI TAJ TASK I PROSLEDI GA
            /*
             Suggestion sug;
             using (var db = new ProjectDatabase())
                {
                    foreach(Suggestion s in db.Suggestions){
                        foreach(OrganizierTask ot in s.Tasks){
                            if(ot.Id == OragnizierTask.Id){
                                sug = s;
                            }
                        }
                
                    }
                    db.SaveChanges();
                }
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
             */
            UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, new Suggestion( new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"kurcina", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen)
                }, "MASU JAK PREDLOG1", new PartyRequest())));
        }

        public void DenyTask()
        {
            // nadji task u dbu, postavi userapproval na odbijeno i prosledi sugestiju u kojoj se nalazi
            /*
             Suggestion sug;
             using (var db = new ProjectDatabase())
                {
                    foreach(Suggestion s in db.Suggestions){
                        foreach(OrganizierTask ot in s.Tasks){
                            if(ot.Id == OragnizierTask.Id){
                                ot.UserApproval = "Odbijen";
                                ot.Comment = OrganizierTask.Comment;
                                sug = s;
                                
                            }
                        }
                
                    }
                    db.SaveChanges();
                }
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
             */
            UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, new Suggestion( new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"kurcina", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen)
                }, "MASU JAK PREDLOG1", new PartyRequest())));
        }

        public void AcceptTask()
        {
            // prvo moras proveriti jel nesto selektovano, ako nije ispisi dijalog, ako jeste nadji u dbu 
            // task napravi mu user approval prihvacen i u selected offers ubaci izabranu
            if (SelectedOffer != null)
            {
                /*
             Suggestion sug;
             using (var db = new ProjectDatabase())
                {
                    foreach(Suggestion s in db.Suggestions){
                        foreach(OrganizierTask ot in s.Tasks){
                            if(ot.Id == OragnizierTask.Id){
                                ot.UserApproval = "Prihvacen";
                                ot.SelectedOffer = SelectedOffer;
                                ot.Comment = OrganizierTask.Comment;
                                sug = s;
                                
                            }
                        }
                
                    }
                    db.SaveChanges();
                }
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
             */
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, new Suggestion( new List<OrganizierTask>(){
                    new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),

                    }, false,"kurcina", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatfafaak2", "Drugi zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen),
                    new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        new Offer(null,100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,200,"Opasna ponuda3", "nema slike"),
                    }, false,"", UserApproval.Neobradjen)
                }, "MASU JAK PREDLOG1", new PartyRequest())));
            }
            else
            {
                // PRIKAZI NEKI DIJALOG
                MessageBox.Show("MORATE IZABRATI PONUDU");
                Console.WriteLine("MORATE IZABRATI PONUDU");
            }
        }
    }
}
