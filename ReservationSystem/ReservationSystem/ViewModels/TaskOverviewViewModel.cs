﻿using ReservationSystem.Commands;
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
        public bool Answered { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand OfferReviewCommand { get; set; }

        public ICommand RequestViewCommand { get; set; }

        public ICommand DenyTaskCommand { get; set; }
        public ICommand AcceptTaskCommand { get; set; }
        public TaskOverviewViewModel(ICommand updateViewCommand, OrganizierTask suggestion)
        {

            UpdateViewCommand = updateViewCommand;
            OrganizierTask = suggestion;
            Answered = getAnswered();
            SelectedOffer = null;
            OfferReviewCommand = new OfferReviewCommand(UpdateViewCommand);
            RequestViewCommand = new DelegateCommand(RequestView);
            DenyTaskCommand = new DelegateCommand(DenyTask);
            AcceptTaskCommand = new DelegateCommand(AcceptTask);
        }

        public bool getAnswered()
        {
            Suggestion sug = null;
            using (var db = new ProjectDatabase())
            {
                sug = db.Suggestions.Include("OrganizierTasks")
                        .Include("OrganizierTasks.Offers").Where(suggestion => suggestion.Id == OrganizierTask.SuggestionId).First();
                if (sug.Answered == AnsweredType.Prihvacen || sug.Answered == AnsweredType.Odbijen)
                {
                    
                    return false;
                }
                
            }
            return true;
        }
        public void RequestView()
        {
            //PRONADJI IZ DBA NA OSNOVU TASKA SUGGESTION KOJI SADRZI TAJ TASK I PROSLEDI GA
            
             Suggestion sug;
             using (var db = new ProjectDatabase())
                {
                sug = db.Suggestions.Include("OrganizierTasks")
                        .Include("OrganizierTasks.Offers").Where(suggestion => suggestion.Id == OrganizierTask.SuggestionId).First();
                }
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
             
            
        }

        public void DenyTask()
        {
            // nadji task u dbu, postavi userapproval na odbijeno i prosledi sugestiju u kojoj se nalazi
            
             Suggestion sug = null;
             using (var db = new ProjectDatabase())
                {
                sug = db.Suggestions.Include("OrganizierTasks")
                        .Include("OrganizierTasks.Offers").Where(suggestion => suggestion.Id == OrganizierTask.SuggestionId).First();
                if (sug.Answered == AnsweredType.Prihvacen || sug.Answered == AnsweredType.Odbijen)
                {
                    MessageBox.Show("Ovaj zadatak je u okviru ponude na koju ste vec odgovorili!");
                    return;
                }
                OrganizierTask taskk = db.OrganizierTasks.Where(task => task.Id == OrganizierTask.Id).First();
                taskk.Comment = OrganizierTask.Comment;
                taskk.UserApproval = UserApproval.Odbijen;
                
                db.SaveChanges();
                }
            UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
             
           
        }

        public void AcceptTask()
        {
            // prvo moras proveriti jel nesto selektovano, ako nije ispisi dijalog, ako jeste nadji u dbu 
            // task napravi mu user approval prihvacen i u selected offers ubaci izabranu
            if (SelectedOffer != null)
            {
                Suggestion sug = null;
                using (var db = new ProjectDatabase())
                {
                    sug = db.Suggestions.Include("OrganizierTasks")
                            .Include("OrganizierTasks.Offers").Where(suggestion => suggestion.Id == OrganizierTask.SuggestionId).First();
                    if(sug.Answered == AnsweredType.Prihvacen || sug.Answered == AnsweredType.Odbijen)
                    {
                        MessageBox.Show("Ovaj zadatak je u okviru ponude na koju ste vec odgovorili!");
                        return;
                    }
                    OrganizierTask taskk = db.OrganizierTasks.Where(task => task.Id == OrganizierTask.Id).First();
                    taskk.Comment = OrganizierTask.Comment;
                    taskk.UserApproval = UserApproval.Prihvacen;
                    
                    db.SaveChanges();
                }
                UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, sug));
            }
            else
            {
                // PRIKAZI NEKI DIJALOG
                MessageBox.Show("MORATE IZABRATI PONUDU");
            }
        }
    }
}
