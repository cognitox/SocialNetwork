//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Social.Data.DatabaseContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionnaireQuestionMultichoiceAnswer
    {
        public QuestionnaireQuestionMultichoiceAnswer()
        {
            this.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks = new HashSet<QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink>();
        }
    
        public System.Guid QuestionnaireQuestionMultichoiceAnswerID { get; set; }
        public System.Guid AccountID { get; set; }
        public System.Guid GroupAccountID { get; set; }
        public System.Guid CommitmentGroupID { get; set; }
        public string Answer { get; set; }
        public string Helptext { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual CommitmentGroup CommitmentGroup { get; set; }
        public virtual GroupAccount GroupAccount { get; set; }
        public virtual ICollection<QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink> QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks { get; set; }
    }
}
