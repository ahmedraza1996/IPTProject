using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.FYP
{
    public class int_model
    {
        public double Marks { get; set; }
    }
    public class Deliverables
    {
        public string Deliverables1 { get; set; }
        public string Deliverables2 { get; set; }
        public string Deliverables3 { get; set; }
        public string Deliverables4 { get; set; }
        public string Deliverables5 { get; set; }
    }
    public class StudentProposal
    {
        public int ProposalID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }
        public string Abstract { get; set; }
        public int SupervisorID { get; set; }
        public int CoSupervisorID { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
    }

    public class GlobalModel
    {
        public StudentProposal SearchModel { get; set; }
        public IEnumerable<StudentProposal> IndexModels { get; set; }
    }

    public class FypResponse
    {
        public int FypID { get; set; }
        public int CoSuperVisorID { get; set; }
        public int SupervisorEmpID { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }

    }

    public class StudentDefense
    {
        public int SupervisorEmpID { get; set; }
        public string ProjectName { get; set; }
        public int SupervisorID { get; set; }
        public int CoSupervisorID { get; set; }
        public string DefenceStatus { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }
        public double Criteria1Marks { get; set; }
        public double Criteria2Marks { get; set; }
        public double Criteria3Marks { get; set; }
        public double Criteria4Marks  { get; set; }
        public double Criteria5Marks { get; set; }
        public string Deliverables1 { get; set; }
        public string Deliverables2 { get; set; }
        public string Deliverables3 { get; set; }
        public string Deliverables4 { get; set; }
        public string Deliverables5 { get; set; }
        public string ChangesRecommeneded { get; set; }
    }
    public class GlobalDefense
    {
        public StudentDefense SearchModel { get; set; }
        public IEnumerable<StudentDefense> IndexModels { get; set; }
    }
    public class Fyp1FinalModel
    {
        public string ProjectName { get; set; }
        public int SuperVisorEmpID { get; set; }
        public int CoSuperVisorID { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }
        public string Deliverable1 { get; set; }
        public string Deliverable2 { get; set; }
        public string Deliverable3 { get; set; }
        public string Deliverable4 { get; set; }
        public string Deliverable5 { get; set; }
        public string Fyp2Deliverables { get; set; }
        public double Deliverable1Completion { get; set; }
        public double Deliverable2Completion { get; set; }
        public double Deliverable3Completion { get; set; }
        public double Deliverable4Completion { get; set; }
        public double Deliverable5Completion { get; set; }
        public int leaderMarks { get; set; }
        public int member1marks { get; set; }
        public int member2marks { get; set; }

    }

    public class GlobalFinal
    {
        public Fyp1FinalModel SearchModel { get; set; }
        public IEnumerable<Fyp1FinalModel> IndexModels { get; set; }
    }

    ///FYP 2
    public class FYP2MidEvaluation
    {
        public int FormID { get; set; }
        public int FypID { get; set; }
        public string ProjectName { get; set; }
        public int SuperVisorEmpID { get; set; }
        public int CoSupervisorID { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }
        public string ProjectProgress { get; set; }
        public string DocumentationStatus { get; set; }
        public string ProgressComments { get; set; }

    }
    public class Marks_Model
    {
        public double Marks { get; set; }
    }
    public class GlobalFyp2Mid
    {
        public FYP2MidEvaluation SearchModel { get; set; }
        public IEnumerable<FYP2MidEvaluation> IndexModels { get; set; }
    }
    public class GlobalFyp2Final
    {
        public FYP2FinalEvaluation SearchModelFinal { get; set; }
        public IEnumerable<FYP2FinalEvaluation> IndexModelsFinal { get; set; }
    }
    public class FYP2FinalEvaluation
    {
        public int FormID { get; set; }
        public int FypID { get; set; }
        public string ProjectName { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }
        public int SupervisorEmpID { get; set; }
        public int CoSupervisorID { get; set; }
        public int leaderMarks { get; set; }
        public int member1marks { get; set; }
        public int member2marks { get; set; }
        public int EvaluationID { get; set; }

    }


}