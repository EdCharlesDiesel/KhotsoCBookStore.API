using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
    public class Survey
    {
        private SurveyState state;
        readonly StarPeaceAdminDbContext _dbContext;
         
        public Survey(SurveyState state, StarPeaceAdminDbContext dbContext)
        {
            this.state = state?? throw new ArgumentNullException(nameof(_dbContext));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public SurveySnapshot CreateSnapshot()
        {
            SurveySnapshot snapshot = new SurveySnapshot(AppSettings.StoragePath);
            snapshot.Save(this.state);
            return snapshot;
        }

        public void RestoreSnapshot(SurveySnapshot snapshot)
        {
            this.state = snapshot.Restore();
        }

        public List<string> GetAnswers()
        {
            return this.state.Answers;
        }

        public void Submit()
        {
       
            for (int i = 0; i < state.Questions.Count; i++)
            {
                Answer ans = new Answer();
                ans.QuestionId = state.Questions[i];
                ans.AnswerText = state.Answers[i];
                ans.SubmittedOn = DateTime.Now;
                _dbContext.Answers.Add(ans);
            }
            _dbContext.SaveChanges();
            }
        }
    
}
