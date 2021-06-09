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
    public class CreateSuggestionViewViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand AcceptPendingRequestCommand { get; set; }
        public ICommand CreateTaskCommand { get; set; }
        public List<OrganizierTask> OrganizierTasks { get; set; }
        public PartyRequest Sug { get; set; }
        public Suggestion Suggestion { get; set; }
        public User User { get; set; }
        public ICommand PendingRequestOverviewCommand { get; set; }

        public CreateSuggestionViewViewModel(ICommand updateViewCommand, User user, PartyRequest sug)
        {
            Sug = sug;
            User = user;
            Suggestion = getSuggestion();
            OrganizierTasks = getTasks();
            UpdateViewCommand = updateViewCommand;  
            PendingRequestOverviewCommand = new DelegateCommand(PendingRequestOverviewView);
            AcceptPendingRequestCommand = new DelegateCommand(AcceptPendingRequest);
            CreateTaskCommand = new DelegateCommand(CreateTask);   
        }

        public Suggestion getSuggestion()
        {
            using (var db = new ProjectDatabase())
            {
                Suggestion sugpom = db.Suggestions.Where(sg => sg.PartyRequest.Id == Sug.Id).FirstOrDefault();
                if (sugpom == null) 
                {
                    Suggestion ns = new Suggestion();
                    //Console.WriteLine(Sug.Id);
                    Console.WriteLine(db.PartyRequests.ToList().Count);

                    PartyRequest pr = db.PartyRequests.Where(ppr => ppr.Id == Sug.Id).First();
                    ns.PartyRequest = pr;
                    
                    db.Suggestions.Add(ns);
                    db.SaveChanges();
                    Console.WriteLine(db.PartyRequests.ToList().Count);
                    return ns;
                }

                return sugpom;
            }
        }

        public void CreateTask()
        {
            UpdateViewCommand.Execute(new CreateTaskViewModel(UpdateViewCommand, User, Sug, Suggestion));
        }
        public List<OrganizierTask> getTasks()
        {
            using(var db = new ProjectDatabase())
            {
                Suggestion sugpom = db.Suggestions.Where(sg => sg.PartyRequest.Id == Sug.Id).FirstOrDefault();
                if (sugpom == null) 
                    return null; 
                
                return sugpom.OrganizierTasks;
            }
        }
        public void AcceptPendingRequest()
        {
            if(OrganizierTasks.Count == 0)
            {
                MessageBox.Show("Morate dodati bar jedan zadatak na ponudu!");
                return;
            }
            using (var db = new ProjectDatabase())
            {
                db.PartyRequests.Where(pr => pr.Id == Sug.Id).First().RequestState = RequestState.Active;
                
                db.SaveChanges();
            }
            MessageBox.Show("Prihvatili ste ponudu!");
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
        public void PendingRequestOverviewView()
        {   
            UpdateViewCommand.Execute(new PendingRequestOverview(UpdateViewCommand, Sug));
        }
    }
}
